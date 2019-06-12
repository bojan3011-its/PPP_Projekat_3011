namespace bojan3011_ppp_projekat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KategorijaVozila")]
    public partial class KategorijaVozila
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KategorijaVozila()
        {
            Voziloes = new HashSet<Vozilo>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KategorijaId { get; set; }

        [Required]
        [StringLength(1)]
        public string Oznaka { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vozilo> Voziloes { get; set; }
    }
}
