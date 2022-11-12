using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApi.Controllers.UseCases;

namespace WebApi.Modules.Filters
{
    public class LogActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var logger = context.HttpContext.RequestServices.GetService<ILogger<ApiController>>();
            var request = context.HttpContext.Request;

            logger.LogInformation("Rota do tipo {0} acionada: `{1}://{2}{3}`", request.Method, request.Scheme, request.Host, request.Path);

            if (request.ContentLength != null && request.ContentLength > 0 && !request.HasFormContentType)
            {
                var reader = new StreamReader(request.Body);
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                var body = reader.ReadToEndAsync().Result;

                var json = JToken.Parse(body).ToString(Formatting.Indented);
                json = RemoveSenhaDoJson(json);
                logger.LogInformation("Body da requisição: \n{1}", json);
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
            }

            base.OnActionExecuting(context);
        }

        private static string RemoveSenhaDoJson(string json)
        {
            try
            {
                var o = (JObject)JsonConvert.DeserializeObject(json);
                var campoSenha = o.Property("senha");
                if (campoSenha != null)
                {
                    campoSenha.Remove();
                }

                return o.ToString();
            }
            catch (Exception)
            {
                return json;
            }
        }
    }
}