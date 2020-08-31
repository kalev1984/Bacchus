using System;

namespace Domain
{
    public class Auction
    {
        public Guid ProductId { get; set; } 
        public string ProductName { get; set; } 
        public string ProductDescription { get; set; } 
        public string ProductCategory { get; set; } 
        public DateTime BiddingEndDate { get; set; }
    }
}