using System.Text.RegularExpressions;

namespace WH.Common.SecurityTools
{
    public static class EmailHelpers
    {
        public const char CensorWildcard = '*';

        /// <summary>
        ///  Replaces the classified words located in the email text. A return value indicates whether
        ///  any word have been censored.
        /// </summary>
        /// <param name="classifieds">A list of classified words/phrases</param>
        /// <param name="text">The email text. A new email text where the classified words or phrases have been replaced
        ///  with asterisks, or the original email text if there was no classified material in the email.</param>
        /// <returns>
        /// true/false If any of the classified words or phrases were located in the email.
        /// </returns>
        public static bool ClassifyEmail(string[] classifieds, ref string text)
        {
            var hasClassifiedWords = false;

            if (string.IsNullOrWhiteSpace(text))
                return hasClassifiedWords;

            classifieds = classifieds.Where(c => !string.IsNullOrWhiteSpace(c))
                .Distinct()
                .Select(c => Regex.Escape(c))
                .OrderByDescending(s => s.Length)
                .ToArray();

            if (!classifieds.Any())
                return hasClassifiedWords;

            Regex rx = new(string.Join('|', classifieds)
                , RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Compiled);
            
            string result = rx.Replace(text, (Match m) => {
                hasClassifiedWords = true;
                return new string(CensorWildcard, m.Length);
            });

            if(hasClassifiedWords)
                text = result;

            return hasClassifiedWords;
        }
    }
}