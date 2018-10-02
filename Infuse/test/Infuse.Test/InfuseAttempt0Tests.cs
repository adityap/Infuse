using InfuseAttempt0;
using InfuseAttempt0.Extensions;
using System;
using Xunit;
using Infuse.Test.TestData;
using InfuseAttempt0.Enums;
using InfuseAttempt0.Contracts;

namespace InfuseAttempt0.Tests
{
    public class InfuseAttempt0Tests
    {
        [Fact]
        public void ShouldThrowExceptionWhenTypeNotRegistered()
        {
            var container = new InfuseContainer();
            Assert.Throws<ArgumentException>(() => {
                var pet = container.Resolve<Logger>();
            });
        }

        [Fact]
        public void RegisterAsSingletonAndResolve()
        {
            var container = new InfuseContainer();
            container.Register<Logger, Logger>(LifecycleType.Singleton);

            var logger = container.Resolve<Logger>();
            Assert.NotNull(logger);
            Assert.IsType<Logger>(logger);
        }

        [Fact]
        public void RegisterAsSingletonUsingExtensionAndResolve()
        {
            var container = new InfuseContainer();
            container.RegisterSingleton<Logger, Logger>();

            var logger = container.Resolve<Logger>();
            Assert.NotNull(logger);
            Assert.IsType<Logger>(logger);
        }

        [Fact]
        public void RegisterAsTransientAndResolve()
        {
            var container = new InfuseContainer();
            container.Register<Logger, Logger>(LifecycleType.Transient);

            var logger = container.Resolve<Logger>();
            Assert.NotNull(logger);
            Assert.IsType<Logger>(logger);
        }

        [Fact]
        public void RegisterAsTransientUsingExtensionAndResolve()
        {
            var container = new InfuseContainer();
            container.RegisterTransient<Logger, Logger>();

            var logger = container.Resolve<Logger>();
            Assert.NotNull(logger);
            Assert.IsType<Logger>(logger);
        }

        [Fact]
        public void EnsureDefaultRegistrationLifecycleIsTransient()
        {
            var container = new InfuseContainer();
            container.Register<Logger, Logger>();

            var logger1 = container.Resolve<Logger>();
            var logger2 = container.Resolve<Logger>();

            Assert.NotSame(logger1, logger2);

        }

        [Fact]
        public void RegisterTypeWithParametersAndResolve()
        {
            var container = new InfuseContainer();

            container.Register<IChat, Chatroom>(LifecycleType.Singleton);
            container.RegisterSingleton<IPerson, PersonA>();

            var person = container.Resolve<IPerson>();

            Assert.NotNull(person);
        }



        [Fact]
        public void DuplicateTypeRegistrationOverwritesThePreviousOne()
        {
            var container = new InfuseContainer();

            container.Register<IChat, Chatroom>(LifecycleType.Singleton);

            container.RegisterSingleton<IPerson, PersonA>();
            container.RegisterSingleton<IPerson, PersonB>();

            var person = container.Resolve<IPerson>();
            Assert.IsType<PersonB>(person);
        }

        [Fact]
        public void SingletonIsSharedBetweenHierarchy()
        {
            var container = new InfuseContainer();
            container.Register<Logger, Logger>(LifecycleType.Singleton);
            container.Register<TestLoggerController, TestLoggerController>(LifecycleType.Singleton);
            container.Register<TestLoggerRepository, TestLoggerRepository>(LifecycleType.Singleton);

            string str = "Hello";

            var a = container.Resolve<TestLoggerController>();

            a.Update(str);

            Assert.Equal(str, a.Fetch());
        }

        [Fact]
        public void SingletonsHasOnlyOneInstancePerContainer()
        {
            IContainer container = new InfuseContainer();
            container.Register<IChat, Chatroom>(LifecycleType.Singleton);
            container.RegisterSingleton<IPerson, PersonA>();

            string talkMsg = "Hello";

            var a = container.Resolve<IPerson>();
            var chat = container.Resolve<IChat>();

            a.Say(talkMsg);

            Assert.Equal(talkMsg, chat.Receive());
        }

        [Fact]
        public void TransientDoesNotRegisterAsSingleton_ButManagesSingletonWithinIt()
        {
            IContainer container = new InfuseContainer();
            container.Register<IChat, Chatroom>(LifecycleType.Singleton);
            container.RegisterTransient<IPerson, PersonA>();

            string talkMsg = "Hello";

            var a = container.Resolve<IPerson>();
            var b = container.Resolve<IPerson>();

            Assert.NotSame(a, b);

            a.Say(talkMsg);
            Assert.Equal(talkMsg, b.Listen());
        }

        [Fact]
        public void SingletonsAreSharedBetweenMultipleTransient()
        {
            IContainer container = new InfuseContainer();
            container.Register<IChat, Chatroom>(LifecycleType.Singleton);
            container.RegisterTransient<PersonA, PersonA>();
            container.RegisterTransient<PersonB, PersonB>();

            string talkMsg = "Hello";

            var a = container.Resolve<PersonA>();
            var b = container.Resolve<PersonB>();

            Assert.NotSame(a, b);

            a.Say(talkMsg);
            Assert.Equal(talkMsg, b.Listen());
        }

        [Fact]
        public void RegisterTransientTypeWithinASingletonTypeGetsAutoPromotedToSingleton()
        {
            IContainer container = new InfuseContainer();

            container.RegisterSingleton<IPerson, PersonA>();
            container.Register<IChat, Chatroom>(LifecycleType.Transient);


            string talkMsg = "Hello";

            var a = container.Resolve<IPerson>();
            var b = container.Resolve<IPerson>();

            Assert.Same(a, b);

            a.Say(talkMsg);

            Assert.Equal(talkMsg, b.Listen());
        }

        [Fact]
        public void ShouldThrowExceptionWhenPublicConstructorNotFound()
        {
            IContainer container = new InfuseContainer();

            container.Register<NoPublicConstructor, NoPublicConstructor>();

            Assert.Throws<InvalidOperationException>(() => {
                var oops = container.Resolve<NoPublicConstructor>();
            });
        }

        [Fact]
        public void ShouldThrowExceptionWhenPublicConstructorNotFoundInHierarchy()
        {
            IContainer container = new InfuseContainer();

            container.Register<NoPublicConstructor, NoPublicConstructor>();
            container.Register<DependsOnNonPublicConstructorClass, DependsOnNonPublicConstructorClass>();

            Assert.Throws<InvalidOperationException>(() => {
                var oops = container.Resolve<DependsOnNonPublicConstructorClass>();
            });
        }

        [Fact]
        public void ShouldThrowExceptionWhenPublicConstructorNotFoundInHierarchyOfMixedClasses()
        {
            IContainer container = new InfuseContainer();

            container.Register<NoPublicConstructor, NoPublicConstructor>();
            container.Register<PerfectlyNormalClass, PerfectlyNormalClass>();
            container.Register<DependsOnMixedConstructorClass, DependsOnMixedConstructorClass>();

            Assert.Throws<InvalidOperationException>(() => {
                var oops = container.Resolve<DependsOnMixedConstructorClass>();
            });
        }
    }
}
