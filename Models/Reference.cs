using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RozcestnikApp.Models
{
    public class Reference
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public int Order { get; set; }

        public int SectionId { get; set; }






    }
}
