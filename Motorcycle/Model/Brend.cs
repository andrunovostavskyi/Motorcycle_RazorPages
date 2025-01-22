using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Motorcycle.Model
{
    public class Brend
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = default!;

        [MaxLength(1000)]
        public string? History { get; set; }

        [Required]
		[MaxLength(100000)]
		public string? Image { get; set; }
        public List<Moto> Motorcyclies { get; set; } = default!;
    }
}
