using ShippingService.DAL.Attributes;

namespace ShippingService.DAL.Extensions
{
    public static class EntityExtensionMethods
    {
        public static string? GetCollectionName(this Type type)
        {
            var attribute = type.GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault() as BsonCollectionAttribute;
            if (attribute != null)
            {
                return attribute.CollectionName;
            }

            return default;
        }
    }
}
