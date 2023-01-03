using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BO
{
    public static class Extensions
    {
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public static void CopyProperties(this object dest, object src)
        {
            foreach (var srcProp in (src ?? throw new NullReferenceException()).GetType().GetProperties())
                foreach (var destProp in dest!.GetType().GetProperties())
                    if (srcProp.Name == destProp.Name && srcProp.PropertyType == destProp.PropertyType)
                        destProp.SetValue(dest, srcProp.GetValue(src));
        }

        /// <summary>
        /// converts any object to string, automatically getting the properties' names 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns>that string</returns>
        public static string AutoToString<T>(this T t)
        {
            string s = "";
            foreach (var p in t?.GetType().GetProperties() ?? throw new NullReferenceException())
            {
                s+=$"{p.Name}: ";
                var q = p.GetValue(t);
                if (q is IEnumerable && q is not string) foreach (var i in q as IEnumerable) s += $"{i}"; 
                else s += $"{q}\n";
            }
            return s;
            //return JsonSerializer.Serialize(t, new JsonSerializerOptions { WriteIndented = true });

            //var propertyStrings = from prop in t.GetType().GetProperties()
            //                      select $"{prop.Name}: {prop.GetValue(t)}";
            //return string.Join("\n", propertyStrings);
        }
    }
}
