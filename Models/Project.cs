using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRep.Models
{
    public class Project
    {
        [Key]
        public int Number { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }

        [ForeignKey("Department")]
        public int? DeptNum { get; set; }
        public virtual Department? Department { get; set; }

        public virtual List<WorksOnProject>? WorksOnProjects { get; set; }



    }
}
