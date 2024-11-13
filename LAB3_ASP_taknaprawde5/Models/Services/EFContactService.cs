
using Microsoft.EntityFrameworkCore;

namespace LAB3_SIWON.Models.Services
{
    public class EFContactService : IContactService
    {


        private readonly AppDbContext _context;

        public EFContactService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(ContactModel contact)
        {
            _context.Contacts.Add(ContactMapper.ToEntity(contact));
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Contacts.Remove(new ContactEntity() { Id = id });
            _context.SaveChanges();
        }

        public List<ContactModel> GetAll()
        {
            return _context.Contacts
                .Include(e=>e.Organization)
                .Select(e => ContactMapper.FromEntity(e))
                .ToList();

        }

        public List<OrganizationEntity> GetAllOrganizaios()
        {
            return _context.Organizations.ToList();
        }

        public ContactModel? GetById(int id)
        {
            var entity=_context.Contacts.Include(c=>c.Organization).FirstOrDefault(c=>c.Id==id)
                ;
            return entity != null ? ContactMapper.FromEntity(entity) : null;
        }

        public void Update(ContactModel contact)
        {
            _context.Contacts.Update(ContactMapper.ToEntity(contact));
            _context.SaveChanges();
        }
    }
}
