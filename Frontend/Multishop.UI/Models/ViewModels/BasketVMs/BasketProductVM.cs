using System.ComponentModel.DataAnnotations.Schema;

namespace Multishop.UI.Models.ViewModels.BasketVMs
{
    public class BasketProductVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice => Amount * Price;
    }
}