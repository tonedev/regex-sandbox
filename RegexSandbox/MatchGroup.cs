using System;
using System.Collections.Generic;
using System.Text;

namespace RegexSandbox
{
    public class MatchGroup
    {
        public MatchGroup(string groupName, string groupValue)
        {
            GroupName = groupName;
            GroupValue = groupValue;
        }

        public string GroupName { get; set; }
        public string GroupValue { get; set; }
    }
}
