using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace transmission_renamer.Classes.Rules
{
    class RemoveRule : IRenameRule
    {
        public string Name { get; } = "Rename";
        public string Description { get; }
        public string Id { get; } = Guid.NewGuid().ToString();

        public string RemoveText { get; set; }
        public bool AllOccurrences { get; set; }
        public bool FirstOccurrence { get; set; }
        public bool LastOccurrence { get; set; }
        public bool CaseSensitive { get; set; }
        public bool InterpretWildCards { get; set; }
        public bool IgnoreExtension { get; set; }

        public RemoveRule(string removeText, bool allOccurrences, bool firstOccurrence, bool lastOccurrence, bool caseSensitive, bool interpretWildCards, bool ignoreExtension)
        {
            this.RemoveText = removeText;
            this.AllOccurrences = allOccurrences;
            this.FirstOccurrence = firstOccurrence;
            this.LastOccurrence = lastOccurrence;
            this.CaseSensitive = caseSensitive;
            this.InterpretWildCards = interpretWildCards;
            this.IgnoreExtension = ignoreExtension;

            this.Description = GenerateDescription();
        }

        private string GenerateDescription()
        {
            StringBuilder descriptionSb = new StringBuilder($"Remove");
            if (AllOccurrences)
            {
                descriptionSb.Append(" All occurrences of string ");
            }
            else if (FirstOccurrence)
            {
                descriptionSb.Append(" First occurrence of string ");
            }
            else
            {
                descriptionSb.Append(" Last occurrence of string ");
            }

            descriptionSb.Append($"'{RemoveText}' ");

            if (CaseSensitive && IgnoreExtension && InterpretWildCards)
                descriptionSb.Append("(case sensitive, ignoring extension, interpreting wildcards)");
            else if (CaseSensitive || IgnoreExtension || InterpretWildCards)
            {
                descriptionSb.Append("(");

                if (CaseSensitive)
                {
                    descriptionSb.Append("case sensitive");
                }
                if (IgnoreExtension)
                {
                    if (CaseSensitive)
                        descriptionSb.Append(", ");
                    descriptionSb.Append("ignoring extension");
                }
                if (InterpretWildCards)
                {
                    if (CaseSensitive || IgnoreExtension)
                        descriptionSb.Append(", ");
                    descriptionSb.Append("interpreting wildcards");
                }
                descriptionSb.Append(")");
            }

            return descriptionSb.ToString();
        }

        public string DoRename(FriendlyTorrentFileInfo torrentFileInfo)
        {
            try
            {
                StringBuilder newNameSb;
                string extension = Path.GetExtension(torrentFileInfo.NewestName);
                if (IgnoreExtension)
                    newNameSb = new StringBuilder(Path.GetFileNameWithoutExtension(torrentFileInfo.NewestName));
                else
                    newNameSb = new StringBuilder(Path.GetFileName(torrentFileInfo.NewestName));

                if (AllOccurrences)
                {
                    string result;
                    Wildcard wildcard;
                    if (InterpretWildCards)
                    {
                        int lastIndex = newNameSb.ToString().LastIndexOf(RemoveText, StringComparison.Ordinal);
                        if (CaseSensitive)
                            wildcard = new Wildcard(RemoveText);
                        else
                            wildcard = new Wildcard(RemoveText, RegexOptions.IgnoreCase);

                        result = wildcard.Replace(Regex.Escape(newNameSb.ToString()), "", FirstOccurrence ? 1 : 1000, LastOccurrence ? lastIndex : 0);
                        newNameSb = new StringBuilder(result);
                    }
                    else
                    {
                        if (CaseSensitive)
                            result = Regex.Replace(newNameSb.ToString(), Regex.Escape(RemoveText), "");
                        else
                            result = Regex.Replace(newNameSb.ToString(), Regex.Escape(RemoveText), "", RegexOptions.IgnoreCase);
                        newNameSb = new StringBuilder(result);
                    }
                }
                else if (FirstOccurrence)
                {
                    int index = newNameSb.ToString().IndexOf(RemoveText, StringComparison.Ordinal);
                    newNameSb = (index < 0) ? newNameSb : newNameSb.Remove(index, RemoveText.Length);
                }
                else if (LastOccurrence)
                {
                    int index = newNameSb.ToString().LastIndexOf(RemoveText, StringComparison.Ordinal);
                    newNameSb = (index < 0) ? newNameSb : newNameSb.Remove(index, RemoveText.Length);
                }


                if (IgnoreExtension)
                    newNameSb.Append(extension);

                return newNameSb.ToString();
            }
            catch { return Path.GetFileName(torrentFileInfo.NewestName); }
        }
    }
}
