using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilbudsApp.Model
{
    public class Byer
    {
        public int Id { get; set; }
        public string Bname { get; set; }

        public Byer(int id, string bname)
        {
            Id = id;
            Bname = bname;
        }

        public override string ToString()
        {
            // Dette bruges til kun at, printe id og byes navn uden det der står foran.
            // (isted for Id 3000 så bliver der printet ud 3000)
            // Oprydning for se godt ud til kunderne.
            return $"{Id}, {Bname}";
            //return $"{nameof(Id)}: {Id}, {nameof(Bname)}: {Bname}";
    }
    }
}
