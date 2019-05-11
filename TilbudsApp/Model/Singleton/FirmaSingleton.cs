using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilbudsApp.Persistency;

namespace TilbudsApp.Model.Singleton
{
    class FirmaSingleton
    {
        private static FirmaSingleton _instance = null;

        public static FirmaSingleton Instance
        {
            get { return _instance ?? (_instance = new FirmaSingleton()); }
        }

        public ObservableCollection<Firma> FirmaCollection { get; set; }

        private FirmaSingleton()
        {
            FirmaCollection = new ObservableCollection<Firma>();
        }

        public void Add(int id, string fname)
        {
            Firma firmaToBeAdded = new Firma(id,fname);
            FirmaCollection.Add(firmaToBeAdded);
            FirmaPersistencyService.PostFirmaAsync(firmaToBeAdded);
        }

        public void Delete(Firma FirmaToBeDelete)
        {
            FirmaCollection.Remove((FirmaToBeDelete));
            FirmaPersistencyService.DeleteFirmaAsync(FirmaToBeDelete);
        }
    }
}
