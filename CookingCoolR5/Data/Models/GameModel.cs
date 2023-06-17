using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParserHelper.Models
{
    [Table("GamesModels")]
    public class GameModel
    {
        [Key]
        public int Id { get; set; }
        public int Session { get; set; }
        public string Site { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public string Discount { get; set; }
        public string PriceWithoutDiscount { get; set; }
        public string Href { get; set; }
        public DateTime? Created { get; set; }
        public int DiscountInt { get; set; }
        public double PriceDouble { get; set; }
    }
}
