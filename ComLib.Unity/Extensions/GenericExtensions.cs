﻿using System;
using System.IO;
using System.Xml.Serialization;

namespace ComLib.Unity.Extensions
{
    public static class GenericExtensions
    {
        private static System.Random rand = new System.Random((int)DateTime.Now.Ticks);

        /// <summary>
        /// Serialize the object into a string.
        /// </summary>
        public static string Serialize<T>(this T obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, obj);
                return textWriter.ToString();
            }
        }

        /// <summary>
        /// Deserializes string into object.
        /// </summary>
        public static T Deserialize<T>(this string data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(data))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Converts object into the specified type.
        /// </summary>
        public static T To<T>(this object arg)
        {
            if (arg == null)
            {
                throw new ArgumentNullException("arg");
            }

            return (T)Convert.ChangeType(arg, typeof(T), null);
        }

        /// <summary>
        /// Returns a random entry in an array
        /// </summary>
        /// <returns>Random entry in array</returns>
        public static T GetRandom<T>(this T[] val)
        {
            return val[rand.Next(val.Length)];
        }
    }
}
