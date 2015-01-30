using System;
using System.CodeDom;
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
using RunrunIt4Net.Enum;

namespace RunrunIt4Net.Converter
{
    public class RunrunitSerializeEntityResolver : DefaultContractResolver
    {
        private readonly Attribute _attribute;
        private RequestType _requestType;

        public RunrunitSerializeEntityResolver(Attribute attribute)
        {
            _attribute = attribute;
        }

        public RunrunitSerializeEntityResolver(Attribute attribute, RequestType requestType)
        {
            _attribute = attribute;
            _requestType = requestType;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            switch (_requestType)
            {
                case RequestType.Get:
                    {
                        if (property.AttributeProvider.GetAttributes(false).Any(w => ReferenceEquals(w.TypeId, typeof(GetColumnAttribute))))
                        {
                            return property;
                        }
                        break;
                    }
                case RequestType.Post:
                {
                    if (property.AttributeProvider.GetAttributes(false).Any(w => ReferenceEquals(w.TypeId, typeof(PostColumnAttribute))))
                    {
                        return property;
                    }
                    break;
                }
                case RequestType.Put:
                {
                    if (property.AttributeProvider.GetAttributes(false).Any(w => ReferenceEquals(w.TypeId, typeof(PostColumnAttribute))))
                    {
                        return property;
                    }
                    break;
                }
            }

            return null;
        }
    }
}
