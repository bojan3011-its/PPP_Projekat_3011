namespace bojan3011_ppp_projekat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Klijent")]
    public partial class Klijent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Klijent()
        {
            Nalogs = new HashSet<Nalog>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KlijentId { get; set; }

        public int DrzavaID { get; set; }

        [Required]
        [StringLength(15)]
        public string Ime { get; set; }

        [Required]
        [StringLength(20)]
        public string Prezime { get; set; }

        [Required]
        [StringLength(15)]
        public string BrojLD { get; set; }

        [Required]
        [StringLength(15)]
        public string BrojNVD { get; set; }

        [StringLength(15)]
        public string BrojMVD { get; set; }

        public virtual Drzava Drzava { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nalog> Nalogs { get; set; }
    }
}
