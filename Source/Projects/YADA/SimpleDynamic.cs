using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace YADA
{
    public class SimpleDynamic : DynamicObject
    {
        private Dictionary<string, object> PropertyMap { get; set; } 

        public SimpleDynamic(string[] properties, object[] values)
        {
            Contract.Requires(properties.Length == values.Length);

            PropertyMap = new Dictionary<string, object>();

            for (int i = 0; i < properties.Length; ++i)
                PropertyMap.Add(properties[i], values[i]);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return PropertyMap.TryGetValue(binder.Name, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            string propertyName = binder.Name;

            if (!PropertyMap.ContainsKey(propertyName))
                return false;

            PropertyMap[propertyName] = value;

            return true;
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return PropertyMap.Keys;
        }
    }
}
