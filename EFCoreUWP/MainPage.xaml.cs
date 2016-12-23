using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace EFCoreUWP {
  public sealed partial class MainPage : Page {
    private BingeViewModel _binge;

    public MainPage() {
      InitializeComponent();
      _binge = new BingeViewModel();
      NomText.Visibility = Visibility.Collapsed;
      // Refresh bing list after a new binge is added
      _binge.BingeCompleted += s => { ReloadHistory(); };
      BingePane.DataContext = _binge;
    }

    private void Page_Loaded(object sender, RoutedEventArgs e) {
      ReloadHistory();
    }

    private void ReloadHistory() {
      BingeList.ItemsSource = BingeService.GetLast5Binges();
    }

    //private void Image_Tapped(object sender, TappedRoutedEventArgs e) {
    //  _binge.HandleClick();
    //}

    private void Play_Tapped(object sender, TappedRoutedEventArgs e) {
      _binge.StartNewBinge();
    }

    private void AddCookies_Click(object sender, RoutedEventArgs e) {
    }

    private void WorthIt_Click(object sender, RoutedEventArgs e) {
      _binge.StoreBinge(true);
    }

    private void NotWorthIt_Click(object sender, RoutedEventArgs e) {
      _binge.StoreBinge(false);
    }

   private void CookieImage_PointerPressed(object sender, PointerRoutedEventArgs e) {
      var pt = e.GetCurrentPoint(BingeGrid);
      NomText.Margin = new Thickness(pt.Position.X, pt.Position.Y, 0, 0);

      NomText.Visibility = Visibility.Visible;
      _binge.HandleClick();
    }

    private void CookieImage_PointerReleased(object sender, PointerRoutedEventArgs e) {
      NomText.Visibility = Visibility.Collapsed;
    }
  }
}