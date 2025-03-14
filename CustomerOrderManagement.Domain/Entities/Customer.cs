namespace CustomerOrderManagement.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; private set; }  
        public string FirstName { get;  set; }  
        public string LastName { get;  set; } 
        public string Address { get;  set; }
        public string PostalCode { get;  set; }

        public string FullName => $"{FirstName} {LastName}";


        public List<Order> Orders { get;  set; } = new List<Order>();  

        public Customer(string firstName, string lastName, string address, string postalCode)
        {
            Id = Guid.NewGuid();  
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PostalCode = postalCode;
        }
    }
}