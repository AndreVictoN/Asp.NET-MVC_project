using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiapOnSmartCity.Models;

[Table("PRODUCT")]
public class Product
{
    [Key]
    [Column("PROD_ID")]
    public int id { get; set; }

    [Column("PROD_NAME")]
    public string name { get; set; }

    [Column("PROD_DESCRIPTION")]
    public string description { get; set; }

    [Column("PRICE")]
    public double price { get; set; }

    [Column("LOGO")]
    public string logo { get; set; }

    //Foreign Key
    [Column("IDPRODUCT_TYPE")]
    public int productTypeId { get; set; }

    //Navigation Property
    public ProductType productType { get; set; }
}