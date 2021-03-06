using System;

namespace Enbiso.NLib.OpenApi.Attributes.Inputs
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ExtInputTextAttribute : ExtInputAttribute
    {
        public ExtInputTextAttribute() : base("text")
        {
        }
    }
}
