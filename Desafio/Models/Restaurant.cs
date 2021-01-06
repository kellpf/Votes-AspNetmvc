using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Desafio.Models
{
    [DataContract]
    public class Restaurant : BaseModel
    {
        public Restaurant(int id, string name)
        {
            this.Id_restaurant = id;
            this.Name = name;
        }

        [DataMember]
        public int Id_restaurant { get; set; }
        [DataMember]
        public string Name { get; set; }
    }

}
