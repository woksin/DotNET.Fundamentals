﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;

namespace Dolittle.Concepts
{
    /// <summary>
    /// Expresses a Concept as a another type, usually a primitive such as Guid, Int or String
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConceptAs<T> : IEquatable<ConceptAs<T>>, IComparable<ConceptAs<T>>, IComparable
    {
        /// <summary>
        /// The underlying primitive value of this concept
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// The underlying primitive type of this concept.
        /// </summary>
        public static Type UnderlyingType { get { return typeof(T); } }

#pragma warning disable 1591 // Xml Comments
        public override string ToString()
        {
            return Value == null ? default(T).ToString() : Value.ToString();
        }

        public static implicit operator T(ConceptAs<T> value)
        {
            return value == null ? default(T) : value.Value;
        }

        public override bool Equals(object obj)
        {
            if (obj is ConceptAs<T> typed)
            {
                return Equals(typed);
            }
            else
            {
                return false;
            }
        }

        public virtual bool Equals(ConceptAs<T> other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            var t = GetType();
            var otherType = other.GetType();

            return t == otherType && EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        public static bool operator ==(ConceptAs<T> a, ConceptAs<T> b)
        {
            if (ReferenceEquals(a,null) && ReferenceEquals(b,null))
                return true;

            if (ReferenceEquals(a,null) ^ ReferenceEquals(b,null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ConceptAs<T> a, ConceptAs<T> b)
        {
            return !(a == b);
        }

        public static bool operator > (ConceptAs<T> a, ConceptAs<T> b)
        {
            return a.CompareTo(b) == 1;
        }

        public static bool operator < (ConceptAs<T> a, ConceptAs<T> b)
        {
            return a.CompareTo(b) == -1;
        }

        public static bool operator >=(ConceptAs<T> a, ConceptAs<T> b)
        {
            return a.CompareTo(b) > -1;
        }

        public static bool operator <= (ConceptAs<T> a, ConceptAs<T> b)
        {
            return a.CompareTo(b) < 1;
        }
        
        public override int GetHashCode()
        {
            return HashCodeHelper.Generate(typeof (T), Value);
        }

        public bool IsEmpty()
        {
            if (!(Value != null))
                return true;

            var value = Value as string;

            if (value != null)
                return value == string.Empty;

            return Value.Equals(default(T));
        }

        public virtual int CompareTo(ConceptAs<T> other)
        {
            if(other == null)
                return 1;

            return Comparer<T>.Default.Compare(this.Value,other.Value);
        }

        public virtual int CompareTo(object obj)
        {
            var other = obj as ConceptAs<T>;
            return CompareTo(other);
        }
#pragma warning restore 1591 // Xml Comments
    }
}