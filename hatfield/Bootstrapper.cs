using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using hatfield.Data;

namespace hatfield
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
      RegisterTypes(container);
      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
        container.RegisterType<IDataProvider, DataProvider>();
    }
  }
}