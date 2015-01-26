using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RunrunIt4Net.Attributes;

namespace RunrunIt4Net.Converter
{
    public class RunrunitSerializeEntityResolver : DefaultContractResolver
    {
        private readonly Attribute _attribute;

        public RunrunitSerializeEntityResolver(Attribute attribute)
        {
            _attribute = attribute;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (property.AttributeProvider.GetAttributes(false).Any(w => ReferenceEquals(w.TypeId, _attribute.TypeId)))
            {
                return property;
            }

            return null;
        }
    }
}
