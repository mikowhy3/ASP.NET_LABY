using LAB4_ASP_SIWON.Models.Services;

namespace LAB4_ASP_SIWON
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // SKOJARZENIE MEMORYCONTACTSERVICE Z INTERFEJSEM, TWORZENIE JEDNEJ INSTANCJI
            // dopytac chatu co to robi
            // implementacja podstawiana w icontactserive 
            // teraz kontroler musi z tego skorzystac wiec musimy wskazac mu aby mogl z tego
            // czerpac
            // kontener to obiekt ktory za nas tworzy instancje klas, dostarcza
            // instancje tam gdzie jest potrzebna, zarzadza nimi
            // taki dzial zatrudniania pracownikow 


            // obiekt typu IContactService ma dostep do wszystkich metod MemoryContactService

            /*
             * U¿ycie AddSingleton w builder.Services.AddSingleton<IContactService,
             * MemoryContactService>() zapewnia, ¿e tylko jedna instancja MemoryContactService 
             * istnieje przez ca³y czas dzia³ania aplikacji.
             */
            // tworzy singleton ale inaczej niz klasyczny wzorzec
            builder.Services.AddSingleton<IContactService,MemoryContactService>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
