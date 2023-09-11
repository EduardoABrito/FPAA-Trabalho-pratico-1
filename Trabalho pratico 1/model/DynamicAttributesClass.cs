using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_pratico_1.model
{
    internal class DynamicAttributesClass
    {
        public Dictionary<string, object> attributes = new Dictionary<string, object>();

        public void AddAttribute(string attributeName, object attributeValue)
        {
            attributes[attributeName] = attributeValue;
        }

        public object GetAttribute(string attributeName)
        {
            if (attributes.ContainsKey(attributeName))
            {
                return attributes[attributeName];
            }
            else
            {
                return null; // Ou lança uma exceção se preferir
            }
        }
    }
}
