using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practic5.Models;

namespace practic5
{
    internal class Helper
    {
        private static furniture_centreEntities _context;

        public static furniture_centreEntities GetContext()
        {
            if (_context == null)
            {
                _context = new furniture_centreEntities();
            }
            return _context;
        }

        public void CreateUser(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        private void UpdateUser(User user)
        {
            _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveUser(int idUser)
        {
            var users = _context.User.Find(idUser);
            _context.User.Remove(users);
            _context.SaveChanges();
        }

        public List<User> FiltrUsers()
        {
            return _context.User.OrderBy(x => x.Login.StartsWith("M") || x.Login.StartsWith("A")).ToList();
        }

        public List<User> SortUsers()
        {
            return _context.User.OrderBy(x => x.Login).ToList();
        }

        public string GetUserTypes(Employee employee)
        {
            
            return employee.Job_title.Name.ToString();
        }
    }
}
