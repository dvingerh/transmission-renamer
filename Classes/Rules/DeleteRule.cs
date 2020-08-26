using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace transmission_renamer.Classes.Rules
{
    public class DeleteRule: RenameRule
    {
        private readonly string name = "Delete";
        private readonly string description;
        private readonly string id = Guid.NewGuid().ToString();

        private bool fromPosition, fromDelimiter, toPosition, toDelimiter, deleteToEnd, ignoreExtension, deleteEntireFileName, keepDelimiters;
        private int fromPositionIndex, toPositionIndex;
        private string fromDelimiterStr, toDelimiterStr;

        public string Name => name;

        public string Description => description;

        public string Id => id;

        public bool FromPosition { get => fromPosition; set => fromPosition = value; }
        public bool FromDelimiter { get => fromDelimiter; set => fromDelimiter = value; }
        public bool ToPosition { get => toPosition; set => toPosition = value; }
        public bool ToDelimiter { get => toDelimiter; set => toDelimiter = value; }
        public bool DeleteToEnd { get => deleteToEnd; set => deleteToEnd = value; }
        public bool DeleteEntireFileName { get => deleteEntireFileName; set => deleteEntireFileName = value; }
        public bool IgnoreExtension { get => ignoreExtension; set => ignoreExtension = value; }
        public bool KeepDelimiters { get => keepDelimiters; set => keepDelimiters = value; }
        public int FromPositionIndex { get => fromPositionIndex; set => fromPositionIndex = value; }
        public int ToPositionIndex { get => toPositionIndex; set => toPositionIndex = value; }
        public string FromDelimiterStr { get => fromDelimiterStr; set => fromDelimiterStr = value; }
        public string ToDelimiterStr { get => toDelimiterStr; set => toDelimiterStr = value; }

        public DeleteRule(bool fromPosition, bool fromDelimiter, bool toPosition, bool toDelimiter, bool deleteToEnd, bool deleteEntireFileName, bool ignoreExtension, bool keepDelimiters, int fromPositionIndex, int toPositionIndex, string fromDelimiterStr, string toDelimiterStr)
        {
            this.fromPosition = fromPosition;
            this.fromDelimiter = fromDelimiter;
            this.toPosition = toPosition;
            this.toDelimiter = toDelimiter;
            this.deleteToEnd = deleteToEnd;
            this.deleteEntireFileName = deleteEntireFileName;
            this.ignoreExtension = ignoreExtension;
            this.keepDelimiters = keepDelimiters;
            this.fromPositionIndex = fromPositionIndex;
            this.toPositionIndex = toPositionIndex;
            this.fromDelimiterStr = fromDelimiterStr;
            this.toDelimiterStr = toDelimiterStr;

            this.description = GenerateDescription();
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
                else if (fromDelimiter)
                    descriptionSb.Append($" Delimiter '{FromDelimiterStr}'");
                if (ToPosition && ToPositionIndex != -1)
                    descriptionSb.Append($" to Position {ToPositionIndex} ");
                else if (ToDelimiter)
                    descriptionSb.Append($" to Delimiter '{ToDelimiterStr}' ");
                else if (DeleteToEnd)
                    descriptionSb.Append(" to End ");


                if (KeepDelimiters && IgnoreExtension)
                    descriptionSb.Append("(keeping delimiters, ignoring extension)");
                else if (KeepDelimiters || IgnoreExtension)
                {
                    descriptionSb.Append("(");

                    if (KeepDelimiters)
                    {
                        descriptionSb.Append("keeping delimiters");
                    }
                    if (IgnoreExtension)
                    {
                        if (KeepDelimiters)
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
                if (ignoreExtension)
                    newNameSb = new StringBuilder(Path.GetFileNameWithoutExtension(torrentFileInfo.NewestName));
                else
                    newNameSb = new StringBuilder(torrentFileInfo.NewestName);

                string oldNameStr = newNameSb.ToString();

                if (DeleteEntireFileName)
                {
                    newNameSb.Clear();
                    if (ignoreExtension)
                        newNameSb.Append(extension);

                    return newNameSb.ToString();
                }

                int fromDelimiterPos = 0;
                int toDelimiterPos = 0;
                if (fromDelimiter)
                    fromDelimiterPos = newNameSb.ToString().IndexOf(fromDelimiterStr);
                if (toDelimiter)
                    toDelimiterPos = newNameSb.ToString().IndexOf(toDelimiterStr);

                int removeStartIndex = FromPosition ? fromPositionIndex : fromDelimiterPos + (!keepDelimiters ? 0 : fromDelimiterStr.Length);
                int removeLength = ToPosition ? (toPositionIndex - removeStartIndex) + 1 : (toDelimiterPos + toDelimiterStr.Length) - removeStartIndex - (!keepDelimiters ? 0 : toDelimiterStr.Length);

                if (DeleteToEnd)
                    removeLength = newNameSb.Length - removeStartIndex;

                newNameSb.Remove(removeStartIndex, removeLength);

                if (ignoreExtension)
                    newNameSb.Append(extension);

                return newNameSb.ToString();
            }
            catch { return torrentFileInfo.NewestName; }

        }
    }
}