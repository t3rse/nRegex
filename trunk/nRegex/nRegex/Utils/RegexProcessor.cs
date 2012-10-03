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

            result.MatchSortedList = sl;
            return result;

        }
    }
}