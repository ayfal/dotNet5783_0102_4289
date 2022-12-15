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
        public static void CopyProperties/*<TDest, TSrc>*/(/*TDest?*/ this object dest, /*TSrc?*/ object src)
        {
            //foreach (var srcProp in (src ?? throw new NullReferenceException()).GetType().GetProperties())
            //    foreach (var destProp in dest!.GetType().GetProperties())
            //        if (srcProp.Name == destProp.Name && srcProp.PropertyType == destProp.PropertyType)
            //            destProp.SetValue(dest, srcProp.GetValue(src));
            PropertyInfo[] srcProp = (src ?? throw new NullReferenceException()).GetType().GetProperties();
            for (int i = 0; i < srcProp.Length; i++)
            {
                PropertyInfo[] destProp = dest!.GetType().GetProperties();
                for (int j = 0; j < destProp.Length; j++)
                {
                    if (srcProp[i].Name == destProp[j].Name && srcProp[i].PropertyType == destProp[j].PropertyType)
                        destProp[j].SetValue(dest, srcProp[i].GetValue(src));
                }
            }
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
