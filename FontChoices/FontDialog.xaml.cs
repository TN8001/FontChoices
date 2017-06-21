using System.Windows;
using System.Windows.Media;

namespace FontChoices
{
    public partial class FontDialog : Window
    {
        public FontFamily SelectedFontFamily { get => fontPicker.SelectedFontFamily; set => fontPicker.SelectedFontFamily = value; }
        public FontStyle SelectedFontStyle { get => fontPicker.SelectedFontStyle; set => fontPicker.SelectedFontStyle = value; }
        public FontWeight SelectedFontWeight { get => fontPicker.SelectedFontWeight; set => fontPicker.SelectedFontWeight = value; }
        public FontStretch SelectedFontStretch { get => fontPicker.SelectedFontStretch; set => fontPicker.SelectedFontStretch = value; }
        public double SelectedFontSize { get => fontPicker.SelectedFontSize; set => fontPicker.SelectedFontSize = value; }

        public FontDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) => DialogResult = true;
    }
}
