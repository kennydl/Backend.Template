using System;

namespace Backend.Template.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ScopedServiceAttribute : Attribute
    {
    }
}
