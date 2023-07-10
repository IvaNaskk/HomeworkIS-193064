using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeworkIS_193064.Domain.Domainmodels
{
    public class Ticket : BaseEntity
    {
       
        [Required]
        [Display(Name = "Датум")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Сала")]
        public string Hall { get; set; }

        [Required]
        [Display(Name = "Цена")]
        public float Price { get; set; }

        [Required]
        [ForeignKey("Movie")]
        [Display(Name = "Филм")]
        public int MovieId { get; set; }

        [Required]
        public required Movie Movie { get; set; }

        public ICollection<TicketInShoppingCart> TicketInshoppingCart { get; set; }
    }
}

