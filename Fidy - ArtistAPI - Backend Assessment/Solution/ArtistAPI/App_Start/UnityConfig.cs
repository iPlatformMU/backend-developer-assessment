using System.Web.Http;
using Unity;
using Unity.WebApi;
using ArtistAPI.Services;


namespace ArtistAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IGetArtistSvc, GetArtistsSvc>();
            container.RegisterType<ISearchMusicBrainzReleaseSvc, SearchMusicBrainzReleaseSvc>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}