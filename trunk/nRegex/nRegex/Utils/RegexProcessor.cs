using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace nRegex.Utils
{
    public class RegexProcessor
    {
        public static object Evaluate(string target, string test, RegexOptions options)
        {
            return Regex.Match(target, test);
        
        }
    }
}