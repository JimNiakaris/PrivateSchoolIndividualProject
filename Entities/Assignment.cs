namespace IndividualProjectB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Assignment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Assignment()
        {
            Courses = new HashSet<Course>();
        }

        [Required]
        [StringLength(50)]
        public string title { get; set; }

        [StringLength(50)]
        public string description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? sub_date { get; set; }

        public int? oral_mark { get; set; }

        public int? total_mark { get; set; }

        public int assignmentID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> Courses { get; set; }

        public override string ToString()
        {
            return ("Assignment info :\n Title \t\t | Description \t | Submision Date  | Oral Mark | Total Mark |" +
                "\n-----------------------------------------------------------------------------------------------------\n" +
                string.Format("{0,-17}|{1,-15}|{2,-17}|{3,-11}|{4,-10}",$" {title}",$" {description}",$" {sub_date.GetValueOrDefault().ToShortDateString()}",$" {oral_mark}",$" {total_mark}\n"));
        }
    }


}
