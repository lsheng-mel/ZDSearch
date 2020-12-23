using System;
using System.Linq;
using System.Reflection;

namespace ZendeskSearch.Extensions
{
    public static class EnumExtensions
    {
        // get the "Description" attribute value of an Enum item
        public static string GetDescription(this Enum enumValue)
        {
            Type genericEnumType = enumValue.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(enumValue.ToString());

            if (memberInfo == null || memberInfo.Length <= 0)
            {
                return enumValue.ToString();
            }

            var attribs = memberInfo[0]
                .GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);

            if (attribs == null || !attribs.Any())
            {
                return enumValue.ToString();
            }

            return ((System.ComponentModel.DescriptionAttribute) attribs.ElementAt(0)).Description;
        }
    }
}