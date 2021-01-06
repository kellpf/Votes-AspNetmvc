using Desafio.Models;
using Desafio.Repositories;
using Desafio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Bussines
{
    public class Services
    {
        public VoteRepository voteRepository;
      

        public Services(VoteRepository voteRepository)
        {
            this.voteRepository = voteRepository;
     
        }

        public VoteViewModel BaseViewModel(DateTime date)
        {
            var votes = voteRepository.CountVotes(date).ToList();

            return new VoteViewModel(votes, date);
        }

        public VoteViewModel CreateViewModel(DateTime date)
        {
            var baseViewModel = BaseViewModel(date);
            var list = WinnersOfDay(date);

            baseViewModel.Restaurants = baseViewModel.Restaurants.Select(r =>
            {
                
                if (list.Contains(r.Restaurant.Id_restaurant))
                {
                    r.IsReady = false;
                }
                else
                    r.IsReady = true;
                return r;
            }).ToList();
          

            return baseViewModel;

        }
        public List<int> WinnersOfDay(DateTime date)
        {
            var dayWeek = (int)date.DayOfWeek - (int)DayOfWeek.Monday;//quarta(3)-segunda(1) diferenca de dias
            var daysDiferent = date.AddDays(-dayWeek); //

            List<int> winnerList = new List<int>();

            for (int i = 0; i < dayWeek; i++)
            {
                var dates = daysDiferent.AddDays(i);
                var viewModel = CreateViewModel(dates);
                var restaurant = viewModel.WinnerRestaurant();
                if(restaurant != null)
                {
                    winnerList.Add(restaurant.Id_restaurant);
                }

            }
            return winnerList;
        }

    }
}
