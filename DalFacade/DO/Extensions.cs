using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public static class Extensions
    {        
        /// <summary>
        /// converts any object to string, automatically getting the properties' names 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns>that string</returns>
        public static string AutoToString<T>(this T t)
        {
            string s = "";
            foreach (var p in t!.GetType().GetProperties())
                s += $"{p.Name}: {p.GetValue(t)}\n";
            return s;
        }
    }
}
