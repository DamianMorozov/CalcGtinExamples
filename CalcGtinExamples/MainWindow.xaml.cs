using System.Windows;

namespace CalcGtinExamples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ViewModel _viewModel;

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
            _viewModel.Gtin = _viewModel.GetGtin(_viewModel.Ean, EnumGtinVariant.Var1);
        }

        private void ButtonGtinCalcV1_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.Gtin = _viewModel.GetGtin(_viewModel.Ean, EnumGtinVariant.Var1);
        }
        
        private void ButtonGtinCalcV2_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.Gtin = _viewModel.GetGtin(_viewModel.Ean, EnumGtinVariant.Var2);
        }
        
        private void ButtonGtinCalcV3_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.Gtin = _viewModel.GetGtin(_viewModel.Ean, EnumGtinVariant.Var3);
        }
    }
}
