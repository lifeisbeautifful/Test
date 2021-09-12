using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public interface IsetUserData
    {
        public void SetOrChangeUserData(string[] newUserData, params string[] oldUserData);
    }
}
