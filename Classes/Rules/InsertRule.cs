using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace transmission_renamer.Classes.Rules
{
    public class InsertRule : RenameRule
    {
        private readonly string name = "Insert";
        private readonly string description;
        private readonly string id = Guid.NewGuid().ToString();
        private string insertText;
        private string beforeTextStr;
        private string afterTextStr;
        private bool prefix, suffix, position, beforeText, afterText, replaceFileName, ignoreExtension, positionRightToLeft;
        private int positionIndex;

        public string Description { get => description; }

        public string Name { get => name; }

        public string Id { get => id; }

        public InsertRule(string insertText, string beforeTextStr = "", string afterTextStr = "", bool prefix = true, bool suffix = false, bool position = false, bool positionRightToLeft = false, bool beforeText = false, bool afterText = false, bool replaceFileName = false, bool ignoreExtension = false, int positionIndex = -1)
        {
            this.insertText = insertText;
            this.beforeTextStr = beforeTextStr;
            this.afterTextStr = afterTextStr;
            this.prefix = prefix;
            this.suffix = suffix;
            this.position = position;
            this.positionRightToLeft = positionRightToLeft;
            this.beforeText = beforeText;
            this.afterText = afterText;
            this.replaceFileName = replaceFileName;
            this.ignoreExtension = ignoreExtension;
            this.positionIndex = positionIndex;

            this.description = GenerateDescription();
        }

        private string GenerateDescription()
        {
            StringBuilder descriptionSb = new StringBuilder($"Insert '{insertText}'");
            if (prefix)
                descriptionSb.Append(" as Prefix ");
            else if (suffix)
                descriptionSb.Append(" as Suffix ");
            else if (position && positionIndex != -1)
            {
                if (positionRightToLeft)
                    descriptionSb.Append($" at Position {positionIndex} from right-to-left ");
                else
                    descriptionSb.Append($" at Position {positionIndex} ");
            }

            else if (beforeText && !string.IsNullOrEmpty(beforeTextStr))
                descriptionSb.Append($" Before Text '{beforeTextStr}' ");
            else if (afterText && !string.IsNullOrEmpty(afterTextStr))
                descriptionSb.Append($" After Text '{afterTextStr}' ");
            else if (replaceFileName)
                descriptionSb.Append(" replacing current filename");

            if (ignoreExtension)
                descriptionSb.Append("(ignoring extension)");

            return descriptionSb.ToString();
        }

        public string DoRename(FriendlyTorrentFileInfo torrentFileInfo)
        {
            try
            {
                StringBuilder newNameSb;
                string extension = Path.GetExtension(torrentFileInfo.NewestName);
                if (ignoreExtension)
                    newNameSb = new StringBuilder(Path.GetFileNameWithoutExtension(torrentFileInfo.NewestName));
                else
                    newNameSb = new StringBuilder(torrentFileInfo.NewestName);

                string oldNameStr = newNameSb.ToString();

                if (prefix)
                    newNameSb.Insert(0, insertText);
                else if (suffix)
                    newNameSb.Append(insertText);
                else if (position && positionIndex != -1)
                {
                    if (positionRightToLeft)
                        newNameSb.Insert(newNameSb.Length - positionIndex, insertText);
                    else
                        newNameSb.Insert(positionIndex, insertText);
                }
                else if (beforeText && !string.IsNullOrEmpty(beforeTextStr))
                    newNameSb.Insert(oldNameStr.IndexOf(beforeTextStr), insertText);
                else if (afterText && !string.IsNullOrEmpty(afterTextStr))
                    newNameSb.Insert(oldNameStr.IndexOf(afterTextStr) + afterTextStr.Length, insertText);
                else if (replaceFileName)
                    newNameSb.Clear().Append(insertText);

                if (ignoreExtension)
                    newNameSb.Append(extension);

                return newNameSb.ToString();
            }
            catch { return torrentFileInfo.NewestName; }

        }
    }
}
