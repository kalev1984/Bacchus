using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Bidding : BaseEntity
    {
        [MinLength(2), MaxLength(50), Required] public string FirstName { get; set; } = default!;

        [MinLength(3), MaxLength(50), Required] public string LastName { get; set; } = default!;

        public Guid AuctionId { get; set; }

        public DateTime BiddingTime { get; set; }

        [Range(0, int.MaxValue)] public int Bid { get; set; } = default!;
    }
}