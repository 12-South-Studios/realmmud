﻿using System;

// ReSharper disable CheckNamespace
namespace Realm.Library.Common
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class RangeAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public int Minimum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Maximum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RangeAttribute()
        {
            Minimum = Int32.MinValue;
            Maximum = Int32.MaxValue;
        }
    }
}
