namespace bojan3011_ppp_projekat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Proizvodjac")]
    public partial class Proizvodjac
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proizvodjac()
        {
            Voziloes = new HashSet<Vozilo>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProizvodjacId { get; set; }

        public int DrzavaID { get; set; }

        [Required]
        [StringLength(20)]
        public string Naziv { get; set; }

        public virtual Drzava Drzava { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vozilo> Voziloes { get; set; }
    }
}
