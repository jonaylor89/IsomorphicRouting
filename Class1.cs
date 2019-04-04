using System;

namespace IsomorphicRouting
{

    public static class FeRouteExtension {

        /**
        * Map the front end routes located in a JSON file
        * For modern SPA applications that do their own routing,
        * mapping the frontend routes will allow for the backend to
        * know when to send a proper 404 error 
        */
        public static void MapFeRoutes(this IRouteBuilder routeBuilder, string pathToRoutes) {

            // Grab path data from JSON
            JArray paths = JArray.Parse(File.ReadAllText(pathToRoutes));
        
            // Loop through the list of routes and add map them into the routing table
            foreach (var r in paths.Children<JObject>().Select((x, i) => new { Value = x, Index = i })) {
                routesBuilder.MapRoute(
                    name: $"feRoute${r.Index}",
                    template: (string)r.Value["path"],
                    defaults: new { controller = "Home", action = "Index" },
                    constraints: null
                );  
            }
        }
    }
}