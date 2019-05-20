using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
    public class ButikViewModel : INotifyPropertyChanged
    {
        // We don't need other codes here, we'll call all from ButikSingleton class

        public ButikSingleton ButikSingleton { get; set; }

        public ButikViewModel()
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
