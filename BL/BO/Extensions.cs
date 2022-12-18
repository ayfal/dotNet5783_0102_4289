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
        /// <summary>
        /// copy similar properties from another object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public static void CopyProperties(this object B, object D)
        {
            foreach (var d in D.GetType().GetProperties())
                foreach (var b in B.GetType().GetProperties())
                    if (d.Name == b.Name && d.PropertyType == b.PropertyType)
                        b.SetValue(B, d.GetValue(D));
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
                s += $"{p.Name}: {string.Join("", p.GetValue(t))}\n";
            return s;
        }
    }
}
