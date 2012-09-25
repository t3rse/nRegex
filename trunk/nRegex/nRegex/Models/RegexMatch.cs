using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nRegex.Models
{
    public class RegexMatch
    {
        public List<RegexCaptureResult> GroupResults { get; set; }


        public RegexMatch()
        {
            GroupResults = new List<RegexCaptureResult>();
        }
    }
}