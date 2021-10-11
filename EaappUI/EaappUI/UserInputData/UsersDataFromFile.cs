using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;


namespace Eaapp.UserInputData
{
    [DataContract]
    public class UsersDataFromFile : IUserData
    {
        private string _serializerPath = @"C:\Users\ognyp\source\UserData.json";
        private string _name;
        private string _salary;
        private string _durationWorked;
        private string _grade;
        private string _email;

        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
           
        [DataMember]
        public string Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        [DataMember]
        public string DurationWorked 
        {
            get { return _durationWorked; }
            set { _durationWorked = value; }
        }

        [DataMember]
        public string Grade 
        {
            get { return _grade; }
            set { _grade = value; }
        }

        [DataMember]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public UsersDataFromFile(string name, string salary, string durationWorked, string grade, string email)
        {
            _name = name;
            _salary = salary;
            _durationWorked = durationWorked;
            _grade = grade;
            _email = email;
        }

        public UsersDataFromFile() {; }

        public void SerializeInputDataToFile()
        {
            UsersDataFromFile data = new UsersDataFromFile("Olena", "3000", "3", "3", "a@mailforspam.com");
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(UsersDataFromFile));

            using (FileStream file = new FileStream(_serializerPath, FileMode.OpenOrCreate))
            {
                serializer.WriteObject(file, data);
            }  
        }

        public void DeSerializeInputDataFromFile()
        {
            UsersDataFromFile data;
            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(UsersDataFromFile));

            using (FileStream file = new FileStream(_serializerPath, FileMode.OpenOrCreate))
            {
                data = (UsersDataFromFile)deserializer.ReadObject(file);
            }

            _name = data.Name;
            _salary = data.Salary;
            _durationWorked = data.DurationWorked;
            _grade = data.Grade;
            _email = data.Email;
        }
    }
}
