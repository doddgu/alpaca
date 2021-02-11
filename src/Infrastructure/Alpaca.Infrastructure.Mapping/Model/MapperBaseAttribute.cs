using System;

namespace Alpaca.Infrastructure.Mapping.Model
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class MapperBaseAttribute : Attribute
    {

    }
}