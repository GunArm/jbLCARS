﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LCARS.CoreUi.Helpers
{
    /// <summary> Enum Extension Methods </summary>
    /// <typeparam name="T"> type of Enum </typeparam>
    public class Enum<T> where T : struct, IConvertible
    {
        public static List<T> ToList()
        {
            if (!typeof(T).IsEnum) throw new ArgumentException("T must be an enumerated type");
            return Enum.GetValues(typeof(T)).Cast<T>().OrderBy(o => Convert.ToInt32(o)).ToList();
        }

        public static int Count
        {
            get
            {
                if (!typeof(T).IsEnum) throw new ArgumentException("T must be an enumerated type");
                return Enum.GetValues(typeof(T)).Length;
            }
        }

        public static int IndexOf(string name)
        {
            if (!typeof(T).IsEnum) throw new ArgumentException("T must be an enumerated type");
            return (int)Enum.Parse(typeof(T), name, true);
        }

        public static T Random()
        {
            if (!typeof(T).IsEnum) throw new ArgumentException("T must be an enumerated type");
            var list = Enum.GetValues(typeof(T)).Cast<T>().ToArray();
            return list[Randomizer.NextInt(list.Length)];
        }
    }
}
