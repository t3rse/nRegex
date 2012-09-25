using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using nRegex.Models;
using System.Collections;

namespace nRegex.Utils
{
    public class RegexProcessor
    {
        public static RegexResult Evaluate(RegexQueryBuilder regexQuery)
        {
            RegexResult result = new RegexResult(regexQuery);

            Regex expression = new Regex(regexQuery.Regex, regexQuery.GetOptions());

            result.Regex = regexQuery.Regex;
            result.Replacement = regexQuery.ReplaceText;

            int searchPos = 0;

            List<string> groupNames = expression.GetGroupNames().ToList();
            Match m = expression.Match(regexQuery.Target, searchPos);

            SortedList sl = new SortedList();
            string groupData = String.Empty;
            int groupCount = 0;
            while (m.Success)
            {
                RegexMatch matchResult = new RegexMatch();
                groupNames.ForEach(groupName => {
                    var groupMatch = m.Groups[groupName];
                    foreach (Capture cap in groupMatch.Captures) {
                        RegexCaptureResult groupResult = new RegexCaptureResult()
                        {
                            Index = cap.Index,
                            MatchText = cap.Value,
                            MatchLength = cap.Length
                        };
                        matchResult.GroupResults.Add(groupResult);
                    }
                });

                result.Matches.Add(matchResult);
                sl.Add(m.Index, m.Value);                
                m = m.NextMatch();

            }

            // TODO: old code, refactor for new nRegex

            // go backwards through the string inserting spans and what have you
            // rather than tracking a shifting position... 
            string target = regexQuery.Target;
            for (int i = sl.Count - 1; i > -1; i--)
            {
                int startPos = (int)sl.GetKey(i);
                int matchLength = sl[sl.GetKey(i)].ToString().Length;
                // use _xyZZZ_ for < and _ZZZyx_ for >. gosh-aweful, but it will work to 
                // do a replace later while still encoding this as html for display:
                target = target.Insert(startPos + matchLength, "_xyZZZ_/a_ZZZyx_");
                target = target.Insert(startPos, "_xyZZZ_a id='m" + startPos + "' name='m" + startPos + "'  class='match'_ZZZyx_");
            }

            return result;

        }
    }
}