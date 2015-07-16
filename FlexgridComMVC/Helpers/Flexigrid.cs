using System.Linq;
using System.Collections.Generic;
using System;

namespace FlexgridComMVC.Helpers
{
    public class Flexigrid
    {
        public int page;
        public int total;
        public List<FlexigridLinha> rows = new List<FlexigridLinha>();
    }
    public class FlexigridLinha
    {
        public long id;
        public List<string> cell;
    }


}


namespace FlexgridComMVC
{
    public static class FlexiGridHelper
    {
        public static T GetPropValue<T>(this object component, string propertyName)
        {
            return (T)System.ComponentModel.TypeDescriptor.GetProperties(component)[propertyName].GetValue(component);
        }

                
        public static object GetPropertyValue(this object obj, string property)
        {
            System.Reflection.PropertyInfo propertyInfo = obj.GetType().GetProperty(property);
            return propertyInfo.GetValue(obj, null);
        }
    }
}
