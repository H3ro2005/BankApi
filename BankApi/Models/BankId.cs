using System.ComponentModel.DataAnnotations;

namespace BankApi.Models
{
    public class BankId
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public double dramtorubl { get; set; }
        public double dramtoeuro { get; set; }
        public double dramtodollar { get; set; }
        public double rubltodram { get; set; }
        public double eurotodram { get; set; }
        public double dollartodram { get; set; }


    }
}
