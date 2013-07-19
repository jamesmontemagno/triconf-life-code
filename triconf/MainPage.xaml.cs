using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GalaSoft.MvvmLight.Ioc;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using triconf.Model;
using triconf.ViewModel;

namespace triconf
{
    public sealed partial class MainPage : Page
    {


        private MainViewModel m_ViewModel;
        private MainViewModel ViewModel { get { return m_ViewModel ?? (m_ViewModel = DataContext as MainViewModel); } }


        public MainPage()
        {

            if (!SimpleIoc.Default.IsRegistered<MainViewModel>())
                SimpleIoc.Default.Register<MainViewModel>();

            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }


        private void Semantic_ViewChangeStarted(object sender, SemanticZoomViewChangedEventArgs e)
        {
            if (groupedItemsViewSource.View != null)
                (Semantic.ZoomedOutView as ListViewBase).ItemsSource = groupedItemsViewSource.View.CollectionGroups;
        }

        private void ItemWasTapped(object sender, TappedRoutedEventArgs e)
        {
            GoToItem(e.OriginalSource);
        }

        private void GoToItem(object originalSource)
        {
            var element = originalSource as FrameworkElement;
            if (element == null)
                return;

            var item = element.DataContext as StandardDataItem;
            if (item == null)
                return;

            ViewModel.ExecuteMoreInfoCommand(item);
        }
    }
}
