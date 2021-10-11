using System;


namespace Eaapp
{
    public class UsersData : IUserData, IEquatable<UsersData>
    {

        public string Name { get; set; }
        public string Salary { get; set; }
        public string DurationWorked { get; set; }
        public string Grade { get; set; }
        public string Email { get; set; }
        
        public bool Equals(UsersData obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
            {
                return Name == obj.Name && Salary == obj.Salary && DurationWorked == obj.DurationWorked
                       && Grade == obj.Grade && Email == obj.Email;
            }
        }

        public override bool Equals(object obj) => Equals(obj as UsersData);
    }
}
