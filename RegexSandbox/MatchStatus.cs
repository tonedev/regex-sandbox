using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public enum MatchStatus
{
    [Description("Match")]
    Match,

    [Description("No Match")]
    NoMatch,

    [Description("Invalid Regex")]
    InvalidRegex
}