using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace FontChoices
{
    /// <summary>Typefaceに各日本語名プロパティを追加</summary>
    internal class TypefaceJP : Typeface
    {
        #region STRETCH
        private static readonly Dictionary<string, string> STRETCH = new Dictionary<string, string>()
        {
            {"UltraCondensed", "より狭い(50%)"},
            {"ExtraCondensed", "より狭い(62.5%)"},
            {"Condensed", "狭い(75%)"},
            {"SemiCondensed", "やや狭い(87.5%)"},
            {"Normal", ""},
            {"Medium", ""},
            {"SemiExpanded", "やや広い(112.5%)"},
            {"Expanded", "広い(125%)"},
            {"ExtraExpanded", "より広い(150%)"},
            {"UltraExpanded", "より広い(200%)"},
        };
        #endregion
        #region  WEIGHT
        private static readonly Dictionary<string, string> WEIGHT = new Dictionary<string, string>()
        {
            {"Thin", "極細"},
            {"ExtraCondensed", "細字"},
            {"UltraCondensed", "細字"},
            {"Light", "中細"},
            {"Regular", ""},
            {"Normal", ""},
            {"Medium", "中"},
            {"SemiBold", "中太"},
            {"DemiBold", "中太"},
            {"Bold", "太字"},
            {"Black", "極太"},
            {"Heavy", "極太"},
            {"UltraBlack", "超極太"},
            {"ExtraBlack", "超極太"},
        };
        #endregion
        #region  STYLE
        private static readonly Dictionary<string, string> STYLE = new Dictionary<string, string>()
        {
            {"Italic", "イタリック"},
            {"Normal", ""},
            {"Oblique", "斜体"},
        };
        #endregion

        public string FaceNameJP { get; }

        public TypefaceJP(string typefaceName) : base(typefaceName)
        {
            FaceNameJP = GetFaceNameJP();
        }
        public TypefaceJP(FontFamily fontFamily, FontStyle style, FontWeight weight, FontStretch stretch) : base(fontFamily, style, weight, stretch)
        {
            FaceNameJP = GetFaceNameJP();
        }
        public TypefaceJP(Typeface typeface)
            : this(typeface?.FontFamily,
                   typeface?.Style ?? FontStyles.Normal,
                   typeface?.Weight ?? FontWeights.Normal,
                   typeface?.Stretch ?? FontStretches.Normal)
        { }

        private string GetFaceNameJP()
        {
            var style = Style.ToString();
            var weight = Weight.ToString();
            var stretch = Stretch.ToString();
            string[] l =
            {
                //上記辞書で出来る限り日本語化
                STRETCH.GetOrDefault(stretch, stretch),
                WEIGHT.GetOrDefault(weight, weight),
                STYLE.GetOrDefault(style, style)
            };
            var simulated = ((IsBoldSimulated) || (IsObliqueSimulated)) ? " (Simulated)" : "";

            //スペースで区切って整形
            var s = string.Join(" ", l.Where(x => !string.IsNullOrEmpty(x)));
            return string.IsNullOrEmpty(s) ? "標準" + simulated : s + simulated;
        }
    }

    internal static class DictionaryExtensions
    {
        /// <summary>DictionaryExtension デフォルト付きGet</summary>
        public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> self, TKey key, TValue defaultValue = default(TValue))
            => self.TryGetValue(key, out TValue value) ? value : defaultValue;
    }
}
