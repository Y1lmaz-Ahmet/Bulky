﻿using System.ComponentModel.DataAnnotations;

namespace Bulky_MVC.Models
{
    public class Category
    {
        #region PROPERTIES
        //Data Annotation = [something], Used to tell EF what a collumn does, Id=PrimaryKey & Name = required
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        #endregion PROPERTIES
    }
}
