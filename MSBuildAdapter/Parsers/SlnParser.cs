using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace MSBuildAdapter.Parsers
{
    public class SlnParser
    {
        private static readonly string SLN_REGEX_PROJECT = ", \\\".*\\.[cv][bs]proj";
        public IEnumerable<string> Parse(string slnFilePath)
        {
            var slnText = File.ReadAllText(slnFilePath);

            return Regex.Matches(slnText, SLN_REGEX_PROJECT).Cast<Match>()
                .Select(match => match.Value.Remove(0, 3));
        }
    }
}