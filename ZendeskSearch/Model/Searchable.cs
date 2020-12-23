using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ZendeskSearch.Model
{
    public abstract class Searchable
    {
        public virtual bool IsMatched(Type type, string field, string searchValue)
        {
            if (GetType() != type)
            {
                return false;
            }
            
            var property = GetType()
                .GetProperty(field, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

            if (property == null)
            {
                return false;
            }

            if (property.PropertyType == typeof(IEnumerable<string>))
            {
                var propVal = property.GetValue(this);
                if (propVal == null)
                {
                    return false;
                }
                
                var value = (IEnumerable<string>)(propVal);
                return value.Any(v => v.Equals(searchValue, StringComparison.InvariantCultureIgnoreCase));
            }

            if (property.PropertyType == typeof(DateTime))
            {
                DateTime inputDateTime;
                if (!DateTime.TryParse(searchValue, out inputDateTime))
                {
                    return false;
                }

                return inputDateTime == (DateTime)property.GetValue(this);
            }
            
            return property.GetValue(this)?.ToString()
                ?.Equals(searchValue, StringComparison.InvariantCultureIgnoreCase) ?? false;
        }
    }
}