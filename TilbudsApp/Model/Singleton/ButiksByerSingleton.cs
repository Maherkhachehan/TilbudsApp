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
    public class ButiksByerSingleton : INotifyPropertyChanged
    {
        private static ButiksByerSingleton _instance = null;

        public static ButiksByerSingleton Instance
        {
            get { return _instance ?? (_instance = new ButiksByerSingleton()); }
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
                    // Kalder den her metode hvergang selected item er skiftet i byer listen.
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

        private ButiksByerSingleton()
        {
            ButikCollection = new ObservableCollection<Butik>();
            ByerCollection = new ObservableCollection<Byer>();

            LoadDb();
            LoadFromDB();
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
            SelectedItem = null;
            // Clear alle items for duplicate pga Foreach Addere det samme fra database.
            ButikCollection.Clear();

            List<Butik> tempList = new List<Butik>(); 

            tempList = await ButikPersistencyService.GetButikAsync();
            foreach (Butik butik in tempList)
            {
                ButikCollection.Add(butik);
            }
        }

        
            // Int? betyder den kan være Null
        public async void FilterDb(int? id)
        {
            // Load original database

            LoadDb();

            // Filterering af butikkerne. 
            ButikCollection = 
                new ObservableCollection<Butik>(ButikCollection.Where(x => x.Zipcode == id));
        }

        

        public async void LoadFromDB() // this load byer??? 
        {
            List<Byer> tempList = new List<Byer>();

            // her får jeg en liste af byer
            tempList = await ByerPersistencyService.GetByerAsync();

            // her går jeg igennem listen med foreach, for at add dem til min OC'list
            foreach (Byer by in tempList)
            {
                ByerCollection.Add(by);
            }
         

        }
    }
}
