using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //[Min18YearsOld]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}
