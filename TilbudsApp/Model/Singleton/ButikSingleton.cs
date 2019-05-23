using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TilbudsApp.Persistency;

namespace TilbudsApp.Model.Singleton
{
    public class ButikSingleton : INotifyPropertyChanged
    {
        private static ButikSingleton _instance = null;

        public static ButikSingleton Instance
        {
            get { return _instance ?? (_instance = new ButikSingleton()); }
        }

        private Byer _selectedItem;

        public Byer SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                if (value != null)
                {
                    // Call this method whenever selected item is changed in Byer list
                    FilterDb(_selectedItem.Id);
                }

            }
        }

        private ObservableCollection<Butik> _butikCollection;

        public ObservableCollection<Butik> ButikCollection
        {
            get => _butikCollection;
            set
            {
                _butikCollection = value;
                NotifyPropertyChanged();
            }
        }

        #region PropertyChange
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {

            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        public ObservableCollection<Byer> ByerCollection { get; set; }

        private ButikSingleton()
        {
            ButikCollection = new ObservableCollection<Butik>();
            ByerCollection = new ObservableCollection<Byer>();
        }

        public void Add(int id, int firmaId, int zipCode, string adresse)
        {
            Butik butikToBeAdded = new Butik(id, firmaId, zipCode, adresse);
            ButikCollection.Add(butikToBeAdded);
            ButikPersistencyService.PostButikAsync(butikToBeAdded);
        }

        public void Delete(Butik ButikToBeDelete)
        {
            ButikCollection.Remove((ButikToBeDelete));
            ButikPersistencyService.DeleteButikAsync(ButikToBeDelete);
        }

        public async void LoadDb()
        {
            
            // TODO: Fjern highlight fra Byer ListView
            SelectedItem = null;

            // Clear any items to prevent duplicate since foreach ADDS the SAME database
            ButikCollection.Clear();



            List<Butik> tempList = new List<Butik>(); // this load butik?

            tempList = await ButikPersistencyService.GetButikAsync();
            foreach (Butik butik in tempList)
            {
                ButikCollection.Add(butik);
            }
        }

        /// <summary>
        /// Filter original (complete) data with parameter to be filtered
        /// </summary>
        /// <param name="id"></param>

            // Int? betyder den kan være Null
        public async void FilterDb(int? id)
        {
            // Load original database
            LoadDb();

            // Filter by 
            ButikCollection = new ObservableCollection<Butik>(ButikCollection.Where(x => x.Zipcode == id));
        }

        

        public async void LoadFromDB() // this load byer??? 
        {
            List<Byer> tempList = new List<Byer>();

            // her får jeg en liste af byer. fordi jeg har skrevet ".result"
            tempList = await ByerPersistencyService.GetByerAsync();

            // her går jeg igennem listen med foreach, for at add dem til min OC'list
            foreach (Byer by in tempList)
            {
                ByerCollection.Add(by);
            }
         

        }
    }
}
