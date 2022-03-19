using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProHub.Local
{
    public class LocalService
    {
        private readonly IStringLocalizer _localizer;

        public LocalService(IStringLocalizerFactory factory)
        {
            var type = typeof(GlobalResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("GlobalResource", assemblyName.Name);
        }

        public LocalizedString L(string key)
        {
            return _localizer[key];
        }

        public LocalizedString LP(string key, string parameter)
        {
            return _localizer[key, parameter];
        }
    }
}
