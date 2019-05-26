namespace WebSerivceHttp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Byer")]
    public partial class Byer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Bname { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Bname)}: {Bname}";
        }
    }
}
