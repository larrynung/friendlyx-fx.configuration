/* The MIT License (MIT)
*
* Copyright (c) 2014 FriendlyX
* Permission is hereby granted, free of charge, to any person obtaining a copy of
* this software and associated documentation files (the "Software"), to deal in
* the Software without restriction, including without limitation the rights to
* use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
* the Software, and to permit persons to whom the Software is furnished to do so,
* subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
* FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
* COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
* IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
* CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using FX.Configuration.Deserializers;

namespace FX.Configuration.Attributes
{
    /// <summary>
    /// A setting attribute to support enumerable values split by a delimiter.
    /// The default delimiter is ';' and the default type of items is typeof(string)
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EnumerableSettingAttribute : DeserializerAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerableSettingAttribute"/> class.
        /// </summary>
        public EnumerableSettingAttribute()
            : this(";")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerableSettingAttribute"/> class.
        /// </summary>
        /// <param name="delimiter">The delimiter</param>
        public EnumerableSettingAttribute(string delimiter)
            : this(delimiter, typeof(string))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerableSettingAttribute"/> class.
        /// </summary>
        /// <param name="typeOfItem">The type of item.</param>
        public EnumerableSettingAttribute(Type typeOfItem)
            : this(";", typeOfItem)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerableSettingAttribute" /> class.
        /// </summary>
        /// <param name="delimiter">The delimiter</param>
        /// <param name="typeOfItem">The type of item</param>
        public EnumerableSettingAttribute(string delimiter, Type typeOfItem)
            : base(null)
        {
            if (string.IsNullOrEmpty(delimiter))
            {
                throw new ArgumentNullException("delimiter");
            }

            if (typeOfItem == null)
            {
                throw new ArgumentNullException("typeOfItem");
            }

            this.Delimiter = delimiter;
            this.TypeOfItem = typeOfItem;
        }

        /// <summary>
        /// Gets the delimiter between items
        /// </summary>
        public string Delimiter { get; private set; }

        /// <summary>
        /// Gets the type of an item
        /// </summary>
        public Type TypeOfItem { get; private set; }

        /// <summary>
        /// Creates the setting deserializer
        /// </summary>
        /// <returns>A deserializer</returns>
        public override object CreateSettingDeserializer()
        {
            object deserializer;
            if (this.TypeOfItem == typeof(string))
            {
                deserializer = new EnumerableSettingDeserializer<string>(this.Delimiter);
            }
            else if (this.TypeOfItem == typeof(int))
            {
                deserializer = new EnumerableSettingDeserializer<int>(this.Delimiter);
            }
            else if (this.TypeOfItem == typeof(long))
            {
                deserializer = new EnumerableSettingDeserializer<long>(this.Delimiter);
            }
            else if (this.TypeOfItem == typeof(short))
            {
                deserializer = new EnumerableSettingDeserializer<short>(this.Delimiter);
            }
            else if (this.TypeOfItem == typeof(uint))
            {
                deserializer = new EnumerableSettingDeserializer<uint>(this.Delimiter);
            }
            else if (this.TypeOfItem == typeof(ulong))
            {
                deserializer = new EnumerableSettingDeserializer<ulong>(this.Delimiter);
            }
            else if (this.TypeOfItem == typeof(ushort))
            {
                deserializer = new EnumerableSettingDeserializer<ushort>(this.Delimiter);
            }
            else if (this.TypeOfItem == typeof(Guid))
            {
                deserializer = new EnumerableSettingDeserializer<Guid>(this.Delimiter);
            }
            else if (this.TypeOfItem == typeof(TimeSpan))
            {
                deserializer = new EnumerableSettingDeserializer<TimeSpan>(this.Delimiter);
            }
            else if (this.TypeOfItem == typeof(DateTime))
            {
                deserializer = new EnumerableSettingDeserializer<DateTime>(this.Delimiter);
            }
            else if (this.TypeOfItem == typeof(Uri))
            {
                deserializer = new EnumerableSettingDeserializer<Uri>(this.Delimiter);
            }
            else
            {
                throw new InvalidOperationException(string.Format("Unsupported type of items. Please implement custom enumerable setting attribute. Type of items: {0}", this.TypeOfItem));
            }

            return deserializer;
        }
    }
}