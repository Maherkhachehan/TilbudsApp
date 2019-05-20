using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TilbudsApp.Annotations;
using TilbudsApp.Model;
using TilbudsApp.Model.Singleton;

namespace TilbudsApp.ViewModel
{

    public class TilbudVM : INotifyPropertyChanged
    {
        public int Id { get; set; }
        //public int FirmaId { get; set; }
        //public int Zipcode { get; set; }
        //public string Adresse { get; set; }
        public Byer _selectedby;

        public ButikSingleton ButikSingleton { get; set; }

        public TilbudVM()
        {
            ButikSingleton = ButikSingleton.Instance;
            ButikSingleton.LoadDb();
            ButikSingleton.LoadFromDB();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
