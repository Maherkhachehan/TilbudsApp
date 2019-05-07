using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilbudsApp.Model
{
    class TilbudItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int ButikId { get; set; }
        public int Antal { get; set; }

        public TilbudItem(int id, int itemid, int butikId, int antal)
        {
            Id = id;
            ItemId = itemid;
            ButikId = butikId;
            Antal = antal;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(ItemId)}: {ItemId}, {nameof(ButikId)}: {ButikId}, {nameof(Antal)}: {Antal}";
        }
    }

}
