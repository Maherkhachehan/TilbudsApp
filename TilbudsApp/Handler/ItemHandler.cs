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
            // hvad FUCK laver du her
            // det var det abed sagde der skulle stå
            OpretItemVM.ItemSingleton.Add(
                OpretItemVM.Id, 
                OpretItemVM.Iname, 
                OpretItemVM.Beskrivelse);
        }

    }
}
