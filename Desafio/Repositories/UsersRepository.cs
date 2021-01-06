using Desafio.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Repositories
{
    public class UsersRepository
    {
        public UsersRepository()
        {
        }

        public List<Users> GetUsers()
        {
            var file = $"Files/users.json";
            var readFile = File.ReadAllText(file);
            var json = JsonConvert.DeserializeObject<List<Users>>(readFile);
            return json;
        }
        
        public void VerifyUser(string user)
        {
            var jsonUsers = GetUsers();
            var result = jsonUsers.Any(u => u.User_name == user);
            
            if(result == false)
            {
                throw new Exception("Este usuário não existe.");
            }
        }
    }

   
}
