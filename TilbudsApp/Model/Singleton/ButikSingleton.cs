using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilbudsApp.Persistency;

namespace TilbudsApp.Model.Singleton
{
    class ButikSingleton
    {
        
        private static ButikSingleton _instance = null;

        public static ButikSingleton Instance
        {
            get { return _instance ?? (_instance = new ButikSingleton()); }
        }

        public ObservableCollection<Butik> ButikCollection { get; set; }

        private ButikSingleton()
        {
            ButikCollection = new ObservableCollection<Butik>();
        }

        public void Add(int id, int firmaId, int zipCode, string adresse)
        {
            Butik butikToBeAdded = new Butik(id,firmaId,zipCode,adresse);
            ButikCollection.Add(butikToBeAdded);
            ButikPersistencyService.PostButikAsync(butikToBeAdded);
        }

        public void Delete(Butik ButikToBeDelete)
        {
            ButikCollection.Remove((ButikToBeDelete));
            ButikPersistencyService.DeleteButikAsync(ButikToBeDelete);
        }

    }
}
