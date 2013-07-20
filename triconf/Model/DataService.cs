using System;

namespace triconf.Model
{
    public class DataService : IDataService
    {
        public void GetData(Action<StandardDataSource, Exception> callback)
        {
            // Use this to connect to the actual data service
            var source = new StandardDataSource();
            var group1 = new StandardDataGroup("live", "Live", "Subtitle");
            var homeItem = new HomeDataItem("live1", 0, "Live Code", "Live", null, null, null, group1);
            homeItem.Items.Add(new HomeDataItem("live1.1", 1, "C#", "C#"));
            homeItem.Items.Add(new HomeDataItem("live1.2", 1, "Objective C", "Objective C"));
            homeItem.Items.Add(new HomeDataItem("live1.3", 1, "C++", "C++"));
            homeItem.Items.Add(new HomeDataItem("live1.4", 1, "All the Languages", "All the Languages"));
            group1.Items.Add(homeItem);
            var standard = new StandardDataItem("live2", 2, "Adorable", "Adorable");
            group1.Items.Add(standard);
            standard = new StandardDataItem("live2", 2, "DO IT", "DO IT") { ColSpan = 2, RowSpan = 2 };
            group1.Items.Add(standard);
            source.AllGroups.Add(group1);

            group1 = new StandardDataGroup("eat", "Eat", "Eat");
            homeItem = new HomeDataItem("live1", 0, "Live Code", "Live", null, null, null, group1);
            homeItem.Items.Add(new HomeDataItem("live1.1", 1, "Live", "Live"));
            homeItem.Items.Add(new HomeDataItem("live1.2", 1, "Love", "Love"));
            homeItem.Items.Add(new HomeDataItem("live1.3", 1, "Bike", "Bike"));
            homeItem.Items.Add(new HomeDataItem("live1.4", 1, "Code", "Code"));
            group1.Items.Add(homeItem);
            standard = new StandardDataItem("live2", 2, "CCCOde", "CCCOde");
            group1.Items.Add(standard);
            standard = new StandardDataItem("live2", 2, "Thai Food", "Thai Food") { ColSpan = 2, RowSpan = 1 };
            group1.Items.Add(standard);
            standard = new StandardDataItem("live2", 2, "Coffee", "Coffee") { ColSpan = 2, RowSpan = 1 };
            group1.Items.Add(standard);
            standard = new StandardDataItem("live2", 2, "More Coffee", "More Coffee") { ColSpan = 2, RowSpan = 1 };
            group1.Items.Add(standard);
            standard = new StandardDataItem("live2", 2, "All The Coffee", "All The Coffee");
            group1.Items.Add(standard);
            source.AllGroups.Add(group1);

            group1 = new StandardDataGroup("breathe", "Breathe", "Subtitle");
            homeItem = new HomeDataItem("live1", 0, "Live Code", "Live", null, null, null, group1);
            homeItem.Items.Add(new HomeDataItem("live1.1", 1, "You", "You"));
            homeItem.Items.Add(new HomeDataItem("live1.2", 1, "+", "+"));
            homeItem.Items.Add(new HomeDataItem("live1.3", 1, "Me", "Me"));
            homeItem.Items.Add(new HomeDataItem("live1.4", 1, "=", "="));
            homeItem.Items.Add(new HomeDataItem("live1.4", 1, "Us", "Us"));
            group1.Items.Add(homeItem);
            standard = new StandardDataItem("live2", 2, "Better", "Better");
            group1.Items.Add(standard);
            standard = new StandardDataItem("live2", 2, "Faster", "Faster") { ColSpan = 2, RowSpan = 2 };
            group1.Items.Add(standard);
            source.AllGroups.Add(group1);


            group1 = new StandardDataGroup("about", "@JamesMontemagno", "@JamesMontemagno");
            standard = new StandardDataItem("twitter", 2, "Twitter", "Twitter", "ms-appx:///Assets/twitter_logo.png");
            group1.Items.Add(standard);
            standard = new StandardDataItem("live2", 2, "Montemagno.com", "Montemagno.com") { ColSpan = 2, RowSpan = 2 };
            group1.Items.Add(standard);

            homeItem = new HomeDataItem("thanks", 0, "Thanks To:", "Live", null, null, null, group1);
            homeItem.Items.Add(new HomeDataItem("live1.1", 1, "MVVMLight", "MVVMLight"));
            homeItem.Items.Add(new HomeDataItem("live1.2", 1, "Callisto", "Callisto"));
            homeItem.Items.Add(new HomeDataItem("live1.3", 1, "WinRTXamlToolit", "WinRTXamlToolit"));
            homeItem.Items.Add(new HomeDataItem("live1.4", 1, "Q42", "Q42"));
            group1.Items.Add(homeItem);

            standard = new StandardDataItem("live2", 2, "GitHub.com/JamesMontemagno", "GitHub.com/JamesMontemagno") { ColSpan = 2, RowSpan = 2 };
            group1.Items.Add(standard);


            standard = new StandardDataItem("live2", 2, "MotzCod.es", "MotzCod.es") { ColSpan = 2, RowSpan = 1 };
            group1.Items.Add(standard);
            source.AllGroups.Add(group1);

            callback(source, null);
        }
    }
}