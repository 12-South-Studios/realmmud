﻿using System;

namespace Realm.DAL.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class ColorAttribute : Attribute
    {
        public ColorAttribute(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
