﻿using System;
using System.Collections.Generic;

namespace AutoParse
{
    public static class AutoParse
    {
        public delegate bool TryParser<T>(string str, out T value);
        public static T TryParse<T>(this string value, TryParser<T> parser)
        {
            T val;
            parser.Invoke(value, out val);
            return val;
        }

        public static T? TryParseNullable<T>(this string value, TryParser<T> parser)
            where T : struct
        {
            T val;
            return parser.Invoke(value, out val) ? val : null as T?;
        }

        public static T TryParse<T>(this string value)
        {
            var parser = GetParser<T>();
            return value.TryParse(parser);
        }

        public static T TryParse<T>(this string value, T defaultValue)
        {
            var parsedValue = value.TryParse<T>();
            return (EqualityComparer<T>.Default.Equals(parsedValue, default(T))) ? defaultValue : parsedValue;
        }

        public static T? TryParseNullable<T>(this string value)
            where T : struct
        {
            var parser = GetParser<T>();
            return value.TryParseNullable(parser);
        }

        private static TryParser<T> GetParser<T>()
        {
            return Delegate.CreateDelegate(typeof (TryParser<T>), typeof (T), "TryParse") as TryParser<T>;
        }
    }
}