using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmsBackend.ViewModels
{
    public class StudentViewModel
    {
        
        public int UserId { get; set; }

        
        public string FName { get; set; } = null!;

       
        public string LName { get; set; } = null!;

        
        public string Password { get; set; } = null!;

       
        public int UserRole { get; set; }

      
        public DateTime Dob { get; set; }

        public string Contact { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
