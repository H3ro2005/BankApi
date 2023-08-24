using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BankApi.Models
{
    public class BankCard
    {
        [Key]
        public int Id { get; set; }
        public int CardId { get; set; }
        public required string CardName { get; set; }
        public required string CardCode { get; set; }
    }
}
