using System.ComponentModel.DataAnnotations;

namespace BankApi.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }


    }
 
    
}
