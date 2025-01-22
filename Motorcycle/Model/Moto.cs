using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Motorcycle.Model
{
    public class Moto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model { get; set; } = default!;

        [MaxLength(1000)]
        public string Description { get; set; } = default!;

        [Required]
        [MaxLength (100000)]
        public string? Image { get;set; }

        [Required]
        public decimal Price { get; set; }

		[ForeignKey("BrendId")]
		public int BrendId { get; set; }
		public Brend? Brend { get; set; }


        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
