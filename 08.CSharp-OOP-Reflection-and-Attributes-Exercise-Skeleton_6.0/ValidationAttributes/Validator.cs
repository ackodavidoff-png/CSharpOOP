using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                object value = propertyInfo.GetValue(obj);
                IEnumerable<MyValidationAttribute> attributes = propertyInfo.GetCustomAttributes().OfType<MyValidationAttribute>();
                foreach (var attribute in attributes)
                {
                    if(!attribute.IsValid(value))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
