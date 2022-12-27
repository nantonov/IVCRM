using System.Web;

namespace IVCRM.API.IntegrationTests.Infrastructure.Extensions
{
    public static class Extensions
    {
        public static string ToQueryString(this object obj)
        {
            var properties = obj.GetType()
                .GetProperties()
                .Where(x => x.GetValue(obj, null) != null)
                .Select(x => x.Name + "=" + HttpUtility.UrlEncode(x.GetValue(obj, null).ToString()));
            return String.Join("&", properties.ToArray());
        }
    }
}
