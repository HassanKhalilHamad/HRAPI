namespace HR
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string BuldingNum { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty; 
        public List<Employ> employees { get; set; }

    }
}
