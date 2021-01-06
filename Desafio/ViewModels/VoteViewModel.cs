using Desafio.Models;
using Desafio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.ViewModels
{
    public class VoteViewModel
    {
        public VoteViewModel(List<VoteCount> Restaurants, DateTime Date)
        {
            this.Restaurants = Restaurants;
            this.Date = Date;

        }

        public List<VoteCount> Restaurants { set; get; }

        public Users User { set; get; }
        public DateTime Date { set; get; }
        public List<Users> Users { set; get; }

        public Restaurant WinnerRestaurant()
        {
            var votes = Restaurants.Where(r => r.IsReady).Max(r => r.Quantidade);
            var rest = Restaurants.Where(r => r.Quantidade == votes && r.IsReady == true);

            if(votes == 0)
            {
                return null;
            }
           
            return rest.First().Restaurant;
        }

       
    }
}
