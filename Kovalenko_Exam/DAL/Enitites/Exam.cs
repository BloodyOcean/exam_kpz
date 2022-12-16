using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Enitites
{
    public class Exam : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int Mark { get; set; }


        // Navigation properties.
        public virtual Student Student { get; set; }
    }
}
