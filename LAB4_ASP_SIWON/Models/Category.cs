using System.ComponentModel.DataAnnotations;

namespace LAB4_ASP_SIWON.Models
{
    public enum Category
    {
        // nazwa w formularzu stalej, daje tez mozliwosc ustalenia kolejnosci
        // nad kazda wlasnoscia dajemy nazwe
        // oraz order id
        [Display(Name = "Rodzina", Order = 1)]
        Family,
        [Display(Name = "Znajomi", Order = 2)]
        Friends,
        [Display(Name = "Kontakt Zawodowy", Order = 3)]
        Business

    }
}
