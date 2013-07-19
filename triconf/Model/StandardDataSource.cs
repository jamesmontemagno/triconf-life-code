using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using triconf.Common;

// The data model defined by this file serves as a representative example of a strongly-typed
// model that supports notification when members are added, removed, or modified.  The property
// names chosen coincide with data bindings in the standard item templates.
//
// Applications may use this model as a starting point and build on it, or discard it entirely and
// replace it with something appropriate to their needs.

namespace triconf.Model
{
    /// <summary>
    /// Base class for <see cref="StandardDataItem"/> and <see cref="StandardDataGroup"/> that
    /// defines properties common to both.
    /// </summary>
    [Windows.Foundation.Metadata.WebHostHidden]
    public abstract class DataModelBase : BindableBase
    {
        protected DataModelBase(string uniqueId, Int64 id, String title, String subtitle, String imagePath = null, String description = null)
        {
            this.m_UniqueId = uniqueId;
            this.m_Id = id;
            this.m_Title = title;
            this.m_Subtitle = subtitle;
            this.m_Description = description;
            this.m_ImagePath = imagePath;
        }

        private string m_UniqueId;
        public string UniqueId
        {
            get { return this.m_UniqueId; }
            set { this.SetProperty(ref this.m_UniqueId, value); }
        }

        private Int64 m_Id = 0;
        public Int64 Id
        {
            get { return this.m_Id; }
            set { this.SetProperty(ref this.m_Id, value); }
        }

        private string m_Title = string.Empty;
        public string Title
        {
            get { return this.m_Title; }
            set { this.SetProperty(ref this.m_Title, value); }
        }

        private string m_Subtitle = string.Empty;
        public string Subtitle
        {
            get { return this.m_Subtitle; }
            set { this.SetProperty(ref this.m_Subtitle, value); }
        }

        private string m_Description = string.Empty;
        public string Description
        {
            get { return this.m_Description; }
            set { this.SetProperty(ref this.m_Description, value); }
        }

        protected String m_ImagePath = null;
        public virtual String Image
        {
            get
            {
                /*if (this._image == null && this._imagePath != null)
                {
                    this._image = new BitmapImage(new Uri(DataModelBase._baseUri, this._imagePath));
                }*/
                return this.m_ImagePath;
            }

            set
            {
                //this._imagePath = null;
                this.SetProperty(ref this.m_ImagePath, value);
            }
        }

        public void SetImage(String path)
        {
            this.m_ImagePath = path;
            this.OnPropertyChanged("Image");
        }

        public override string ToString()
        {
            return this.Title;
        }
    }

    public class HomeDataItem : StandardDataItem
    {
        public HomeDataItem(string uniqueId, Int64 id, String title, String subtitle, String imagePath = null,
                            String description = null, String content = null, StandardDataGroup group = null) :
            base(uniqueId, id, title, subtitle, imagePath, description, content, group)
        {
            //random stuff

        }




        private readonly ObservableCollection<StandardDataItem> m_Items = new ObservableCollection<StandardDataItem>();
        public ObservableCollection<StandardDataItem> Items
        {
            get { return m_Items; }
        }

    }

    /// <summary>
    /// Generic item data model.
    /// </summary>
    public class StandardDataItem : DataModelBase
    {
        public StandardDataItem(string uniqueId, Int64 id, String title, String subtitle, String imagePath = null, String description = null, String content = null, StandardDataGroup group = null)
            : base(uniqueId, id, title, subtitle, imagePath, description)
        {
            this._content = content;
            this._group = group;
        }

        private string _content = string.Empty;
        public string Content
        {
            get { return this._content; }
            set { this.SetProperty(ref this._content, value); }
        }

        private StandardDataGroup _group;
        public StandardDataGroup Group
        {
            get { return this._group; }
            set { this.SetProperty(ref this._group, value); }
        }

        public const string ColSpanPropertyName = "ColSpan";

        private int _colSpan = 1;

        public int ColSpan
        {
            get
            {
                return _colSpan;
            }
            set
            {
                SetProperty(ref _colSpan, value, ColSpanPropertyName);
            }
        }


        private int m_RowSpan = 1;

        public int RowSpan
        {
            get
            {
                return m_RowSpan;
            }
            set
            {
                SetProperty(ref m_RowSpan, value);
            }
        }
    }

