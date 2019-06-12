namespace bojan3011_ppp_projekat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vozilo")]
    public partial class Vozilo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vozilo()
        {
            Nalogs = new HashSet<Nalog>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VoziloId { get; set; }

        public int KategorijaID { get; set; }

        public int ProizvodjacID { get; set; }

        [Required]
        [StringLength(10)]
        public string BrojRegistracije { get; set; }

        [Required]
        [StringLength(30)]
        public string Model { get; set; }

        public int Godiste { get; set; }

        public double CenaPoDanu { get; set; }

        public virtual KategorijaVozila KategorijaVozila { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nalog> Nalogs { get; set; }

        public virtual Proizvodjac Proizvodjac { get; set; }
    }
}
