using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace FontChoices
{
    public partial class FontPicker : UserControl
    {
        [Category("FontPicker")]
        [Description("選択されているFontFamilyを取得、設定します。")]
        public FontFamily SelectedFontFamily { get => (FontFamily)GetValue(SelectedFontFamilyProperty); set => SetValue(SelectedFontFamilyProperty, value); }
        public static readonly DependencyProperty SelectedFontFamilyProperty =
            DependencyProperty.Register("SelectedFontFamily", typeof(FontFamily), typeof(FontPicker), new FrameworkPropertyMetadata(SystemFonts.MessageFontFamily, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Typeface SelectedTypeface { get => (Typeface)GetValue(SelectedTypefaceProperty); set => SetValue(SelectedTypefaceProperty, value); }
        internal static readonly DependencyProperty SelectedTypefaceProperty =
            DependencyProperty.Register("SelectedTypeface", typeof(Typeface), typeof(FontPicker), new PropertyMetadata(new Typeface(SystemFonts.MessageFontFamily.Source), SelectedTypefaceChanged));
        private static void SelectedTypefaceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var p = d as FontPicker;
            var f = e.NewValue as Typeface;

            p.SelectedFontStyle = f?.Style ?? FontStyles.Normal;
            p.SelectedFontWeight = f?.Weight ?? FontWeights.Normal;
            p.SelectedFontStretch = f?.Stretch ?? FontStretches.Normal;
        }

        [Category("FontPicker")]
        [Description("選択されているFontStyleを取得します。（設定してもTypefaceには反映しません）")]
        public FontStyle SelectedFontStyle { get => (FontStyle)GetValue(SelectedFontStyleProperty); set => SetValue(SelectedFontStyleProperty, value); }
        public static readonly DependencyProperty SelectedFontStyleProperty =
            DependencyProperty.Register("SelectedFontStyle", typeof(FontStyle), typeof(FontPicker), new FrameworkPropertyMetadata(FontStyles.Normal, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        [Category("FontPicker")]
        [Description("選択されているFontWeightを取得します。（設定してもTypefaceには反映しません）")]
        public FontWeight SelectedFontWeight { get => (FontWeight)GetValue(SelectedFontWeightProperty); set => SetValue(SelectedFontWeightProperty, value); }
        public static readonly DependencyProperty SelectedFontWeightProperty =
            DependencyProperty.Register("SelectedFontWeight", typeof(FontWeight), typeof(FontPicker), new FrameworkPropertyMetadata(FontWeights.Normal, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        [Category("FontPicker")]
        [Description("選択されているFontStretchを取得します。（設定してもTypefaceには反映しません）")]
        public FontStretch SelectedFontStretch { get => (FontStretch)GetValue(SelectedFontStretchProperty); set => SetValue(SelectedFontStretchProperty, value); }
        public static readonly DependencyProperty SelectedFontStretchProperty =
            DependencyProperty.Register("SelectedFontStretch", typeof(FontStretch), typeof(FontPicker), new FrameworkPropertyMetadata(FontStretches.Normal, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        [Category("FontPicker")]
        [Description("選択されているFontSizeを取得、設定します。")]
        public double SelectedFontSize { get => (double)GetValue(SelectedFontSizeProperty); set => SetValue(SelectedFontSizeProperty, value); }
        public static readonly DependencyProperty SelectedFontSizeProperty =
            DependencyProperty.Register("SelectedFontSize", typeof(double), typeof(FontPicker), new FrameworkPropertyMetadata(SystemFonts.MessageFontSize, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        public FontPicker()
        {
            InitializeComponent();
            baseContainer.DataContext = new SystemFontsModel();
        }
        private void TypefaceComboBox_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            //FontFamilyが変わったとき今選択しているTypefaceがあるとは限らないので
            //一番ある可能性の高い"標準"にリセット
            //使い勝手が悪いとは思うが変なTypefaceを持ったFontFamilyがあったりしてどうしたものか。。。
            var cb = sender as ComboBox;
            foreach(TypefaceJP f in cb.Items)
            {
                if(f.FaceNameJP == "標準")
                {
                    cb.SelectedItem = f;
                    return;
                }
            }
            cb.SelectedIndex = 0;
        }
    }
}
