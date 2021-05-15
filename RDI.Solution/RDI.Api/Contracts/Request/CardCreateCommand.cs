using System.ComponentModel.DataAnnotations;

namespace RDI.Api.Contracts.Request
{
    public class CardCreateCommand
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public long CardNumber { get; set; }

        [Required]
        [Range(1,99999)]
        public int CVV { get; set; }
    }
}
