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
        private bool prefix, suffix, position, beforeText, afterText, replaceFileName, ignoreExtension, positionRightToLeft;

        public string Name { get; } = "Insert";

        public string Description { get; }

        public string Id { get; } = Guid.NewGuid().ToString();
        public string InsertText { get; set; }
        public string BeforeTextStr { get; set; }
        public string AfterTextStr { get; set; }
        public bool Prefix { get => prefix; set => prefix = value; }
        public bool Suffix { get => suffix; set => suffix = value; }
        public bool Position { get => position; set => position = value; }
        public bool BeforeText { get => beforeText; set => beforeText = value; }
        public bool AfterText { get => afterText; set => afterText = value; }
        public bool ReplaceFileName { get => replaceFileName; set => replaceFileName = value; }
        public bool IgnoreExtension { get => ignoreExtension; set => ignoreExtension = value; }
        public bool PositionRightToLeft { get => positionRightToLeft; set => positionRightToLeft = value; }
        public int PositionIndex { get; set; }

        public InsertRule(string insertText, string beforeTextStr = "", string afterTextStr = "", bool prefix = true, bool suffix = false, bool position = false, bool positionRightToLeft = false, bool beforeText = false, bool afterText = false, bool replaceFileName = false, bool ignoreExtension = false, int positionIndex = -1)
        {
            InsertText = insertText;
            BeforeTextStr = beforeTextStr;
            AfterTextStr = afterTextStr;
            this.prefix = prefix;
            this.suffix = suffix;
            this.position = position;
            this.positionRightToLeft = positionRightToLeft;
            this.beforeText = beforeText;
            this.afterText = afterText;
            this.replaceFileName = replaceFileName;
            this.ignoreExtension = ignoreExtension;
            this.PositionIndex = positionIndex;

            this.Description = GenerateDescription();
        }

        private string GenerateDescription()
        {
            StringBuilder descriptionSb = new StringBuilder($"Insert '{InsertText}'");
            if (prefix)
            {
                descriptionSb.Append(" as Prefix ");
            }
            else if (suffix)
            {
                descriptionSb.Append(" as Suffix ");
            }
            else if (position && PositionIndex != -1)
            {
                if (positionRightToLeft)
                {
                    descriptionSb.Append($" at Position {PositionIndex} from right-to-left ");
                }
                else
                {
                    descriptionSb.Append($" at Position {PositionIndex} ");
                }
            }

            else if (beforeText && !string.IsNullOrEmpty(BeforeTextStr))
            {
                descriptionSb.Append($" Before Text '{BeforeTextStr}' ");
            }
            else if (afterText && !string.IsNullOrEmpty(AfterTextStr))
            {
                descriptionSb.Append($" After Text '{AfterTextStr}' ");
            }
            else if (replaceFileName)
            {
                descriptionSb.Append(" replacing current filename");
            }

            if (ignoreExtension)
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
                newNameSb = ignoreExtension
                    ? new StringBuilder(Path.GetFileNameWithoutExtension(torrentFileInfo.NewestName))
                    : new StringBuilder(torrentFileInfo.NewestName);

                string oldNameStr = newNameSb.ToString();

                if (prefix)
                {
                    newNameSb.Insert(0, InsertText);
                }
                else if (suffix)
                {
                    newNameSb.Append(InsertText);
                }
                else if (position && PositionIndex != -1)
                {
                    if (positionRightToLeft)
                    {
                        newNameSb.Insert(newNameSb.Length - PositionIndex, InsertText);
                    }
                    else
                    {
                        newNameSb.Insert(PositionIndex, InsertText);
                    }
                }
                else if (beforeText && !string.IsNullOrEmpty(BeforeTextStr))
                {
                    newNameSb.Insert(oldNameStr.IndexOf(BeforeTextStr), InsertText);
                }
                else if (afterText && !string.IsNullOrEmpty(AfterTextStr))
                {
                    newNameSb.Insert(oldNameStr.IndexOf(AfterTextStr) + AfterTextStr.Length, InsertText);
                }
                else if (replaceFileName)
                {
                    newNameSb.Clear().Append(InsertText);
                }

                if (ignoreExtension)
                {
                    newNameSb.Append(extension);
                }

                return newNameSb.ToString();
            }
            catch { return torrentFileInfo.NewestName; }

        }
    }
}
