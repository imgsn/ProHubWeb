using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ProHub.Core.Extensions
{

    public static class TempDataExtensions
    {
        public static void Put<T>(this TempDataDictionary tempData, T value) where T : class
        {
            tempData[typeof(T).FullName] = value;
        }

        public static void Put<T>(this TempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[typeof(T).FullName + key] = value;
        }

        public static T Get<T>(this TempDataDictionary tempData) where T : class
        {
            object o;
            tempData.TryGetValue(typeof(T).FullName, out o);
            return (T)o;
        }

        public static T Get<T>(this TempDataDictionary tempData, string key) where T : class
        {
            object o;
            tempData.TryGetValue(typeof(T).FullName + key, out o);
            return (T)o;
        }
    }
}



//var customer = new Customer();
//TempData.Put(customer); // Strongly typed without key
//TempData.Put("key1", customer); // Strongly typed with extra key
//var tempDataCustomer = TempData.Get<Customer>(); // Get customer without key
//v