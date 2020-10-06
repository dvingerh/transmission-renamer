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
        public bool NumberSequence { get; set; }
        public bool PositionRightToLeft { get; set; }
        public int NumberSequenceStart { get; set; }
        public int NumberSequenceLeadingZeroes { get; set; }
        public int PositionIndex { get; set; }

        public InsertRule(string insertText, bool numberSequence, int numberSequenceStart, int numberSequenceLeadingZeroes, string beforeTextStr = "", string afterTextStr = "", bool prefix = true, bool suffix = false, bool position = false, bool positionRightToLeft = false, bool beforeText = false, bool afterText = false, bool replaceFileName = false, bool ignoreExtension = false, int positionIndex = -1)
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
            this.NumberSequence = numberSequence;
            this.NumberSequenceStart = numberSequenceStart;
            this.NumberSequenceLeadingZeroes = numberSequenceLeadingZeroes;

            this.Description = GenerateDescription();
        }

        private string GenerateDescription()
        {
            StringBuilder descriptionSb;
            if (!NumberSequence)
                descriptionSb = new StringBuilder($"Insert text '{InsertText}'");
            else
                descriptionSb = new StringBuilder($"Insert number sequence starting at '{NumberSequenceStart}' with {NumberSequenceLeadingZeroes} leading zeroes");
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

                string oldNameStr = newNameSb.ToString();

                string insertNumber = (itemIndex + NumberSequenceStart).ToString($"D{NumberSequenceLeadingZeroes + 1}");

                if (Prefix)
                {
                    newNameSb.Insert(0, NumberSequence ? insertNumber : InsertText);
                }
                else if (Suffix)
                {
                    newNameSb.Append(NumberSequence ? insertNumber : InsertText);
                }
                else if (Position && PositionIndex != -1)
                {
                    if (PositionRightToLeft)
                    {
                        newNameSb.Insert(newNameSb.Length - PositionIndex, NumberSequence ? insertNumber : InsertText);
                    }
                    else
                    {
                        newNameSb.Insert(PositionIndex, NumberSequence ? insertNumber : InsertText);
                    }
                }
                else if (BeforeText && !string.IsNullOrEmpty(BeforeTextStr))
                {
                    newNameSb.Insert(oldNameStr.IndexOf(BeforeTextStr), NumberSequence ? insertNumber : InsertText);
                }
                else if (AfterText && !string.IsNullOrEmpty(AfterTextStr))
                {
                    newNameSb.Insert(oldNameStr.IndexOf(AfterTextStr) + AfterTextStr.Length, NumberSequence ? insertNumber : InsertText);
                }
                else if (ReplaceFileName)
                {
                    newNameSb.Clear().Append(NumberSequence ? insertNumber : InsertText);
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
