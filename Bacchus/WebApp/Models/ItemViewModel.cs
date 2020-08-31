using System;
using Domain;

namespace WebApp.Models
{
    public class ItemViewModel
    {
        public ItemViewModel(Auction auction)
        {
            ProductId = auction.ProductId;
            ProductName = auction.ProductName;
            ProductDescription = auction.ProductDescription;
            ProductCategory = auction.ProductCategory;
        }

        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        
        public string TimeLeft { get; set; }
    }
}