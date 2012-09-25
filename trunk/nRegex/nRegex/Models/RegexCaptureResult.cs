using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nRegex.Models
{
    public class RegexCaptureResult
    {
        public int Index { get; set; }
        public int Position { get; set; }
        public int MatchLength { get; set; }
        public string MatchText { get; set; }
        public string MatchGroupName { get; set; }
    }
}