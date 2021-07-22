using city.entity;

namespace city.data.Abstract
{
    // User interfacesi kullan�lan metotlar�n aray�z�
    public interface IUser
    {

        // Kullan�c� ekleme metodunun aray�z�.
         void addUser(User user);

        // Kullan�c� giri� ekran�nda kay�tl� kullan�c� sorgusu i�in fonksiyon
        User findUser(string email, string password);
    }
}