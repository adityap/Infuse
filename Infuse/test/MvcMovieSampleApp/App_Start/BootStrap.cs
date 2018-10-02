using Infuse;
using Infuse.Extensions;
using MvcMovieSampleApp.Controllers;
using MvcMovieSampleApp.Repositories;

namespace MvcMovieSampleApp
{
    public class Bootstrap
    {
        public static IContainer ConfigureInfuseContainer()
        {
            IContainer infuseContainer = new InfuseContainer();

            infuseContainer.RegisterSingleton<IHomeRepository, HomeRepository>();

            infuseContainer.Register<HomeController, HomeController>();
            infuseContainer.Register<AccountController, AccountController>();
            infuseContainer.Register<ManageController, ManageController>();
            infuseContainer.Register<MoviesController, MoviesController>();
            infuseContainer.Register<HelloWorldController, HelloWorldController>();

            return infuseContainer;
        }
    }
}
