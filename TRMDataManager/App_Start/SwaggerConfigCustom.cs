using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Web.Http.Description;

namespace TRMDataManager.App_Start
{
    public class SwaggerAuthTokenOperation : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            swaggerDoc.paths.Add("/token", new PathItem()
            {
                post = new Operation
                {
                    tags = new List<string> { "Auth" },
                    consumes = new List<string> { "application/x-www-form-urlencoded" },
                    parameters = new List<Parameter>
                    {
                        new Parameter
                        {
                            type = "string",
                            name = "grant_type",
                            required = true,
                            @in = "formdata",
                            @default = "password"
                        },
                        new Parameter
                        {
                            type = "string",
                            name = "username",
                            required = false,
                            @in = "formdata"
                        },
                        new Parameter
                        {
                            type = "string",
                            name = "password",
                            required = false,
                            @in = "formdata"
                        },

                    }
                }
            });
        }
    }
}