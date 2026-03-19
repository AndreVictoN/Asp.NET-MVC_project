using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiapOnSmartCity.Models;

[Table("PRODUCT_TYPE")]
public class ProductType
{
    [Key]
    [Column("IDPRODUCT")]
    public int id { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 50 characters.")]
    [Column("PROD_DESCRIPTION")]
    public string description { get; set; }

    [Column("IS_COMERCIALIZED")]
    public bool isComercialized { get; set; }

    //Navigation Property
    public List<Product> products { get; set; }
}