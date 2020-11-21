using System;

namespace Backend.Template.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class SingletonServiceAttribute : Attribute
    {
    }
}
