using System.Windows;
using FontChoices;

namespace FontChoicesDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new FontDialog();
            if(dlg.ShowDialog() == true)
            {
                var msg = $"FontFamily:\t{dlg.SelectedFontFamily}\n"
                        + $"FontStyle:\t{dlg.SelectedFontStyle}\n"
                        + $"FontWeight:\t{dlg.SelectedFontWeight}\n"
                        + $"FontStretch:\t{dlg.SelectedFontStretch}\n"
                        + $"FontSize:\t\t{dlg.SelectedFontSize}";
                MessageBox.Show(msg, "選択したフォント");
            }
        }
    }
}
