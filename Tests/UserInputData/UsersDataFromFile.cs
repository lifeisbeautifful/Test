using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Tests.UserInputData
{
    [DataContract]
    public class UsersDataFromFile : IUserData
    {
        private string serializerPath = @"C:\Users\ognyp\source\UserData.json";
        private List<string> UserInputData = new List<string>();

        public string UserName => "admin";
        public string Password => "password";
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public double Salary { get; set; }

        [DataMember]
        public int DurationWorked { get; set; }

        [DataMember]
        public int Grade { get; set; }

        [DataMember]
        public string Email { get; set; }

        public UsersDataFromFile(string name,double salary,int durationWorked,int grade,string email)
        {
            Name = name;
            Salary = salary;
            DurationWorked = durationWorked;
            Grade = grade;
            Email = email;
        }

        public UsersDataFromFile() {; }

        public void SerializeInputDataToFile()
        {
            UsersDataFromFile data = new UsersDataFromFile("Olena",3000,3,3,"a@mailforspam.com");
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(UsersDataFromFile));

            using (FileStream file=new FileStream(serializerPath, FileMode.OpenOrCreate))
            {
                serializer.WriteObject(file, data);
            }  
        }

        public void DeSerializeInputDataFromFile()
        {
            UsersDataFromFile data;
            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(UsersDataFromFile));

            using (FileStream file = new FileStream(serializerPath, FileMode.OpenOrCreate))
            {
                data = (UsersDataFromFile)deserializer.ReadObject(file);
            }

            Name = data.Name;
            Salary = data.Salary;
            DurationWorked = data.DurationWorked;
            Grade = data.Grade;
            Email = data.Email;
        }

        public List<string> SetUserInputsToList()
        {
            UserInputData.Add(Name);
            UserInputData.Add(Salary.ToString());
            UserInputData.Add(DurationWorked.ToString());
            UserInputData.Add(Grade.ToString());
            UserInputData.Add(Email);
            return UserInputData;
        }
    }
}
