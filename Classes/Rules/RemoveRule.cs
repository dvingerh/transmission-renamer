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
        public string Name { get; } = "Remove";
        public string Description { get; }
        public string Id { get; } = Guid.NewGuid().ToString();
        public bool Enabled { get; set; } = true;

        public string RemoveText { get; set; }
        public bool AllOccurrences { get; set; }
        public bool FirstOccurrence { get; set; }
        public bool LastOccurrence { get; set; }
        public bool CaseSensitive { get; set; }
        public bool InterpretWildCards { get; set; }
        public bool IgnoreExtension { get; set; }

        public RemoveRule(string removeText, bool allOccurrences, bool firstOccurrence, bool lastOccurrence, bool caseSensitive, bool ignoreExtension)
        {
            this.RemoveText = removeText;
            this.AllOccurrences = allOccurrences;
            this.FirstOccurrence = firstOccurrence;
            this.LastOccurrence = lastOccurrence;
            this.CaseSensitive = caseSensitive;
            this.IgnoreExtension = ignoreExtension;

            this.Description = GenerateDescription();
        }

        private string GenerateDescription()
        {
            StringBuilder descriptionSb = new StringBuilder($"Remove");
            if (AllOccurrences)
            {
                descriptionSb.Append(" All occurrences of text ");
            }
            else if (FirstOccurrence)
            {
                descriptionSb.Append(" First occurrence of text ");
            }
            else
            {
                descriptionSb.Append(" Last occurrence of text ");
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

        public string DoRename(FriendlyTorrentFileInfo torrentFileInfo, int itemIndex = 0)
        {
            try
            {
                StringBuilder newNameSb;
                string extension = Path.GetExtension(torrentFileInfo.NewestName);
                if (IgnoreExtension)
                    newNameSb = new StringBuilder(Path.GetFileNameWithoutExtension(torrentFileInfo.NewestName));
                else
                    newNameSb = new StringBuilder(Path.GetFileName(torrentFileInfo.NewestName));

                string result;

                if (AllOccurrences)
                {
                    if (CaseSensitive)
                        newNameSb.Replace(RemoveText, "");
                    else
                    {
                        result = Regex.Replace(newNameSb.ToString(), Regex.Escape(RemoveText), "", RegexOptions.IgnoreCase);
                        newNameSb = new StringBuilder(result);
                    }
                }
                else if (FirstOccurrence)
                {
                    int index;
                    if (CaseSensitive)
                        index = newNameSb.ToString().IndexOf(RemoveText, StringComparison.InvariantCulture);
                    else
                        index = newNameSb.ToString().IndexOf(RemoveText, StringComparison.InvariantCultureIgnoreCase);
                    if (index != -1)
                        newNameSb = (index < 0) ? newNameSb : newNameSb.Remove(index, RemoveText.Length);
                }
                else if (LastOccurrence)
                {
                    int index;
                    if (CaseSensitive)
                        index = newNameSb.ToString().LastIndexOf(RemoveText, StringComparison.InvariantCulture);
                    else
                        index = newNameSb.ToString().LastIndexOf(RemoveText, StringComparison.InvariantCultureIgnoreCase);
                    if (index != -1)
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