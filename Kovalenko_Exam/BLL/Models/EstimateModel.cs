using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class EstimateModel
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? AssignmentId { get; set; }
        public int? Mark { get; set; }
    }
}
