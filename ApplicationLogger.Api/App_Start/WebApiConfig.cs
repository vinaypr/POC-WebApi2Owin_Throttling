namespace ApplicationLogger.Api
{
    using ApplicationLogger.Api.MessageHandlers;
    using System.Web.Http;
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes

            config.MapHttpAttributeRoutes();
            config.MessageHandlers.Add(new ThrottlingHandler());
        }
    }
}
