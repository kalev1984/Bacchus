using System.Collections.Generic;

namespace WebApp.Models
{
    public class ItemlistViewModel
    {
        private static readonly List<ItemViewModel> Models = new List<ItemViewModel>();
        
        public static List<ItemViewModel> ViewModels()
        {
            return Models;
        } 
    }
}