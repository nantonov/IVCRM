using Newtonsoft.Json;
using System.Text;

namespace IVCRM.API.IntegrationTests.Infrastructure.Extensions
{
    internal static class HttpRequestMessageExtensions
    {
        private const string JsonContentType = "application/json";

        internal static void AddContent<T>(this HttpRequestMessage requestMessage, T content)
        {
            if (content is not null)
            {
                requestMessage.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, JsonContentType);
            }
        }
    }
}
