using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBookMVC.Models
{
    public class Contact
    {
        //had to make some inputs Null in pgAdmin 4 - Edit -> Constraints not NULL
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string? Address1 { get; set; }

        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }

        [DataType(DataType.PostalCode)]
        public string? PostalCode { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }

        [NotMapped]
        public DateTime? Created { get; set; }

        [NotMapped]
        [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        public IFormFile? ImageFile { get; set; }

        public byte[]? ImageData { get; set; }

        public string? ImageType { get; set; }

        public int Id { get; set; }

        [NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}";  } }


    }
}
