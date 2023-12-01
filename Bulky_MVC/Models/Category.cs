using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky_MVC.Models
{
    public class Category
    {
        #region PROPERTIES
        //Data Annotation = [something], Used to tell EF what a collumn does, Id=PrimaryKey & Name = required
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; } = "";
        [DisplayName("Display Order")]
        [Range(1,100)]
        public int DisplayOrder { get; set; }
        #endregion PROPERTIES
    }
}
