﻿using System.ComponentModel.DataAnnotations;

namespace Abby.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public string Name { get; set; }
        [Display(Name ="Display Order")]
        [Range(1,100,ErrorMessage ="Display oreder must be in range 1-100")]
        public int DisplayOrder { get; set; }
    }
}
