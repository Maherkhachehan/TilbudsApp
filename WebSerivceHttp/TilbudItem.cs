namespace WebSerivceHttp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TilbudItem")]
    public partial class TilbudItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int ItemId { get; set; }

        public int ButikId { get; set; }

        public int? Antal { get; set; }

        public virtual Butik Butik { get; set; }

        public virtual Item Item { get; set; }
    }
}
