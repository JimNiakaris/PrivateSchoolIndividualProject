namespace IndividualProjectB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            Courses = new HashSet<Course>();
        }

        [Required]
        [StringLength(50)]
        public string first_name { get; set; }

        [Required]
        [StringLength(50)]
        public string last_name { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_of_birth { get; set; }

        public decimal? tuitions { get; set; }

        public int studentID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> Courses { get; set; }

        public override string ToString()
        {
            return ($"Student info:\n First Name \t |  Last Name \t\t | Birth Date  \t| Tuitions | \n" +
                $"-------------------------------------------------------------------------------------\n" +
                string.Format("{0,-17}|{1,-23}|{2,-16} {3,-20}",$" {first_name}",$" {last_name}",$" {date_of_birth.ToShortDateString()}",$"{tuitions}\n"));
        }
    }
}
