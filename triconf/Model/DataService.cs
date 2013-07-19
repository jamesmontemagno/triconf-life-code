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
            homeItem.Items.Add(new HomeDataItem("live1.1", 1, "Test 1", "subtitle 1"));
            homeItem.Items.Add(new HomeDataItem("live1.2", 1, "Test 2", "subtitle 2"));
            homeItem.Items.Add(new HomeDataItem("live1.3", 1, "Test 3", "subtitle 3"));
            homeItem.Items.Add(new HomeDataItem("live1.4", 1, "Test 4", "subtitle 4"));
            group1.Items.Add(homeItem);
            var standard = new StandardDataItem("live2", 2, "Standard 1", "subtitle 2");
            group1.Items.Add(standard);
            standard = new StandardDataItem("live2", 2, "Standard 1", "subtitle 2"){ColSpan = 2, RowSpan = 2};
            group1.Items.Add(standard);
            source.AllGroups.Add(group1);

            group1 = new StandardDataGroup("eat", "Eat", "Subtitle");
            homeItem = new HomeDataItem("live1", 0, "Live Code", "Live", null, null, null, group1);
            homeItem.Items.Add(new HomeDataItem("live1.1", 1, "Test 1", "subtitle 1"));
            homeItem.Items.Add(new HomeDataItem("live1.2", 1, "Test 2", "subtitle 2"));
            homeItem.Items.Add(new HomeDataItem("live1.3", 1, "Test 3", "subtitle 3"));
            homeItem.Items.Add(new HomeDataItem("live1.4", 1, "Test 4", "subtitle 4"));
            group1.Items.Add(homeItem);
            standard = new StandardDataItem("live2", 2, "Standard 1", "subtitle 2");
            group1.Items.Add(standard);
            standard = new StandardDataItem("live2", 2, "Standard 1", "subtitle 2") { ColSpan = 2, RowSpan = 1 };
            group1.Items.Add(standard);
            standard = new StandardDataItem("live2", 2, "Standard 1", "subtitle 2") { ColSpan = 2, RowSpan = 1 };
            group1.Items.Add(standard);
            standard = new StandardDataItem("live2", 2, "Standard 1", "subtitle 2") { ColSpan = 2, RowSpan = 1 };
            group1.Items.Add(standard);
            standard = new StandardDataItem("live2", 2, "Standard 1", "subtitle 2");
            group1.Items.Add(standard);
            source.AllGroups.Add(group1);

            group1 = new StandardDataGroup("breathe", "Breathe", "Subtitle");
            homeItem = new HomeDataItem("live1", 0, "Live Code", "Live", null, null, null, group1);
            homeItem.Items.Add(new HomeDataItem("live1.1", 1, "Test 1", "1"));
            homeItem.Items.Add(new HomeDataItem("live1.2", 1, "Test 2", "2"));
            homeItem.Items.Add(new HomeDataItem("live1.3", 1, "Test 3", "3"));
            homeItem.Items.Add(new HomeDataItem("live1.4", 1, "Test 4", ""));
            group1.Items.Add(homeItem);
            standard = new StandardDataItem("live2", 2, "Standard 1", "subtitle 2");
            group1.Items.Add(standard);
            standard = new StandardDataItem("live2", 2, "Standard 1", "subtitle 2") { ColSpan = 2, RowSpan = 2 };
            group1.Items.Add(standard);
            source.AllGroups.Add(group1);


            group1 = new StandardDataGroup("about", "@JamesMontemagno", "Subtitle");
            standard = new StandardDataItem("twitter", 2, "Twitter", "subtitle 2");
            group1.Items.Add(standard);
            standard = new StandardDataItem("live2", 2, "Montemagno.com", "subtitle 2") { ColSpan = 2, RowSpan = 2 };
            group1.Items.Add(standard);

            homeItem = new HomeDataItem("thanks", 0, "Thanks To:", "Live", null, null, null, group1);
            homeItem.Items.Add(new HomeDataItem("live1.1", 1, "Test 1", "1"));
            homeItem.Items.Add(new HomeDataItem("live1.2", 1, "Test 2", "2"));
            homeItem.Items.Add(new HomeDataItem("live1.3", 1, "Test 3", "3"));
            homeItem.Items.Add(new HomeDataItem("live1.4", 1, "Test 4", "4"));
            group1.Items.Add(homeItem);

            standard = new StandardDataItem("live2", 2, "Montemagno.com", "subtitle 2") { ColSpan = 2, RowSpan = 2 };
            group1.Items.Add(standard);

           
            standard = new StandardDataItem("live2", 2, "Standard 1", "subtitle 2") { ColSpan = 2, RowSpan = 1 };
            group1.Items.Add(standard);
            source.AllGroups.Add(group1);

            callback(source, null);
        }
    }
}