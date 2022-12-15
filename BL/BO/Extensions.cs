using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
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
            foreach (var p in t.GetType().GetProperties())
                s += $"{p.Name}: {string.Join("", p.GetValue(t))}\n";
            return s;
        }
    }
}
