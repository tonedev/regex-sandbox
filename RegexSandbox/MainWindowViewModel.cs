using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Media;

namespace RegexSandbox
{
    public class MainWindowViewModel : NotificationObject
    {
        const string SampleInput = "Oliver Twist-Dickens,Charles";
        const string SamplePattern = "^(?<title>.*)-(?<lastName>.*),(?<firstName>.*)$";

        public MainWindowViewModel()
        {
            CheckMatches();
        }

        private string input = SampleInput;
        public string Input
        {
            get { return input; }
            set
            {
                if (input != value)
                {
                    input = value;
                    OnPropertyChanged();

                    CheckMatches();
                }
            }
        }

        private string pattern = SamplePattern;
        public string Pattern
        {
            get { return pattern; }
            set
            {
                if (pattern != value)
                {
                    pattern = value;
                    OnPropertyChanged();

                    CheckMatches();
                }
            }
        }

        private MatchStatus status = MatchStatus.NoMatch;
        public MatchStatus Status
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(StatusDisplayValue));
                    OnPropertyChanged(nameof(StatusColor));
                }
            }
        }

        public string StatusDisplayValue
        {
            get { return Status.GetDescription(); }
        }

        public Brush StatusColor
        {
            get
            {
                switch (Status)
                {
                    case MatchStatus.Match:
                        return Brushes.Green;
                    case MatchStatus.InvalidRegex:
                        return Brushes.Red;
                    case MatchStatus.NoMatch:
                    default:
                        return Brushes.Black;
                }
            }
        }

        private string matchedText;
        public string MatchedText
        {
            get { return matchedText; }
            set
            {
                if (matchedText != value)
                {
                    matchedText = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<MatchGroup> groups = new ObservableCollection<MatchGroup>();
        public ObservableCollection<MatchGroup> Groups
        {
            get { return groups; }
            set
            {
                if (groups != value)
                {
                    groups = value;
                    OnPropertyChanged();
                }
            }
        }

        private void CheckMatches()
        {
            Groups.Clear();

            Regex regex;

            try
            {
                regex = new Regex(Pattern, RegexOptions.IgnoreCase);
            }
            catch (ArgumentException)
            {
                MatchedText = string.Empty;
                Status = MatchStatus.InvalidRegex;
                return;
            }

            Match match = regex.Match(Input);
            Status = match.Success ? MatchStatus.Match : MatchStatus.NoMatch;
            MatchedText = match.ToString();

            string[] groupNames = regex.GetGroupNames();
            foreach (string name in groupNames)
            {
                Groups.Add(new MatchGroup(name, match.Groups[name].Value));
            }
        }
    }
}
