using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflections
{

    public class ListItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public Type Type { get; set; }
        public ListItem(string text, object value, Type type)
        {
            this.Text = text;
            this.Value = value;
            this.Type = type;
        }
        public ListItem(string text, object value)
        {
            this.Text = text;
            this.Value = value;
        }
    }
    public static class GeneralReflections
    {
        public static PropertyInfo[] GetObjectsInfos(object obj, string[] inclue, string[] exclude)
        {
            var list = obj.GetType().GetProperties();

            PropertyInfo[] outputPropertyInfos = null;

            if (inclue != null)
            {
                return list.Where(propertyInfo => inclue.Contains(propertyInfo.Name)).ToArray();
            }
            if (exclude != null)
            {
                return list.Where(propertyInfo => !exclude.Contains(propertyInfo.Name)).ToArray();
            }
            return list;
        }

        public static List<ListItem> GetPropertiesDetailed(object obj, string[] include = null, string[] exclude = null)
        {
            var propertyInfos = GetObjectsInfos(obj, include, exclude);
            if (propertyInfos == null) throw new ArgumentNullException("propertyInfos is null");

            var collection = new List<ListItem>();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {


                string name = propertyInfo.Name;

                foreach (Attribute attribute in propertyInfo.GetCustomAttributes(true))
                {
                    DisplayNameAttribute displayAttribute = attribute as DisplayNameAttribute;

                    if (displayAttribute != null)
                    {
                        name = displayAttribute.DisplayName;
                        break;
                    }
                }


                object objvalue = propertyInfo.GetValue(obj);
                collection.Add(new ListItem(name, objvalue, (objvalue == null) ? typeof(object) : objvalue.GetType()));
            }
            return collection;
        }

        public static List<ListItem> GetEnums(object obj)
        {
            var enums = obj.GetType().GetEnumNames();

            var collection = new List<ListItem>();
            foreach (var @enum in enums)
            {
                string s = @enum;

            }
          
            return collection;
        }
    
    }
}
