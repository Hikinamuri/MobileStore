using System.Numerics;

namespace WebApplication2rrr.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; } 
        public User User { get; set; }
        public string Address { get; set; }
        public string ContactTelephone { get; set; }
        public int PhoneId { get; set; }
        public Phone Phone { get; set; }

        /*public Order(int UserId, User User,  string Address, string ContactTelephone,int PhoneId, Phone Phone)
        {
            this.UserId = UserId;
            this.User = User;
            this.Address = Address;
            this.ContactTelephone = ContactTelephone;
            this.PhoneId = PhoneId; 
            this.Phone = Phone;

        }*/
    }
}
