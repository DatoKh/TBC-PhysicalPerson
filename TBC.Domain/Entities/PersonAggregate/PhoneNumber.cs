using Common.Domain.Seedwork;
using TBC.Domain.Enums;

namespace TBC.Domain.Entities.PersonAggregate
{
    public class PhoneNumber : BaseEntity<int>
    {
        protected PhoneNumber() { }

        private PhoneNumber(string phone, PhoneNumberType phoneNumberType) : this()
        {
            Phone = phone;
            PhoneNumberType = phoneNumberType;
        }

        public string Phone { get; private set; }
        public PhoneNumberType PhoneNumberType { get; private set; }
        public int PersonId { get; private set; }
        public virtual Person Person { get; set; }

        public static PhoneNumber Create(string phone, PhoneNumberType phoneNumberType) => new PhoneNumber(phone, phoneNumberType);

        public void Update(string phone, PhoneNumberType phoneNumberType)
        {
            if (phone != Phone)
                Phone = phone;

            if (phoneNumberType != PhoneNumberType)
                PhoneNumberType = phoneNumberType;
        }
    }
}
