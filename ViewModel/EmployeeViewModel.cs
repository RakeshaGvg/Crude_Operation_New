using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Crude_Operation1.WEB.ViewModel
{
    public class EmployeeViewModel
    {

        public int EmployeeId { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
       
        public string Designation { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
