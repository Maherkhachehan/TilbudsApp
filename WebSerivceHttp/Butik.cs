namespace WebSerivceHttp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Butik")]
    public partial class Butik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Butik()
        {
            TilbudItem = new HashSet<TilbudItem>();
        }

        public int Id { get; set; }

        public int FirmaId { get; set; }

        public int ZipCode { get; set; }

        [StringLength(50)]
        public string Adresse { get; set; }

        public virtual Firma Firma { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TilbudItem> TilbudItem { get; set; }
    }
}
