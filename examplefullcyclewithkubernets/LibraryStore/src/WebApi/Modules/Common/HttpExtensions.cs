using System;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebApi.Modules.Common
{
    public static class HttpExtensions
    {
        public enum CaseStrategy { CamelCase, SnakeCase }

        public enum IndentStrategy { Indented, None }

        private static JsonSerializerSettings GetSettings(CaseStrategy caseStrategy, IndentStrategy indentStrategy)
        {
            NamingStrategy strategy = caseStrategy switch
            {
                CaseStrategy.SnakeCase => new SnakeCaseNamingStrategy(),
                _ => new CamelCaseNamingStrategy(),
            };
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = strategy
                },
                Formatting = indentStrategy == IndentStrategy.Indented ? Formatting.Indented : Formatting.None,
                NullValueHandling = NullValueHandling.Ignore,
                
            };

            return settings;
        }

        public static StringContent AsJsonContent(this object body, CaseStrategy caseStrategy = CaseStrategy.CamelCase)
        {
            return new StringContent(body.AsJson(caseStrategy), Encoding.UTF8, "application/json");
        }

        public static string AsJson(this object body, CaseStrategy caseStrategy = CaseStrategy.CamelCase, IndentStrategy indentStrategy = IndentStrategy.Indented)
        {
            return JsonConvert.SerializeObject(body, GetSettings(caseStrategy, indentStrategy));
        }

        public static async Task<T> GetResponseAsync<T>(this HttpResponseMessage http, CaseStrategy caseStrategy = CaseStrategy.CamelCase, IndentStrategy indentStrategy = IndentStrategy.Indented)
        {
            try
            {
                var content = await http.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content, GetSettings(caseStrategy, indentStrategy));
            }
            catch (Exception e)
            {
                throw new SerializationException($"Erro ao obter response da requisição, com a seguinte mensagem: {e.Message}");
            }
        }
    }
}