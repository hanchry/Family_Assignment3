using System;

namespace Models
{
    public class Username
    {
        private string name;

        public Username(string username)
        {
            if (username == null || username.Length < 3)
            {
                throw new ArgumentException("Username must have at least 3 characters");
            }
            this.name = username;
        }

        public string GetName()
        {
            return name;
        }

         public override string ToString()
        {
            return name;
        }
        
    }
}