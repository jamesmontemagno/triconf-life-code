// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Ceton Corporation">
//   Copyright © 2013 Ceton Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using triconf.Model;

namespace VeronaWin8.Common
{
   

    public class HomeItemTemplateSelector : DataTemplateSelector
    {
        private Random m_Random = new Random();
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var home = item as HomeDataItem;
            if (home != null && home.Items.Count > 0)
            {
                var random = m_Random.Next(0, 100) % 2;
                if (random == 0)
                {
                    return Application.Current.Resources["HomeMenuLiveTileDataTemplate"] as DataTemplate;
                }

                return Application.Current.Resources["HomeMenuLiveTileDataTemplate2"] as DataTemplate;
            }

            return Application.Current.Resources["HomeMenuDataTemplate"] as DataTemplate;
        }

    }

    public class MainItemStyleSelector : StyleSelector
    {
        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            var i = (StandardDataItem)item;

            if (i.ColSpan == 2 && i.RowSpan == 1)
            {
                return Application.Current.Resources["WideGridViewItemStyle"] as Style;
            }
            else if (i.ColSpan == 2 && i.RowSpan == 2)
            {
                return Application.Current.Resources["WideAndTallGridViewItemStyle"] as Style;
            }
            else if (i.ColSpan == 1 && i.RowSpan == 2)
            {
                return Application.Current.Resources["TallGridViewItemStyle"] as Style;
            }
            else if (i.ColSpan == 2 && i.RowSpan == 3)
            {
                return Application.Current.Resources["SuperTallAndWideGridViewItemStyle"] as Style;
            }

            return Application.Current.Resources["GridViewItemContainerStyleNoSelection"] as Style;
        }
    }

    public class HomeGroupSelector : GroupStyleSelector
    {
        protected override GroupStyle SelectGroupStyleCore(object group, uint level)
        {
            if (ApplicationView.Value == ApplicationViewState.FullScreenPortrait)
            {
                return Application.Current.Resources["HomeGroupStylePortrait"] as GroupStyle;
            }

            return Application.Current.Resources["HomeGroupStyle"] as GroupStyle;
        }
    }
}
