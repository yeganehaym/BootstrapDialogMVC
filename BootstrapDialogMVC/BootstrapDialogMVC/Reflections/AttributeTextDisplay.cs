using System;
using System.Reflection;


namespace Reflections
{
    public class EnumDescription : Attribute
    {
        public string Text;
        public EnumDescription(string text)
        {
            Text = text;
        }
    }
    public static class AttributeTextDisplay
    {
        public static string GetDisplayText(this Enum enu)
        {
            Type type = enu.GetType();

            MemberInfo[] memInfo = type.GetMember(enu.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {

                object[] attrs = memInfo[0].GetCustomAttributes(typeof(EnumDescription), false);

                if (attrs != null && attrs.Length > 0)
                    return ((EnumDescription)attrs[0]).Text;
            }

            return enu.ToString();
        }

        public static string GetDisplayText(this PropertyInfo pInfo)
        {
            Type type = pInfo.GetType();

            MemberInfo[] memInfo = type.GetMember(pInfo.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {

                object[] attrs = memInfo[0].GetCustomAttributes(typeof(EnumDescription), false);

                if (attrs != null && attrs.Length > 0)
                    return ((EnumDescription)attrs[0]).Text;
            }

            return pInfo.ToString();
        }

    }




}