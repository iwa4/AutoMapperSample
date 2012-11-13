using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMapperSample.Profiles
{
    internal class DateStringFormatterJP : BaseFormatter<DateTime?>
    {
        protected override string FormatValueCore(DateTime? dateTime)
        {
            return dateTime.HasValue ?
                dateTime.Value.ToString("yyyy年MM月dd日生まれ") : "未設定です";
        }
    }
}