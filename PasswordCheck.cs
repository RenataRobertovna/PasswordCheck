using System;

namespace PasswordCheck
{
    public delegate void Message(string message);

    public class PasswordCheck
    {
        public event Message Error;
        public event Message Success;

        private readonly string symbols1;
        private readonly string symbols2;
        private readonly string symbols3;
        private readonly string symbols4;
        
        private readonly string symbols;
        private readonly int passwordLength;

        public PasswordCheck()
        {
            symbols1 = "QWERTYUIOPASDFGHJKLZXCVBNM";
            symbols2 = "qwertyuiopasdfghjklzxcvbnm";
            symbols3 = "!@#$%^&*:;.,-_";
            symbols4 = "0123456789";

            symbols = symbols1 + symbols2 + symbols3 + symbols4;

            passwordLength = 8;
        }

        public bool CheckLength(string password)
        {
            password = password.Trim();

            if (password.Length < passwordLength)
            {
                Error?.Invoke($"Длина пароля меньше {passwordLength} символов");
                return false;
            } 
            else
            {
                Success?.Invoke($"Длина пароля соответствует минимальной длинне");
                return true;
            }
        }

        public bool CheckSymbol(string password)
        {
            int pass_chek1 = password.IndexOfAny(symbols1.ToCharArray());
            int pass_chek2 = password.IndexOfAny(symbols2.ToCharArray());
            int pass_chek3 = password.IndexOfAny(symbols3.ToCharArray());
            int pass_chek4 = password.IndexOfAny(symbols4.ToCharArray());

            if (pass_chek1 == -1 || pass_chek2 == -1 || pass_chek3 == -1 || pass_chek4 == -1)
            {
                Error?.Invoke("Пароль не соответствует требованиям безопасности");
                return false;
            }
            else
            {
                Success?.Invoke("Пароль соответствует минимальным требованиям");
                return true;
            }
        }

        public bool CheckAlphabet(string password)
        {
            foreach (var symbol in password)
            {
                if (!symbols.Contains(symbol))
                {
                    Error?.Invoke("Пароль содержит запрещённые символы");
                    return false;
                }
            }
            Success?.Invoke("Пароль не содержит запрещённые символы");
            return true;
        }
    }
}