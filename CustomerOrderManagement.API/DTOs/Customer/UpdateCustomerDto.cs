namespace CustomerOrderManagement.API.DTOs.Customer
{
    public class UpdateCustomerDto
    {
        public Guid Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
    }
}
