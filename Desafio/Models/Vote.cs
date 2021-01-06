using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Desafio.Models
{
    [DataContract]
    public class Vote : BaseModel
    {
        public Vote(DateTime date, int id_restaurant, string nameUser)
        {
            this.Date = date;
            this.Id_restaurant = id_restaurant;
            this.User_name = nameUser;
        }

        [DataMember]
        [Required]
        public DateTime Date { get; set; }
        [DataMember]
        [Required]
        public int Id_restaurant { get; set; }
        [DataMember]
        [Required]
        public string User_name { get; set; }
      
    }
   
}
