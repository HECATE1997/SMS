namespace SMS.Models
{
    public class Student : CommonConfigClass
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DOB {  get; set; }

        public string Address {  get; set; }

        public string ImageUrl { get; set; }
    }
}
