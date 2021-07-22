using city.data.Abstract;
using city.entity;
using System.Collections.Generic;
using System.Linq;

namespace city.data.Concrete
{
    // IUserden implement al�n�yor.
    public class UserRepository : IUser
    {
        public void addUser(User user)
        {
            // Entity framework yard�m� ile veritaban�na ba�lan�p user tablosuna gelen user nesnesini ekliyoruz.
            using (var db = new database())
            {
                db.users.Add(user);
                db.SaveChanges();
            }
        }
        public User findUser(string email, string password)
        {
            List<User> _users;
            using (var db = new database())
            {
                // Veritaban� i�erisindeki e postaya g�re linq yap�s� ile filtreleme yaparak gelen veriler i�inde do�ru parolas� olan kullan�c� geri d�nd�r�l�r.
                _users = db.users.Where(i => i.eposta == email).ToList();
                foreach(var item in _users)
                {
                    if(item.password == password)
                    {
                        return item;
                    }
                }
                return null;
            }
        }
    }
}