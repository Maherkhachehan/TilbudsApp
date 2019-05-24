using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilbudsApp.ViewModel;

namespace TilbudsApp.Handler
{
    class ItemHandler
    {
        public OpretItem OpretItemVM { get; set; }

        public ItemHandler(OpretItem opretItem)
        {
            OpretItemVM = opretItem;
        }

        public void AddItem()
        {
            OpretItemVM.ItemSingleton.Add(OpretItemVM.Id, OpretItemVM.Iname, OpretItemVM.Beskrivelse);
        }

    }
}
