﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BulkyWeb_Temp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
