﻿using System;
using System.ComponentModel;
using System.Resources;

namespace ProHub.Core.Attributes
{
    public class LocalEnum : DescriptionAttribute
    {
        private readonly string _resourceKey;
        private readonly ResourceManager _resource;

        public LocalEnum(string resourceKey, Type resourceType)
        {
            _resource = new ResourceManager(resourceType);
            _resourceKey = resourceKey;
        }

        public override string Description
        {
            get
            {
                string displayName = _resource.GetString(_resourceKey);
                return string.IsNullOrEmpty(displayName)
                    ? $"[[{_resourceKey}]]"
                    : displayName;
            }
        }
    }
}