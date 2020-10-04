using System;
using System.IO;
using System.Text;

namespace transmission_renamer.Classes.Rules
{
    public class InsertRule : IRenameRule
    {
        public string Name { get; } = "Insert";
        public string Description { get; }
        public string Id { get; } = Guid.NewGuid().ToString();

        public string InsertText { get; set; }
        public string BeforeTextStr { get; set; }
        public string AfterTextStr { get; set; }
        public bool Prefix { get; set; }
        public bool Suffix { get; set; }
        public bool Position { get; set; }
        public bool BeforeText { get; set; }
        public bool AfterText { get; set; }
        public bool ReplaceFileName { get; set; }
        public bool IgnoreExtension { get; set; }
        public bool PositionRightToLeft { get; set; }
        public int PositionIndex { get; set; }

        public InsertRule(string insertText, string beforeTextStr = "", string afterTextStr = "", bool prefix = true, bool suffix = false, bool position = false, bool positionRightToLeft = false, bool beforeText = false, bool afterText = false, bool replaceFileName = false, bool ignoreExtension = false, int positionIndex = -1)
        {
            InsertText = insertText;
            BeforeTextStr = beforeTextStr;
            AfterTextStr = afterTextStr;
            this.Prefix = prefix;
            this.Suffix = suffix;
            this.Position = position;
            this.PositionRightToLeft = positionRightToLeft;
            this.BeforeText = beforeText;
            this.AfterText = afterText;
            this.ReplaceFileName = replaceFileName;
            this.IgnoreExtension = ignoreExtension;
            this.PositionIndex = positionIndex;

            this.Description = GenerateDescription();
        }

        private string GenerateDescription()
        {
            StringBuilder descriptionSb = new StringBuilder($"Insert '{InsertText}'");
            if (Prefix)
            {
                descriptionSb.Append(" as Prefix ");
            }
            else if (Suffix)
            {
                descriptionSb.Append(" as Suffix ");
            }
            else if (Position && PositionIndex != -1)
            {
                if (PositionRightToLeft)
                {
                    descriptionSb.Append($" at Position {PositionIndex} from right-to-left ");
                }
                else
                {
                    descriptionSb.Append($" at Position {PositionIndex} ");
                }
            }

            else if (BeforeText && !string.IsNullOrEmpty(BeforeTextStr))
            {
                descriptionSb.Append($" Before Text '{BeforeTextStr}' ");
            }
            else if (AfterText && !string.IsNullOrEmpty(AfterTextStr))
            {
                descriptionSb.Append($" After Text '{AfterTextStr}' ");
            }
            else if (ReplaceFileName)
            {
                descriptionSb.Append(" replacing current filename");
            }

            if (IgnoreExtension)
            {
                descriptionSb.Append("(ignoring extension)");
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

                string oldNameStr = newNameSb.ToString();

                if (Prefix)
                {
                    newNameSb.Insert(0, InsertText);
                }
                else if (Suffix)
                {
                    newNameSb.Append(InsertText);
                }
                else if (Position && PositionIndex != -1)
                {
                    if (PositionRightToLeft)
                    {
                        newNameSb.Insert(newNameSb.Length - PositionIndex, InsertText);
                    }
                    else
                    {
                        newNameSb.Insert(PositionIndex, InsertText);
                    }
                }
                else if (BeforeText && !string.IsNullOrEmpty(BeforeTextStr))
                {
                    newNameSb.Insert(oldNameStr.IndexOf(BeforeTextStr), InsertText);
                }
                else if (AfterText && !string.IsNullOrEmpty(AfterTextStr))
                {
                    newNameSb.Insert(oldNameStr.IndexOf(AfterTextStr) + AfterTextStr.Length, InsertText);
                }
                else if (ReplaceFileName)
                {
                    newNameSb.Clear().Append(InsertText);
                }

                if (IgnoreExtension)
                {
                    newNameSb.Append(extension);
                }

                return newNameSb.ToString();
            }
            catch { return Path.GetFileName(torrentFileInfo.NewestName); }

        }
    }
}
