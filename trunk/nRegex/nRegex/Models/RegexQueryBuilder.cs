using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace nRegex.Models
{
    public class RegexQueryBuilder
    {
        public string Regex { get; set; }
        public string Target { get; set; }
        public bool IgnoreCase { get; set; }
        public bool SingleLine { get; set; }
        public bool MultiLine { get; set; }
        public bool ExplicitCapture { get; set; }
        public string ReplaceText { get; set; }

        public RegexOptions GetOptions()
        {
            RegexOptions options = RegexOptions.None;
            if (this.IgnoreCase)
            {
                options = options | RegexOptions.IgnoreCase;
            }
            if (this.SingleLine)
            {
                options = options | RegexOptions.Singleline;
            }
            if (this.ExplicitCapture)
            {
                options = options | RegexOptions.ExplicitCapture;
            }
            if (this.MultiLine) {
                options = options | RegexOptions.Multiline;
            }

            return options;
        }
    }
}