using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMapperSample.Profiles
{
    public abstract class BaseFormatter<T> : IValueFormatter
    {
        public string FormatValue(ResolutionContext context)
        {
            if (context.SourceValue == null)
                return null;

            if (!(context.SourceValue is T))
                return context.SourceValue ==
                                     null ? String.Empty : context.SourceValue.ToString();

            return FormatValueCore((T)context.SourceValue);
        }

        protected abstract string FormatValueCore(T value);
    }
}