using System.Windows;
using CalcGtinExamplesCore;

namespace CalcGtinExamples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    public partial class MainWindow
    {
        private readonly ViewModel _viewModel;
        private readonly BarcodeHelper _barcode = BarcodeHelper.Instance;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = DataContext as ViewModel;
        }

        private void ButtonEanSetNew_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.SetEan();
        }
        
        private void ButtonEanClear_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.ClearEan();
            _viewModel.Gtin = _barcode.GetGtin(_viewModel.Ean, EnumGtinVariant.Var1);
        }

        private void ButtonGtinCalcV1_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.Gtin = _barcode.GetGtin(_viewModel.Ean, EnumGtinVariant.Var1);
        }
        
        private void ButtonGtinCalcV2_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.Gtin = _barcode.GetGtin(_viewModel.Ean, EnumGtinVariant.Var2);
        }
        
        private void ButtonGtinCalcV3_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.Gtin = _barcode.GetGtin(_viewModel.Ean);
        }
    }
}
