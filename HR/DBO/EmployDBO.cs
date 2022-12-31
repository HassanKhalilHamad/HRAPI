namespace HR.DBO
{
    public class EmployDBO
    {
        public int EmployId { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Age { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int BranchId { get; set; }
    }
}
