using System.Windows;
using System.Windows.Media;

namespace FontChoicesDemo
{
    public class ViewModel : BindableBase
    {
        public FontFamily Family { get => _Family; set => SetProperty(ref _Family, value); }
        private FontFamily _Family = new FontFamily("メイリオ");

        public FontStyle Style { get => _Style; set => SetProperty(ref _Style, value); }
        private FontStyle _Style = FontStyles.Normal;

        public FontWeight Weight { get => _Weight; set => SetProperty(ref _Weight, value); }
        private FontWeight _Weight = FontWeights.Normal;

        public FontStretch Stretch { get => _Stretch; set => SetProperty(ref _Stretch, value); }
        private FontStretch _Stretch = FontStretches.Normal;

        public double Size { get => _Size; set => SetProperty(ref _Size, value); }
        private double _Size = 15;
    }
}
