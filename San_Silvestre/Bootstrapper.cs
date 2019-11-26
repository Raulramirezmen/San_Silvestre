using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using SanSil.BLL.User.Interface;
using SanSil.BLL.User.Implementation;
using San_Silvestre.Models;
using log4net;
using San_Silvestre.Controllers;
using SanSil.BLL.Gender.Interface;
using SanSil.BLL.Gender.Implementation;
using SanSil.BLL.Award.Implementation;
using SanSil.BLL.Award.Interface;
using SanSil.BLL.Runner.Implementation;
using SanSil.BLL.Runner.Interface;
using SanSil.BLL.Position.Implementation;
using SanSil.BLL.Position.Interface;


namespace San_Silvestre
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      container.RegisterType<IUserManager, UserManager>();
      container.RegisterType<IGenderManager, GenderManager>();
      container.RegisterType<IRunnerManager, RunnerManager>();
      container.RegisterType<IPositionManager, PositionManager>();
      container.RegisterType<IAwardManager, AwardManager>();

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
    
    }

  }
}