using System.Collections.Generic;
using System.Linq;
using System.Windows.Markup;
using System.Windows.Media;

namespace FontChoices
{
    internal class SystemFontsModel
    {
        private static ICollection<FontFamily> _SystemFonts;
        /// <summary>インストールされているフォントのリスト</summary>
        public static ICollection<FontFamily> SystemFonts
        {
            get
            {
                if(_SystemFonts == null)
                    _SystemFonts = GetSystemFonts();
                return _SystemFonts;
            }
        }

        /// <summary>インストール済フォントリストをソートして 名前を日本語名>英語名>デフォルト名の優先度で取得</summary>
        private static ICollection<FontFamily> GetSystemFonts()
        {
            var systemFonts = new List<FontFamily>();
            var jp = XmlLanguage.GetLanguage("ja-jp");
            var us = XmlLanguage.GetLanguage("en-us");
            foreach(var font in Fonts.SystemFontFamilies)
            {
                if(font.FamilyNames.ContainsKey(jp))
                    systemFonts.Add(new FontFamily(font.FamilyNames[jp]));
                else if(font.FamilyNames.ContainsKey(us))
                    systemFonts.Add(new FontFamily(font.FamilyNames[us]));
                else
                    systemFonts.Add(new FontFamily(font.FamilyNames.First().Value));
            }
            systemFonts.Sort((x, y) => string.Compare(x.Source, y.Source, System.StringComparison.Ordinal));
            return systemFonts;
        }
    }
}
