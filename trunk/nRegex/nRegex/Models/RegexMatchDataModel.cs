using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace nRegex.Models
{
    public class RegexMatchDataModel
    {
        public string OriginalTarget { get; set; }
        public SortedList MatchSortedList{ get; set; }
        public List<RegexMatch> Matches { get; set; }
    }
}