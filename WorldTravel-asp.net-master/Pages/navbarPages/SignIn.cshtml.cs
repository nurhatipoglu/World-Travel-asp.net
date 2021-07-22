using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using city.data.Abstract;
using city.entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorldTravel.Models;

namespace WorldTravel.Pages.navbarPages
{

    public class SignInModel : PageModel
    {

        // Status ve Name de�i�kenleri ba�ar�l� i�lemlerin sonucunda redirect yap�s� ile mesaj� d�nderiyor.
        [BindProperty(SupportsGet = true)]
        public string Status { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        // User repositorye ba�lamak i�in bir nesne olu�turuldu.
        IUser _user;

        // Constructer her �al��t���nda nesne olu�turuluyor.
        public SignInModel(IUser user)
        {
            _user = user;
        }



        [BindProperty]
        public UserDataModel UserData { get; set; }

        public void OnGet()
        {

        }

        // Giri� yap�lan e posta ve �ifre bilgileri veritaban�nda e�le�iyorsa ba�ar�l� bir �ekilde indexe y�nlendirilir
        // Aksi halde hata mesaj� verilerek ayn� sayfada kal�r.
        public IActionResult OnPost()
        {
            string email = UserData.eposta;
            string password = UserData.password;

            User user = new User();
            user = _user.findUser(email, password);

            if(user != null)
            {
                return RedirectToPage("/Index", new { Name = user.name });
            }
            return RedirectToPage("/navbarPages/SignIn", new { Status = "Error"});



        }
    }
}

