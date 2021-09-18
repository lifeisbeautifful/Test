using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public interface IUserData
    {
        public void SetOrChangeUserData(string[] newUserData, params string[] oldUserData);
    }
}
