using Newtonsoft.Json;

namespace IVCRM.IntegrationTests.Infrastructure.Extensions
{
    internal static class HttpResponseMessageExtension
    {
        internal static T GetResponseResult<T>(this HttpResponseMessage responseMessage)
        {
            return JsonConvert.DeserializeObject<T>(responseMessage.Content.ReadAsStringAsync().Result);
        }
    }
}
