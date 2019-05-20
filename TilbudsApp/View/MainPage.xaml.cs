    using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
    using TilbudsApp.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TilbudsApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        ///  Databinded My mainpage to Butikviewmodel
        /// </summary>
        private ButikViewModel ViewModel { get; } = new ButikViewModel();
        
        public MainPage()
        {
            this.InitializeComponent();
        }

        //private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        //{

        //}
        
        //private void ListViewOverButikker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}
    }
}
