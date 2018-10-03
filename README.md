# Infuse
<div style="font:bold"> An Simple IoC container made for educational purposes!</div>

<h3>Infuse IoC Purpose & Features</h3>
<p>
  This purpose of this project is to serve as an educational greed for one to understand the internals of how IoC containers might work. 
  The implementation is very general and should not be used in actual production apps.   It does not mimic the likes of better containers
  out there ([in no particular order] Ninject, Autofac etc.) as it would defeat the very purpose this was built for - 'possible explanation of how IoC are build and function'
  <br/>
  There are few features that the <i>Infuse</i> container provides:
  <ul style="list-style-type:circle">
    <li>Support for two lifecycle types for object registration</li>
      <ul>
        <li><code>LifecycleType.Transient</code> - A new instance of the object is returned for every resolve</li>
        <li><code>LifecycleType.Singleton</code> - A same instance of the object is returned for every subsequent resolves</li>
      </ul>
    <li>Register Types. Multiple ways to do so - </li>
    <ul>
      <li><code>container.Register<<i>TInterface</i>,<i>TConcrete</i>>()</code>. The default Lifecycle of the objects registered 
      this way is <code>Lifecycle.Transient</code></li>
      <li><code>container.Register<<i>TInterface</i>,<i>TConcrete</i>>(LifecycleType type)</code></li>
      <li><code>container.RegisterSingleton<<i>TInterface</i>,<i>TConcrete</i>>()</code>. An Extension method</li>
      <li><code>container.RegisterTransient<<i>TInterface</i>,<i>TConcrete</i>>()</code>. An Extension method</li>
      <li>Registration takes care of notifying if an <code>TInterface</code> is already registered in the container</li>
    </ul>
    <li>Resolve Types. Multiple ways to do so - </li>
    <ul>
      <li><code>container.Resolve<<i>TInterface</i>>()</code></li>
      <li><code>container.Resolve(<i>System.Type</i> type)</code> where <code>type</code> is <code>typeof(TInterface)</code></li>
      <li>Resolution takes care of following things</li>
      <ul>
        <li>Resolve Singleton from the Singleton store</li>
        <li>Resolving inter-dependency scenarios where DI applies. E.g.: <code>Controller</code> is dependent on 
        <code>Repository</code>. It does so by supporting <i>Constructor Injection</i> at the moment</li>
        <li>Informative error resolution in case resolution is attempted to be done for an unregistered type</li>
      </ul>
    </ul>
    <li>xUnit Test Coverage</li>
  </ul>
</p>

<h3>Repository Structure</h3>
<p>
  There are two main folders in the solution - 
  <ul style="list-style-type:circle">
    <li><i>src</i><br>
    This folder contains the IoC library project</li>
    <ul>
        <li><i>Infuse</i>: This is the main IoC container project. It's a class library project with dependenct on .NET Standard</li>
        <li><i>Infuse.Attempt0</i>: This is another IoC container project that was started with initially but ran into snags 
        with design and tests thereon. It's a class library project with dependenct on .NET Standard. 
        It's there in repo because I intend to fix this someday and can be <b>ignored</b></li>
    </ul>
    <li><i>test</i><br/>
    This folder contains two test projects
    </li>
    <ul>
      <li><i>Infuse.Test</i>: This is the main IoC container test project. It's a xUnit test project 
      and contains test files for both the IoC container projects</li>
      <li><i>MvcMovieSampleApp</i>: This is a ASP.NET MVC Sample application project that attempts to show the Infuse IoC in action</li>
    </ul>
  </ul>
</p>

<h3>Future</h3>
<p>
  <ul>
    <li>Add sample usage for a ASP.NET Core Web project</li>
    <li>Introduce new options for <code>LifecycleType</code></li>
    <li>Support non-public constructors for type resolution</li>
    <li>Explore possibility of other DI injection kinds e.g.: Setter injection</li>
    <li>Publish <i>Infuse</i> to the Nuget for package management</li>
    <li>Explore the possibility to refactor the code to use a version of <i>Infuse</i> library to achieve DI for <i>Infuse</i></li>
    <li>Create easy to use extensions for using <i>Infuse</i> with different project types. This will be similar to what other container libraries do</li>
</ul>
</p>
