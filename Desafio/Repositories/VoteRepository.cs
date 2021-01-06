using Desafio.Models;
using Desafio.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Repositories
{
    public class VoteRepository
    {

      
        public RestaurantRepository restaurantRepository;
        public VoteRepository(RestaurantRepository restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        public List<Vote> GetVotes()
        {
            var file = $"Files/votes.json";
            var readFile = File.ReadAllText(file);
            var json = JsonConvert.DeserializeObject<List<Vote>>(readFile);

            return json;
        }

        public void InsertVote(Vote vote)
        {
            var file = $"Files/votes.json";
            var votes = GetVotes();
            votes.Add(vote);

            var json = JsonConvert.SerializeObject(votes, Formatting.Indented);

            File.WriteAllText(file, json);
        }

        public void VerifyUserVoted(Vote vote)
        {
            var jsonVotes = GetVotes();

            //retorn true or farse
            var result = jsonVotes.Any(u => u.User_name == vote.User_name && u.Date == vote.Date);
            if (result == true)
            {
                throw new Exception("Você já votou hoje!");
            }
        }
        public void VerifyOldDate(Vote vote)
        {
            DateTime thisDay = DateTime.Today;
            var jsonVotes = GetVotes();
            int result = DateTime.Compare(thisDay, vote.Date);

            //if return =1 is earlier than
            if (result == 1)
            {
                throw new Exception("Não é possível selecionar uma data antiga");
            }
        }
        public void VerifyWeekend(DateTime date)
        {
            var day = (int)date.DayOfWeek;  // 6 - saturday | 0 - sunday
            //var hr = vote.Date.Hour;
            if(day == 6 || day == 0)
            {
                throw new Exception("Não é possível votar no final de semana.");
            }
        }
        
        public void VerifyMidDay(DateTime date)
        {
            DateTime dayAgora = DateTime.Now;
            
            if(dayAgora.Day == date.Day && dayAgora.Hour >= 12)
            {
                throw new Exception("Não é possivel votar após meio dia neste dia");
            }
        }

        public IEnumerable<VoteCount> CountVotes(DateTime date)
        {
            var votes = GetVotes();
            var restaurants = restaurantRepository.GetRestaurants().ToList();

            var r = restaurants.Select(r => new VoteCount
            {
                Restaurant = r,
                Quantidade = votes
               .Where(v => v.Id_restaurant == r.Id_restaurant && v.Date == date)
               .Count(),
                Date = date
            });
            return r;
        }

       
        //public void VerifyMidday(Vote vote)
        //{
        //    DateTime date = DateTime.Today.TryFormat());

        //    if(vote.Date == date && date.Hour > 12)
        //    {
        //        throw new Exception("Não é possível votar após meio dia hoje!");
        //    }
        //}
    }
}
