using System;
using System.IO;
using System.Text;

namespace transmission_renamer.Classes.Rules
{
    public class DeleteRule : RenameRule
    {
        public string Name { get; } = "Delete";

        public string Description { get; }

        public string Id { get; } = Guid.NewGuid().ToString();

        public bool FromPosition { get; set; }
        public bool FromDelimiter { get; set; }
        public bool ToPosition { get; set; }
        public bool ToDelimiter { get; set; }
        public bool DeleteToEnd { get; set; }
        public bool DeleteEntireFileName { get; set; }
        public bool IgnoreExtension { get; set; }
        public bool RightToLeft { get; set; }
        public bool KeepDelimiters { get; set; }
        public int FromPositionIndex { get; set; }
        public int ToPositionIndex { get; set; }
        public string FromDelimiterStr { get; set; }
        public string ToDelimiterStr { get; set; }

        public DeleteRule(bool fromPosition, bool fromDelimiter, bool toPosition, bool toDelimiter, bool deleteToEnd, bool deleteEntireFileName, bool ignoreExtension, bool rightToLeft, bool keepDelimiters, int fromPositionIndex, int toPositionIndex, string fromDelimiterStr, string toDelimiterStr)
        {
            this.FromPosition = fromPosition;
            this.FromDelimiter = fromDelimiter;
            this.ToPosition = toPosition;
            this.ToDelimiter = toDelimiter;
            this.DeleteToEnd = deleteToEnd;
            this.DeleteEntireFileName = deleteEntireFileName;
            this.IgnoreExtension = ignoreExtension;
            this.RightToLeft = rightToLeft;
            this.KeepDelimiters = keepDelimiters;
            this.FromPositionIndex = fromPositionIndex;
            this.ToPositionIndex = toPositionIndex;
            this.FromDelimiterStr = fromDelimiterStr;
            this.ToDelimiterStr = toDelimiterStr;

            this.Description = GenerateDescription();
        }

        private string GenerateDescription()
        {
            StringBuilder descriptionSb = new StringBuilder($"Delete text from");
            if (DeleteEntireFileName)
            {
                descriptionSb.Append(" Start to End (delete entire filename)");
                return descriptionSb.ToString();
            }
            else
            {
                if (FromPosition && FromPositionIndex != -1)
                    descriptionSb.Append($" Position {FromPositionIndex}");
                else if (FromDelimiter)
                    descriptionSb.Append($" Delimiter '{FromDelimiterStr}'");
                if (ToPosition && ToPositionIndex != -1)
                    descriptionSb.Append($" to Position {ToPositionIndex} ");
                else if (ToDelimiter)
                    descriptionSb.Append($" to Delimiter '{ToDelimiterStr}' ");
                else if (DeleteToEnd)
                    descriptionSb.Append(" to End ");


                if (RightToLeft && KeepDelimiters && IgnoreExtension)
                    descriptionSb.Append("(from right-to-left, keeping delimiters, ignoring extension)");
                else if (RightToLeft || KeepDelimiters || IgnoreExtension)
                {
                    descriptionSb.Append("(");

                    if (RightToLeft)
                        descriptionSb.Append("from right-to-left");
                    if (KeepDelimiters)
                        if (RightToLeft)
                        {
                            descriptionSb.Append(", ");
                            descriptionSb.Append("keeping delimiters");
                        }
                    if (IgnoreExtension)
                        if (RightToLeft || KeepDelimiters)
                        {
                            descriptionSb.Append(", ");
                            descriptionSb.Append("ignoring extension");
                        }

                    descriptionSb.Append(")");
                }

                return descriptionSb.ToString();
            }
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
                    newNameSb = new StringBuilder(torrentFileInfo.NewestName);

                string oldNameStr = newNameSb.ToString();

                int fromDelimiterPos = 0;
                int toDelimiterPos = 0;

                if (FromDelimiter)
                    fromDelimiterPos = newNameSb.ToString().IndexOf(FromDelimiterStr);
                if (ToDelimiter)
                    toDelimiterPos = newNameSb.ToString().IndexOf(ToDelimiterStr);

                int fromIndex = FromPosition ? FromPositionIndex : fromDelimiterPos;
                int endIndex = ToPosition ? (ToPositionIndex - fromIndex) + 1 : (toDelimiterPos - fromIndex);
                newNameSb.Remove(fromIndex + (!KeepDelimiters ? 0 : FromDelimiterStr.Length), endIndex + (KeepDelimiters ? 0 : ToDelimiterStr.Length));


                if (IgnoreExtension)
                    newNameSb.Append(extension);

                return newNameSb.ToString();
            }
            catch { return torrentFileInfo.NewestName; }

        }
    }
}