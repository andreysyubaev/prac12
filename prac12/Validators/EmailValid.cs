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
    public class EmailValid : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (input == string.Empty)
                return new ValidationResult(false, "Ввод поля обязателен");

            int count = 0;
            foreach (char c in input)
            {
                if (c == '@')
                    count++;
            }

            if (count != 1)
                return new ValidationResult(false, "Поле должно содержать один символ \"@\"");

            using (var db = new AppDbContext())
            {
                bool exists = db.Users
                    .Any(u => u.Email.ToLower() == input.ToLower());

                if (exists)
                    return new ValidationResult(false, "Такой логин уже существует");
            }

            return ValidationResult.ValidResult;
        }
    }
}
