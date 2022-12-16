using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Enitites
{
    public class Estimate : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? AssignmentId { get; set; }
        public int? Mark { get; set; }

        // Navigation properties.
        public virtual Student Student { get; set; }
        public virtual Assignment Assignment { get; set; }
    }
}
