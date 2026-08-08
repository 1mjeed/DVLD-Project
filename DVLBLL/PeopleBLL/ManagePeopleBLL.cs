using DVLDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;

namespace DVLBLL
{
    public class ManagePeopleBLL
    {
        public enum Mode
        {
            addMode = 0, Update = 1
        }
        public Mode mode = Mode.Update;
        public int PersonID { get; set; }
        public string NationalNO { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gendor { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ImagePath { get; set; }
        public int NationalityCountryID { get; set; }
       
        public ManagePeopleBLL()
        {
            this.PersonID = -1;
            this.NationalNO = "";
            this.FirstName = "";
            this.LastName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now.Date;
            this.ImagePath = "";
            this.NationalityCountryID = -1;
            this.Gendor = 0;
            mode = Mode.addMode;
        }
        public ManagePeopleBLL(int personID, string nationalNO, string firstName, string lastName, string secondName, string thirdName, DateTime dateOfBirth, int gendor, string address, string email, string phone, string imagePath, int nationalityCountryID)
        {
            PersonID = personID;
            NationalNO = nationalNO;
            FirstName = firstName;
            LastName = lastName;
            SecondName = secondName;
            ThirdName = thirdName;
            DateOfBirth = dateOfBirth;
            Gendor = gendor;
            Address = address;
            Email = email;
            Phone = phone;
            ImagePath = imagePath;
            NationalityCountryID = nationalityCountryID;
            mode = Mode.Update;

        }
       
        public static DataTable GetAllPepole()
        {
            return (ManagePeopleDAL.GetAllPeople());
        }
        public static ManagePeopleBLL FindPeopleById(int personID)
        {
            string nationalNO = "", firstName = "", lastName = "", secondName = "", thirdName = "" , address = "",  email = "", phone = "", imagePath = "";
            DateTime dateOfBirth = DateTime.Now.Date;  int gendor = 0 ,  nationalityCountryID =-1;

            if (ManagePeopleDAL.FindPeopleById( personID, ref   nationalNO, ref   firstName, ref   lastName, ref   secondName, ref   thirdName, ref   dateOfBirth, ref   gendor, ref   address, ref   email, ref   phone, ref nationalityCountryID, ref   imagePath))
            {
                return new ManagePeopleBLL(personID,nationalNO,firstName,lastName,secondName,thirdName, dateOfBirth,gendor,address,email,phone,imagePath, nationalityCountryID) ;

            }
            else
            {
                return null ;
            }
        }
        public static bool IsExist(int id)
        {
            return ManagePeopleDAL.IsExist(id);
        }
        public static bool IsExist(string nationalNo)
        {
            return ManagePeopleDAL.IsExist(nationalNo);
        }
        public static bool DeletePerson(int id)
        {
            return ManagePeopleDAL.DeletePerson(id);
        }
        private bool _AddPerson()
        {
            this.PersonID = ManagePeopleDAL.AddPerson(this.NationalNO, this.FirstName, this.LastName, this.SecondName, this.ThirdName, this.DateOfBirth, this.Gendor, this.Address, this.Email, this.Phone, this.ImagePath, this.NationalityCountryID);

            return (PersonID != -1);

        }
        private bool _UpdatePerson()
        {
             
            return (ManagePeopleDAL.UpdatePerson(this.PersonID, this.NationalNO, this.FirstName, this.LastName, this.SecondName, this.ThirdName, this.DateOfBirth, this.Gendor, this.Address, this.Email, this.Phone, this.NationalityCountryID, this.ImagePath));
        }
        public bool Save()
        {
            switch (mode)
            {
                case Mode.addMode:
                    if (_AddPerson())
                    {
                        mode = Mode.Update; 
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case Mode.Update:
                    return _UpdatePerson();
            }


            return false; 
        }
    }
}
