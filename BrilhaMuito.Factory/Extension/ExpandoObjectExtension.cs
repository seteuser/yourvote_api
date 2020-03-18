using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

namespace BrilhaMuito.Factory.Extension
{
    public static class ExpandoObjectExtension
    {
        public static ExpandoObject ToExpando(this IDictionary<string, object> dictionary)
        {
            var expando = new ExpandoObject();
            var expandoDic = (IDictionary<string, object>)expando;

            foreach (var kvp in dictionary)
            {
                if (kvp.Value is IDictionary<string, object>)
                {
                    var expandoValue = ((IDictionary<string, object>)kvp.Value).ToExpando();
                    expandoDic.Add(kvp.Key, expandoValue);
                }
                else if (kvp.Value is ICollection)
                {
                    var itemList = new List<object>();
                    foreach (var item in (ICollection)kvp.Value)
                    {
                        if (item is IDictionary<string, object>)
                        {
                            var expandoItem = ((IDictionary<string, object>)item).ToExpando();
                            itemList.Add(expandoItem);
                        }
                        else
                        {
                            itemList.Add(item);
                        }
                    }
                    expandoDic.Add(kvp.Key, itemList);
                }
                else
                {
                    expandoDic.Add(kvp);
                }
            }
            return expando;
        }

        public static ExpandoObject ToExpando<T>(this object obj)
        {
            IDictionary<string, object> expando = new ExpandoObject();
            foreach (var propertyInfo in typeof(T).GetProperties())
            {
                var currentValue = propertyInfo.GetValue(obj);
                expando.Add(propertyInfo.Name.Contains(typeof(T).Name) ? "_id" : propertyInfo.Name, currentValue);
            }
            return (ExpandoObject)expando;
        }
    }
}