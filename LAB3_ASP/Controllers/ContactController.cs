using LAB3_SIWON.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace LAB3_SIWON.Controllers
{
    public class ContactController : Controller
    {
        //Lista kontaktow
        public IActionResult Index()
        {
            return View(contacts);
        }

        public IActionResult Delete(int id)
        {
            contacts.Remove(id);
            return View("Index", contacts);
        }

		public IActionResult Details(int id)
		{
            //W tym miejscu contacts[id] zwraca pojedynczy obiekt
            //ContactModel, który jest przekazywany jako model do widoku.
            return View(contacts[id]);
		}

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!contacts.ContainsKey(id))
            {
                return NotFound(); // Zwracamy 404, jeśli kontakt nie istnieje
            }

            // Przekazujemy dane kontaktu do widoku Edit.cshtml
            // to ze tutaj jest contacts[id] powoduje ze basicowo do
            //formularza przekazywane sa dane z id. bez tego bylyby 
            // puste pola bez aktualnych danych
            return View(contacts[id]);
        }

        [HttpPost]
        public IActionResult Edit(ContactModel model)
        {
            // Sprawdzamy poprawność modelu
            if (!ModelState.IsValid)
            {
                return View(model); // Zwracamy formularz z błędami walidacyjnymi
            }

            // Sprawdzamy, czy kontakt istnieje
            if (!contacts.ContainsKey(model.Id))
            {
                return NotFound(); // Zwracamy 404, jeśli kontakt nie istnieje
            }

            // Aktualizacja danych kontaktu
            contacts[model.Id] = model;

            // Powrót do widoku listy kontaktów
            return View("Index", contacts);
        }


        private static Dictionary<int, ContactModel> contacts = new()
        {
            {
                
                1, new ContactModel()
                {
                    Id=1,
                    First_Name="Asia",
                    Last_Name="Klawka",
                    Email="email@gmail.com",
                    PhoneNumber="111 222 333",
                    BirthDate= new DateOnly(year:2000,month:10,day:3)
                }
 
            },
            {

                 2, new ContactModel()
                {
                    Id=2,
                    First_Name="Kasia",
                    Last_Name="Klawka",
                    Email="email@gmail.com",
                    PhoneNumber="234 192 222",
                    BirthDate= new DateOnly(year:2001,month:10,day:4)
                }
            },
            {
                 3, new ContactModel()
                {
                    Id=3,
                    First_Name="Basia",
                    Last_Name="Plawka",
                    Email="email@gmail.com",
                    PhoneNumber="273 928 012",
                    BirthDate= new DateOnly(year:2003,month:11,day:30)
                }
            }
        };


        // potrzebujemy znac ostatni id aby dodajac sie nie zdublowal
        private static int _cureentId = 3;

        // formularz dodania kontaktu
        [HttpGet]
        public IActionResult Add()
        {

            //TODO dodanie kontaktu do kolekcji
            return View();
        }

        // odebranie danyc z formularza, zapis kontaktu i powrot do listy kontaktow
        [HttpPost]
        public IActionResult Add(ContactModel model)
        {
            // jesli model niepoprawny to zwracamy formularz
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            // zapisanie danych, powrot do widoku listy

            //return View("Index", contacts);: jawnie określasz,
            //że chcesz użyć widoku "Index"
            //i przekazujesz mu model contacts.
            model.Id = ++_cureentId;
            contacts.Add(model.Id, model);

            return View("Index",contacts);
        }


    }
}
