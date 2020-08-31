using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AuctionsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAppUnitOfWork _uow;

        public AuctionsController(IConfiguration configuration, IAppUnitOfWork uow)
        {
            _configuration = configuration;
            _uow = uow;
        }

        // GET
        public async Task<IActionResult> Index(AuctionViewModel vm)
        {
            var url = _configuration.GetValue<string>("API_url");
            var currentAuctions = JsonConvert.DeserializeObject<List<Auction>>
                (await new HttpClient().GetStringAsync(url));
            
            ItemlistViewModel.ViewModels().Clear();
            var categories = new HashSet<string>();
            
            foreach (var a in currentAuctions)
            {
                var item = new ItemViewModel(a);
                var timeLeft = a.BiddingEndDate.Subtract(DateTime.UtcNow);
                item.TimeLeft = timeLeft.ToString(@"hh\:mm\:ss" );
                ItemlistViewModel.ViewModels().Add(item);
                categories.Add(a.ProductCategory);
            }
            vm!.ItemList = ItemlistViewModel.ViewModels();
            vm.CategoriesSelectList = new SelectList(categories);
            return View(vm);
        }
        
        public Task<IActionResult> Bidding(Guid id)
        {
            var viewModel = ItemlistViewModel.ViewModels().Find(x => x.ProductId == id);
            if (viewModel == null)
            {
                return Task.FromResult<IActionResult>(RedirectToAction(nameof(Index)));
            }
            var bid = new Bidding {AuctionId = id};
            return Task.FromResult<IActionResult>(View(bid));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Bidding(Bidding currentBidding)
        {
            currentBidding.BiddingTime = DateTime.Now;
            var existingBid = await _uow.Biddings.FindAsync(currentBidding.AuctionId);
            if (existingBid == null)
            {
                if (ModelState.IsValid)
                {
                    await _uow.Biddings.AddAsync(currentBidding);
                    await _uow.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                } 
            }
            else
            {
                if (existingBid.Bid < currentBidding.Bid)
                {
                    _uow.Biddings.Update(currentBidding);
                    await _uow.SaveChangesAsync();
                }
            }
            return View();
        }
    }
}