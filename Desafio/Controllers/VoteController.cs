using Desafio.Bussines;
using Desafio.Models;
using Desafio.Repositories;
using Desafio.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Controllers
{
    public class VoteController : Controller 
    {
        public RestaurantRepository restaurantRepository;
        public VoteRepository voteRepository;
        public UsersRepository usersRepository;
        public Services services;
        
   

        public VoteController(RestaurantRepository restaurantRepository, VoteRepository voteRepository, UsersRepository usersRepository, Services services)
        {
            this.restaurantRepository = restaurantRepository;
            this.voteRepository = voteRepository;
            this.usersRepository = usersRepository;
            this.services = services;
        }

        [HttpGet]
        public IActionResult Rest([FromQuery] DateTime? date)
        {
            var dateSelect = date ?? DateTime.Today;
            //var data = voteRepository.CountVotes(dateSelect).ToList();

            VoteViewModel voteViewModel = services.CreateViewModel(dateSelect);
            return View(voteViewModel);
        }

        
        [HttpPost]
       public IActionResult PostObj([FromBody]Vote vote)
        {
            try
            {
                voteRepository.VerifyUserVoted(vote);
                voteRepository.VerifyOldDate(vote);
                // voteRepository.VerifyMidday(vote);
                usersRepository.VerifyUser(vote.User_name);
                voteRepository.VerifyMidDay(vote.Date);
                voteRepository.VerifyWeekend(vote.Date);
                services.WinnersOfDay(vote.Date);
                

                voteRepository.InsertVote(vote);
         
                return Ok();
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }


}
