using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilbudsApp.Persistency;

namespace TilbudsApp.Model.Singleton
{
    public class ButikSingleton
    {
        private static ButikSingleton _instance = null;

        public static ButikSingleton Instance
        {
            get { return _instance ?? (_instance = new ButikSingleton()); }
        }

        public ObservableCollection<Butik> ButikCollection { get; set; }
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
            ButikCollection = new ObservableCollection<Butik>
            {
                new Butik(1, 001, 111002, "Sample City Address 1"),
                new Butik(2, 102, 232, "Sample City Address 2"),
                new Butik(3, 203, 11111002, "Sample City Address 3"),
                new Butik(4, 304, 1311002, "Sample City Address 4"),
            };
            //List<Butik> tempList = new List<Butik>();

            //tempList = await ButikPersistencyService.GetButikAsync();
            //foreach (Butik butik in tempList)
            //{
            //    ButikCollection.Add(butik);
            //}
        }
        public async void LoadFromDB()
        {
            ByerCollection = new ObservableCollection<Byer>
            {
                new Byer(1, "Test 1"),
                new Byer(2, "Test 2"),
                new Byer(3, "Test 3"),
                new Byer(4, "Test 4")
            };


            //ObservableCollection<Byer> tempList = new ObservableCollection<Byer>();

            //// her får jeg en liste af byer. fordi jeg har skrevet ".result"
            //tempList = await ByerPersistencyService.GetByerAsync();

            //// her går jeg igennem listen med foreach, for at add dem til min OC'list
            //foreach (Byer by in tempList)
            //{
            //    ByerCollection.Add(by);
            //}
        }
    }
}
