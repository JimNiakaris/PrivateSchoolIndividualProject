namespace IndividualProjectB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Courses")]
    public partial class Course

    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            Assignments = new HashSet<Assignment>();
            Students = new HashSet<Student>();
            Trainers = new HashSet<Trainer>();
        }

        [Required]
        [StringLength(50)]
        public string title { get; set; }

        [Required]
        [StringLength(50)]
        public string stream { get; set; }

        [StringLength(50)]
        public string type { get; set; }

        [Column(TypeName = "date")]
        public DateTime? start_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? end_date { get; set; }

        [Key]
        public int courseID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assignment> Assignments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trainer> Trainers { get; set; }

        public override string ToString()
        {

            return ($"Course Info : \n Title | Stream\t\t | Type\t\t | Start Date\t | End Date \n" +
                $"-------------------------------------------------------------------------------------\n" +
                String.Format("{0,6} | {1,-15} | {2,-13} | {3,-13} | {4,-10} ", $"{title}",$"{stream}",$"{type}",$"{start_date.GetValueOrDefault().ToShortDateString()}",$"{end_date.GetValueOrDefault().ToShortDateString()}")+
                "\n");
        }
    }


}