    /// <summary>
    /// Generic group data model.
    /// </summary>
    public class StandardDataGroup : DataModelBase
    {
        public StandardDataGroup(String uniqueId, String title, String subtitle = null, String imagePath = null, String description = null, Int64 id = 0, IEnumerable<StandardDataItem> items = null, int totalItems = 200)
            : base(uniqueId, id, title, subtitle, imagePath, description)
        {
            if (totalItems < 200)
                TopMax = 40;




            Items.CollectionChanged += ItemsCollectionChanged;

            if (items == null)
                return;

            foreach (var item in items)
                Items.Add(item);

            ItemCount = Items.Count > TopMax ? "(" + Items.Count + ")" : string.Empty;
        }



        public const string OrderPropertyName = "Order";

        private int m_Order = 1;

        public int Order
        {
            get
            {
                return m_Order;
            }
            set
            {
                SetProperty(ref m_Order, value, OrderPropertyName);
            }
        }


#if ARM
        private int TopMax = 9;
#else
        private int TopMax = 12;
#endif
        private void ItemsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Provides a subset of the full items collection to bind to from a GroupedItemsPage
            // for two reasons: GridView will not virtualize large items collections, and it
            // improves the user experience when browsing through groups with large numbers of
            // items.
            //
            // A maximum of 12 items are displayed because it results in filled grid columns
            // whether there are 1, 2, 3, 4, or 6 rows displayed

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewStartingIndex < TopMax)
                    {
                        TopItems.Insert(e.NewStartingIndex, Items[e.NewStartingIndex]);
                        if (TopItems.Count > TopMax)
                        {
                            TopItems.RemoveAt(TopMax);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Move:
                    if (e.OldStartingIndex < TopMax && e.NewStartingIndex < TopMax)
                    {
                        TopItems.Move(e.OldStartingIndex, e.NewStartingIndex);
                    }
                    else if (e.OldStartingIndex < TopMax)
                    {
                        TopItems.RemoveAt(e.OldStartingIndex);
                        TopItems.Add(Items[11]);
                    }
                    else if (e.NewStartingIndex < TopMax)
                    {
                        TopItems.Insert(e.NewStartingIndex, Items[e.NewStartingIndex]);
                        TopItems.RemoveAt(TopMax);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:

                    ItemCount = Items.Count > TopMax ? "(" + Items.Count + ")" : string.Empty;

                    if (e.OldStartingIndex < TopMax)
                    {
                        TopItems.RemoveAt(e.OldStartingIndex);
                        if (Items.Count >= TopMax)
                        {
                            TopItems.Add(Items[TopMax - 1]);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    if (e.OldStartingIndex < TopMax)
                    {
                        TopItems[e.OldStartingIndex] = Items[e.OldStartingIndex];
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    TopItems.Clear();
                    while (TopItems.Count < Items.Count && TopItems.Count < TopMax)
                    {
                        TopItems.Add(Items[TopItems.Count]);
                    }
                    break;
            }
        }

        private ObservableCollection<StandardDataItem> _items = new ObservableCollection<StandardDataItem>();
        public ObservableCollection<StandardDataItem> Items
        {
            get { return this._items; }
        }

        private ObservableCollection<StandardDataItem> _topItem = new ObservableCollection<StandardDataItem>();
        public ObservableCollection<StandardDataItem> TopItems
        {
            get { return this._topItem; }
        }

        private string m_ItemCount = string.Empty;
        public string ItemCount
        {
            get { return m_ItemCount; }
            set { SetProperty(ref m_ItemCount, value); }
        }
    }

    /// <summary>
    /// Creates a collection of groups and items with hard-coded content.
    /// 
    /// SampleDataSource initializes with placeholder data rather than live production
    /// data so that sample data is provided at both design-time and run-time.
    /// </summary>
    public class StandardDataSource
    {
        public static StandardDataSource _sampleDataSource = new StandardDataSource();

        private ObservableCollection<StandardDataGroup> _allGroups = new ObservableCollection<StandardDataGroup>();
        public ObservableCollection<StandardDataGroup> AllGroups
        {
            get { return this._allGroups; }

        }

        /*public static IEnumerable<StandardDataGroup> GetGroups(string uniqueId)
        {
            if (!uniqueId.Equals("AllGroups")) throw new ArgumentException("Only 'AllGroups' is supported as a collection of groups");
            
            return _sampleDataSource.AllGroups;
        }*/

        public static StandardDataGroup GetGroup(string uniqueId, ObservableCollection<StandardDataGroup> groups)
        {
            // Simple linear search is acceptable for small data sets
            var matches = groups.Where((group) => group.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public static StandardDataItem GetItem(long id, ObservableCollection<StandardDataGroup> groups)
        {
            // Simple linear search is acceptable for small data sets
            var matches = groups.SelectMany(group => group.Items).Where((item) => item.Id.Equals(id));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public StandardDataSource()
        {
        }
    }
}
