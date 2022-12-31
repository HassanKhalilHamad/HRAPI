using System.ComponentModel.DataAnnotations.Schema;

namespace HR
{
    public class Employ
    {
        public int EmployId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Age { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int BranchId { get; set; }
        public Branch branch { get; set; }
        

    }
}
