using System.ComponentModel.DataAnnotations;

namespace RDI.Api.Contracts.Request
{
    public class ValidateCommand
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int CardId { get; set; }
        
        [Required]
        public long Token { get; set; }

        [Required]
        [Range(1, 99999)]
        public int CVV { get; set; }
    }
}
