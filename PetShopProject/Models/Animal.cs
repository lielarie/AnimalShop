using AnimalShopProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShopProject.Models
{
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnimalId { get; set; }

        [Required(ErrorMessage = "An animal without a name?")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Is he ashamed of his age?")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Show us how cute he is")]
        public int PictureId { get; set; }
        public virtual Image Picture { get; set; }

        [Required(ErrorMessage = "Tell us about him")]
        [MinLength(5)]
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }    
    }
}
