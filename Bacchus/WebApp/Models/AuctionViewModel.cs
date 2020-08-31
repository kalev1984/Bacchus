using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models
{
    public class AuctionViewModel
    {
        public List<ItemViewModel> ItemList { get; set; }
        
        public string Category { get; set; }
        public SelectList CategoriesSelectList { get; set; }
    }
}