namespace bojan3011_ppp_projekat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nalog")]
    public partial class Nalog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NalogId { get; set; }

        public int VoziloID { get; set; }

        public int KlijentID { get; set; }

        [Required]
        [StringLength(2)]
        public string MozeInostranstvo { get; set; }

        [Required]
        [StringLength(2)]
        public string VracaUInostranstvu { get; set; }

        [Column(TypeName = "date")]
        public DateTime Datum { get; set; }

        public virtual Klijent Klijent { get; set; }

        public virtual Vozilo Vozilo { get; set; }
    }
}
