using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Thing
    {

        

        

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string What { get; set; }
        [Required]
        public string Where { get; set; }
        [Required]
        public string When { get; set; }
        [Required]
        public string How { get; set; }
        [Required]
        public string Why { get; set; }
        [Required]
        public string Title { get; set; }


    }
}



