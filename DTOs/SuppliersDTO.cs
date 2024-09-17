using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class SuppliersDTO
    {
        public int Id { get; set; }
        public string NIT { get; set; }
        public string CompanyName { get; set; }
        public string Addres { get; set; }
        public string City { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime DateCreated { get; set; }
        public string ContactName { get; set; }
        public string EmailContact { get; set; }
    }

    public class SupplierCreateDTO
    {
        [Required]
        public string NIT { get; set; }

        [Required]
        public string CompanyName { get; set; }

        public string Addres { get; set; }
        public string City { get; set; }
        public string Department { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public bool Active { get; set; }

        [Required]
        public string ContactName { get; set; }

        [EmailAddress]
        public string EmailContact { get; set; }
    }

    public class SupplierUpdateDTO
    {
        [Required]
        public string NIT { get; set; }

        [Required]
        public string CompanyName { get; set; }

        public string Addres { get; set; }
        public string City { get; set; }
        public string Department { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public bool Active { get; set; }

        [Required]
        public string ContactName { get; set; }

        [EmailAddress]
        public string EmailContact { get; set; }
    }
    public class SupplierDeleteDTO
    {
        public string NIT { get; set; }
        public string CompanyName { get; set; }
    }
}
