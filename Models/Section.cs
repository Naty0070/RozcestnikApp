using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RozcestnikApp.Models
{
    public class Section
    {
        
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Reference> References { get; set; } = new List<Reference>();
        public static List<Section> Sections { get; set; }=  new List<Section>();
    }
}
