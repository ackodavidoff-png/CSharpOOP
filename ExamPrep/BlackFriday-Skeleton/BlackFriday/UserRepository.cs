using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday
{
    internal class UserRepository : IRepository<IUser>
    {
        public UserRepository()
        {
        }
        private List<IUser> models = new List<IUser>();
        public IReadOnlyCollection<IUser> Models => models.AsReadOnly();
        public void AddNew(IUser user)
        {
            models.Add(user);
        }
        public IUser GetByName(string name)
        {
            return models.FirstOrDefault(user => user.UserName == name);
        }
        public bool Exists(string name)
        {
            return models.Any(user => user.UserName == name);
        }
    }
}
