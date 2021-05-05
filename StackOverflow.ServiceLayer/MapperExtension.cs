using AutoMapper;

namespace StackOverflow.ServiceLayer
{
    public static class MapperExtension
    {
        private static void IgnoreUnMapped(this IProfileExpression profile)
        {
            profile.ForAllMaps(IgnoreUnMappedProperties);
        }

        private static void IgnoreUnMappedProperties(TypeMap map, IMappingExpression expression)
        {
            foreach (string unmappedProperty in map.GetUnmappedPropertyNames())
            {
                if (map.SourceType.GetProperty(unmappedProperty) != null)
                {
                    expression.ForSourceMember(unmappedProperty, option => option.Ignore());
                }
                if (map.DestinationType.GetProperty(unmappedProperty) != null)
                {
                    expression.ForSourceMember(unmappedProperty, option => option.Ignore());
                }
            }
        }
    }
}
