using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace HomeworkIS_193064.Domain.Domainmodels
{
    public class Movie : BaseEntity
    {
        [Required]
        [Display(Name = "Наслов на филм")]
        public String Title { get; set; }

        [Required]
        [Display(Name = "Режисер")]
        public String Director { get; set; }

        [Required]
        [Display(Name = "Опис")]
        public String Synopsis { get; set; }

        [Required]
        [Display(Name = "Постер")]
        public String Poster { get; set; }

        [Required]
        [Display(Name = "Жанр")]
        public String Genre { get; set; }

        [Required]
        [Display(Name = "Датум на издавање")]
        public DateOnly ReleaseDate { get; set; }

        [Required]
        public List<Ticket> Tickets { get; set; }

        public Movie()
        {
            Tickets = new List<Ticket>();
        }
    }
}

