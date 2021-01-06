using Desafio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Models
{
    public class VoteCount
    {
        public VoteCount()
        {
            
        }

        public int Quantidade { get; set; }
        public Restaurant Restaurant { get; set; }
        public DateTime Date { get; set; }
        public bool IsReady { get; set; }

        public double CalculaPercete(int totalVotes)
        {
            if (totalVotes > 0)
                return ((double)Quantidade / (double)totalVotes) * 100;
            else
                return 0;
        }

        

    }
}
