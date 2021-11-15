using System;

namespace Models
{
    public class Password
    {
        private string password;

        public Password(string password)
        {
            if (password == null)
            {
                throw new ArgumentException("Enter password");
            }

            string message = IsLegal(password);
            if (message != null)
            {
                throw new ArgumentException(message);
            }

            this.password = password;
        }

        public static bool IsLegalPassword(string password)
        {
            return IsLegal(password) == null;
        }

        private static string IsLegal(string password)
        {
            if (password == null || password.Length < 6)
            {
                return "Password must have at least 6 characters";
            }

            int lower = 0;
            int upper = 0;
            int digit = 0;
            int special = 0;
            for (int i = 0; i < password.Length; i++)
            {
                char ch = password[i];
                if (char.IsDigit(ch))
                {
                    digit++;
                }
                else if (char.IsLower(ch) && char.IsLetter(ch))
                {
                    lower++;
                }
                else if (char.IsUpper(ch) && char.IsLetter(ch))
                {
                    upper++;
                }
                else if (ch == '_' || ch == '-')
                {
                    special++;
                }
            }

            if (lower + upper + digit + special < password.Length)
            {
                return "Password may only contain letters, digits, hyphens and underscore characters";
            }

            if (lower == 0 || upper == 0 || digit == 0)
            {
                return
                    "Password must contain at least one uppercase letter, at least one lowercase letter and at least one digit";
            }

            return null;
        }

        public string GetPassword()
        {
            return password;
        }

        public override string ToString()
        {
            return password;

        }
    }
}