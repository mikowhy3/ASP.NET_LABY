using System.Security.Cryptography.X509Certificates;

namespace LAB3_SIWON.Models
{
    public class ContactMapper
    {

        public static ContactEntity ToEntity(ContactModel arg)
        {
            return new ContactEntity
            {
                Id = arg.Id,
                First_Name = arg.First_Name,
                Last_Name = arg.Last_Name,
                BirthDate = arg.BirthDate,
                Email = arg.Email,
                PhoneNumber = arg.PhoneNumber,
                Category = arg.Category

            };


        }


        public static ContactModel FromEntity(ContactEntity arg)
        {
            return new ContactModel
            {
                Id = arg.Id,
                First_Name = arg.First_Name,
                Last_Name = arg.Last_Name,
                BirthDate = arg.BirthDate,
                Email = arg.Email,
                PhoneNumber = arg.PhoneNumber,
                Category = arg.Category
            };

        }
    }
}
