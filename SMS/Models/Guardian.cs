using SMS.Enums;

namespace SMS.Models
{
    public class Guardian : CommonConfigClass
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DocumentType DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Province Province { get; set; }
        public District District { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

    }
}
