using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public interface ISetUserData
    {
        public void SetOrChangeUserData(string[] newUserData, params string[] oldUserData);
    }
}
