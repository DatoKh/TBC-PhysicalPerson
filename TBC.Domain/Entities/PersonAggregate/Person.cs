using Common.Domain.Seedwork;
using Common.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using TBC.Common.Resources;
using TBC.Domain.Entities.CityAggregate;
using TBC.Domain.Enums;

namespace TBC.Domain.Entities.PersonAggregate
{
    public class Person : BaseEntity<int>
    {

        protected Person()
        {
            PhoneNumbers = new List<PhoneNumber>();
            MainPersonRelatedPeople = new List<RelatedPerson>();
            RelatedPersonRelatedPeople = new List<RelatedPerson>();
        }

        private Person(string personalNumber,
                       string name,
                       string lastname,
                       Gender gender,
                       DateTime birthDate,
                       string image,
                       int cityId) : this()
        {
            PersonalNumber = personalNumber;
            Name = name;
            Lastname = lastname;
            Gender = gender;
            BirthDate = birthDate;
            Image = image;
            CityId = cityId;
        }

        public string PersonalNumber { get; private set; }
        public string Name { get; private set; }
        public string Lastname { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Image { get; private set; }
        public int CityId { get; private set; }
        public virtual City City { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public virtual ICollection<RelatedPerson> MainPersonRelatedPeople { get; set; }
        public virtual ICollection<RelatedPerson> RelatedPersonRelatedPeople { get; set; }

        public static Person Create(string personalNumber,
                                    string name,
                                    string lastname,
                                    Gender gender,
                                    DateTime birthDate,
                                    string image,
                                    int cityId) => new Person(personalNumber, name, lastname, gender, birthDate, image, cityId);

        public void Update(string personalNumber,
                           string name,
                           string lastname,
                           Gender gender,
                           DateTime birthDate,
                           int cityId)
        {
            if (personalNumber != PersonalNumber)
                PersonalNumber = personalNumber;

            if (name != Name)
                Name = name;

            if (lastname != Lastname)
                Lastname = lastname;

            if (gender != Gender)
                Gender = gender;

            if (birthDate != BirthDate)
                BirthDate = birthDate;

            if (cityId != CityId)
                CityId = cityId;
        }

        public void ChangeImage(string image) => Image = image;

        public void AddPhoneNumber(PhoneNumber phoneNumber)
        {
            if(!PhoneNumbers.Any(x => x.Phone == phoneNumber.Phone && x.IsActive))
                PhoneNumbers.Add(phoneNumber);
        }

        public void ChangePhoneNumber(int phoneId, string phone, PhoneNumberType phoneNumberType)
        {
            var phoneNumber = PhoneNumbers.FirstOrDefault(x => x.Id == phoneId && x.IsActive);

            if (phoneNumber == null)
                throw new NotFoundException(StringResource.PhoneNumber, StringResource.Id, phoneId);

            phoneNumber.Update(phone, phoneNumberType);
        }

        public void DeletePhoneNumber(int phoneId)
        {
            var phoneNumber = PhoneNumbers.FirstOrDefault(x => x.Id == phoneId && x.IsActive);

            if (phoneNumber == null)
                throw new NotFoundException(StringResource.PhoneNumber, StringResource.Id, phoneId);

            phoneNumber.Delete();
        }

        public void AddRelatedPerson(Person person, ContactType contactType)
        {
            MainPersonRelatedPeople.Add(RelatedPerson.Create(person, contactType));
        }

        public void UpdateRelatedPerson(int personId, ContactType contactType)
        {
            var relatedPerson = MainPersonRelatedPeople.FirstOrDefault(x => x.Id == personId && x.IsActive);

            if (relatedPerson == null)
                throw new NotFoundException(StringResource.PhoneNumber, StringResource.Id, personId);

            relatedPerson.Update(contactType);
        }

        public void DeleteRelatedPerson(int personId)
        {
            var relatedPerson = MainPersonRelatedPeople.FirstOrDefault(x => x.Id == personId && x.IsActive);

            if (relatedPerson == null)
                throw new NotFoundException(StringResource.PhoneNumber, StringResource.Id, personId);

            relatedPerson.Delete();
        }
    }
}
