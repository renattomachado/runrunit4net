using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.PeerToPeer.Collaboration;
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
        private bool _onlyFilled;

        public RunrunitSerializeEntityResolver(Attribute attribute)
        {
            _attribute = attribute;
        }

        public RunrunitSerializeEntityResolver(Attribute attribute, bool onlyFilled)
        {
            _attribute = attribute;
            _onlyFilled = onlyFilled;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (property.AttributeProvider.GetAttributes(false).Any(w => ReferenceEquals(w.TypeId, _attribute.TypeId)))
            {
                if (_onlyFilled)
                    //TO-DO: Find method for get value JsonProperty for filter properties that have value and properties that are required

                return property;
            }

            return null;
        }
    }
}
