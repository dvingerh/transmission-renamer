using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace transmission_renamer.Classes.Rules
{
    class RegexRule : IRenameRule
    {
        public string Name { get; } = "Regular Expressions";
        public string Description { get; }
        public string Id { get; } = Guid.NewGuid().ToString();
        public bool Enabled { get; set; } = true;

        public string RegexFindText { get; set; }
        public string ReplaceText { get; set; }
        public bool IgnoreExtension { get; set; }

        public RegexRule(string regexFindText, string replaceText, bool ignoreExtension)
        {
            this.RegexFindText = regexFindText;
            this.ReplaceText = replaceText;
            this.IgnoreExtension = ignoreExtension;

            this.Description = GenerateDescription();
        }

        private string GenerateDescription()
        {
            StringBuilder descriptionSb = new StringBuilder($"Match and replace Regular Expression ");

            descriptionSb.Append($"'{RegexFindText}' with text '{ReplaceText}' ");

            if (IgnoreExtension)
                descriptionSb.Append("(ignoring extension)");

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

                string result = Regex.Unescape(Regex.Replace(newNameSb.ToString(), RegexFindText, ReplaceText));
                newNameSb = new StringBuilder(result);

                if (IgnoreExtension)
                    newNameSb.Append(extension);

                return newNameSb.ToString();
            }
            catch { return Path.GetFileName(torrentFileInfo.NewestName); }
        }
    }
}
