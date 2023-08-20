using ACME.Store.Domain.Entities;
using AutoMapper;
using System.Linq;

namespace ACME.Store.Application.Extensions;

public static class AutoMapper
{
    public static IMappingExpression<TSource, TDestination> IgnoreBaseEntityProperties<TSource, TDestination>(
        this IMappingExpression<TSource, TDestination> mappingExpression)
        where TDestination : new()
    {
        var destinationProperties = typeof(TDestination).GetProperties();

        var baseEntityProperties = typeof(BaseEntity).GetProperties();

        foreach (var baseEntityProperty in baseEntityProperties)
        {
            var matchingProperty = destinationProperties.FirstOrDefault(p => p.Name == baseEntityProperty.Name);

            if (matchingProperty != null)
            {
                mappingExpression.ForMember(matchingProperty.Name, opt => opt.Ignore());
            }
        }

        return mappingExpression;
    }
}
