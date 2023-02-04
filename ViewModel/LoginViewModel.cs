using System.ComponentModel.DataAnnotations;

namespace EmployeeRep.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool isPressted { get; set; }


    }
}
