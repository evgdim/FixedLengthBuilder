using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FixedLength
{
    public class FixedLengthParser<T>
    {
        private const string DEFAULT_DATE_FORMAT = "yyyyMMdd";
        private T instance;
        private string src;
        private FixedLengthParser(T target, string src)
        {
            this.instance = target;
            this.src = src;
        }

        public static FixedLengthParser<T> New(T target, string src)
        {
            return new FixedLengthParser<T>(target, src);
        }
        public T Get()
        {
            return instance;
        }
        public FixedLengthParser<T> SetString<U>(Expression<Func<T, U>> expression,int start, int length)
        {
            string value = src.Substring(start, length);
            var member = expression.Body as MemberExpression;
            if (member != null && member.Member is PropertyInfo)
                (member.Member as PropertyInfo).SetValue(instance,value);
            return this;
        }
        public FixedLengthParser<T> SetStringTrim(Expression<Func<T, String>> expression, int start, int length)
        {
            string value = src.Substring(start, length).Trim();
            var member = expression.Body as MemberExpression;
            if (member != null && member.Member is PropertyInfo)
                (member.Member as PropertyInfo).SetValue(instance, value);
            return this;
        }
        public FixedLengthParser<T> SetDecimal(Expression<Func<T, Decimal>> expression, int start, int length)
        {
            string strValue = src.Substring(start, length);
            decimal value = Convert.ToDecimal(strValue);
            var member = expression.Body as MemberExpression;
            if (member != null && member.Member is PropertyInfo)
                (member.Member as PropertyInfo).SetValue(instance, value);
            return this;
        }
        public FixedLengthParser<T> SetDateTime(Expression<Func<T, DateTime>> expression, int start, int length)
        {
            string strValue = src.Substring(start, length).Trim();
            DateTime value = DateTime.ParseExact(strValue, DEFAULT_DATE_FORMAT, null);
            var member = expression.Body as MemberExpression;
            if (member != null && member.Member is PropertyInfo)
                (member.Member as PropertyInfo).SetValue(instance, value);
            return this;
        }
    }
}
