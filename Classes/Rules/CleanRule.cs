using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace transmission_renamer.Classes.Rules
{
    class CleanRule : IRenameRule
    {
        public string Name { get; } = "Clean";
        public string Description { get; }
        public string Id { get; } = Guid.NewGuid().ToString();

        public bool CleanLatinAlphabet { get; set; }
        public bool CleanDigits { get; set; }
        public bool CleanBrackets { get; set; }
        public bool CleanSymbols { get; set; }
        public bool CleanUserDefined { get; set; }
        public string CleanUserDefinedText { get; set; }
        public bool CaseSensitive { get; set; }
        public bool IgnoreExtension { get; set; }

        private readonly string LatinAlphabet = "abcdefghijklmnopqrstuvwxyz";
        private readonly string LatinAlphabetUpper = "ABCDEFGHIJKLMNOPQURSTUVWXYZ";

        private readonly string Digits = "1234567890";
        private readonly string Brackets = "()[]{}";
        private readonly string Symbols = "!?@#$%^&*_+-=.,";


        public CleanRule(bool cleanLatinAlphabet, bool cleanDigits, bool cleanBrackets, bool cleanSymbols, bool cleanUserDefined, string cleanUserDefinedText, bool caseSensitive, bool ignoreExtension)
        {
            CleanLatinAlphabet = cleanLatinAlphabet;
            CleanDigits = cleanDigits;
            CleanBrackets = cleanBrackets;
            CleanSymbols = cleanSymbols;
            CleanUserDefined = cleanUserDefined;
            CleanUserDefinedText = cleanUserDefinedText;
            CaseSensitive = caseSensitive;
            IgnoreExtension = ignoreExtension;

            this.Description = GenerateDescription();
        }

        private string GenerateDescription()
        {
            StringBuilder descriptionSb = new StringBuilder($"Clean characters ");

            if (CleanLatinAlphabet && CleanDigits && CleanBrackets && CleanSymbols && CleanUserDefined)
                descriptionSb.Append($" Latin Alpbahet, Digits, Brackets, Symbols, '{CleanUserDefinedText}' ");
            else if (CleanLatinAlphabet || CleanDigits || CleanBrackets || CleanSymbols || CleanUserDefined)
            {
                if (CleanLatinAlphabet)
                {
                    descriptionSb.Append("Latin Alphabet");
                }
                if (CleanDigits)
                {
                    if (CleanLatinAlphabet)
                        descriptionSb.Append(", ");
                    descriptionSb.Append("Digits");
                }
                if (CleanBrackets)
                {
                    if (CleanDigits || CleanLatinAlphabet)
                        descriptionSb.Append(", ");
                    descriptionSb.Append("Brackets");
                }
                if (CleanSymbols)
                {
                    if (CleanDigits || CleanLatinAlphabet || CleanBrackets)
                        descriptionSb.Append(", ");
                    descriptionSb.Append("Symbols");
                }
                if (CleanUserDefined)
                {
                    if (CleanDigits || CleanLatinAlphabet || CleanBrackets || CleanSymbols)
                        descriptionSb.Append(", ");
                    descriptionSb.Append($"'{CleanUserDefinedText}'");
                }
            }

            if (CaseSensitive && IgnoreExtension)
                descriptionSb.Append(" (case sensitive, ignoring extension)");
            else if (CaseSensitive || IgnoreExtension)
            {
                descriptionSb.Append(" (");

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

                if (CleanLatinAlphabet)
                {
                    if (CaseSensitive)
                        for (int i = 0; i < newNameSb.Length - 1; i++)
                        {
                            if (LatinAlphabet.Contains(newNameSb[i]))
                            {
                                foreach (char c in LatinAlphabet)
                                    newNameSb.Replace(c.ToString(), "");
                            }
                        }
                    else
                    {
                        for (int i = 0; i < newNameSb.Length - 1; i++)
                        {
                            if (LatinAlphabet.Contains(newNameSb[i].ToString().ToLower()))
                            {
                                foreach (char c in LatinAlphabet)
                                    newNameSb.Replace(c.ToString(), "");
                                foreach (char c in LatinAlphabetUpper)
                                    newNameSb.Replace(c.ToString(), "");
                            }
                        }
                    }
                }
                if (CleanDigits)
                {
                    for (int i = 0; i < newNameSb.Length - 1; i++)
                    {
                        if (Digits.Contains(newNameSb[i]))
                        {
                            foreach (char c in Digits)
                                newNameSb.Replace(c.ToString(), "");
                        }
                    }
                }
                if (CleanBrackets)
                {
                    for (int i = 0; i < newNameSb.Length - 1; i++)
                    {
                        if (Brackets.Contains(newNameSb[i]))
                        {
                            foreach (char c in Brackets)
                                newNameSb.Replace(c.ToString(), "");
                        }
                    }
                }
                if (CleanSymbols)
                {
                    for (int i = 0; i < newNameSb.Length - 1; i++)
                    {
                        if (Symbols.Contains(newNameSb[i]))
                        {
                            foreach (char c in Symbols)
                                newNameSb.Replace(c.ToString(), "");
                        }
                    }
                }
                if (CleanUserDefined)
                {
                    if (CaseSensitive)
                        for (int i = 0; i < newNameSb.Length - 1; i++)
                        {
                            if (CleanUserDefinedText.Contains(newNameSb[i]))
                            {
                                foreach (char c in CleanUserDefinedText)
                                    newNameSb.Replace(c.ToString(), "");
                            }
                        }
                    else
                    {
                        for (int i = 0; i < newNameSb.Length - 1; i++)
                        {
                            if (CleanUserDefinedText.Contains(newNameSb[i].ToString().ToLower()))
                            {
                                foreach (char c in CleanUserDefinedText.ToLower())
                                    newNameSb.Replace(c.ToString(), "");
                                foreach (char c in CleanUserDefinedText.ToUpper())
                                    newNameSb.Replace(c.ToString(), "");
                            }
                        }
                    }
                }
                if (IgnoreExtension)
                    newNameSb.Append(extension);

                return newNameSb.ToString();
            }
            catch { return Path.GetFileName(torrentFileInfo.NewestName); }
        }
    }
}
