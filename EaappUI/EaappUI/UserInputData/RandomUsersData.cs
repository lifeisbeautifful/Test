using System;


namespace Eaapp.UserData
{
    public class RandomUsersData : IUserData
    {
        private string _name;
        private string _salary;
        private string _durationWorked;
        private string _grade;
        private string _email;
      
        private char[] letters = "ABCDEFGHIJKLMNOPQURSTUVWXYZ".ToCharArray();
        Random random = new Random();

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        public string Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
      
        public string DurationWorked
        {
            get { return _durationWorked; }
            set { _durationWorked = value; }
        }
       
        public string Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }
       
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
       
        public RandomUsersData()
        {
            _name = GetRandomName();
            _salary = GetRandomSalary().ToString();
            _durationWorked = GetRandomDurationWorked().ToString();
            _grade = GetrandomGrade().ToString();
            _email = GetRandomEmail();
        }
        private string GetRandomName()
        {
            for (int i = 0; i < 5; i++)
            {
                int charNumber = random.Next(0, letters.Length - 1);
                _name += letters[charNumber];
            }
            return _name;
        }

        private double GetRandomSalary()
        {
            double randomSalary = random.Next(0, 10000);
            return randomSalary;
        }

       private int GetRandomDurationWorked()
       {
            int randomDurationWorked = random.Next(1, 10);
            return randomDurationWorked;
       }

        private int GetrandomGrade()
        {
            int randomGrade = random.Next(0, 5);
            return randomGrade;
        }
       
       private string GetRandomEmail()
        {
            for(int i = 0; i < 11; i++)
            {
                if (i == 5)
                {
                    _email += "@";
                }

                if (i == 8)
                {
                    _email += ".";
                }

                int charNumber = random.Next(0, letters.Length - 1);
                _email += letters[charNumber];
            }
            return _email;
        }
    }
}
