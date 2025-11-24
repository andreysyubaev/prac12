using prac12.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace prac12.Validators
{
    public class LoginValid : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (input == string.Empty)
                return new ValidationResult(false, "Ввод поля обязателен");

            if (input.Length < 5)
                return new ValidationResult(false, "Логин пользователя должен состоять минимум из 5 символов");

            using (var db = new AppDbContext())
            {
                bool exists = db.Users
                    .Any(u => u.Login.ToLower() == input.ToLower());

                if (exists)
                    return new ValidationResult(false, "Такой логин уже существует");
            }

            return ValidationResult.ValidResult;
        }
    }
}
