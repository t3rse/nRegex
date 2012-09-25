using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nRegex.Models
{
    public class RegexResult
    {
        public string Regex { get; set; }
        public string Replacement { get; set; }
        public string ResultText { get; set; }
        public List<RegexMatch> Matches { get; set; }

        public RegexResult()
        {
            this.Matches = new List<RegexMatch>();
        }

        public RegexResult(RegexQueryBuilder baseQuery):this()
        {
            this.Regex = baseQuery.Regex;
            this.Replacement = baseQuery.ReplaceText;


        }

    }
}