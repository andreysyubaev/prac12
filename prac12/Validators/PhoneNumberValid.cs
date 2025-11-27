using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace prac12.Validators
{
    public class PhoneNumberValid : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = value as string;

            if (string.IsNullOrWhiteSpace(input))
                return new ValidationResult(false, "Ввод поля обязателен");

            if (!input.All(char.IsDigit))
                return new ValidationResult(false, "Номер должен содержать только цифры");

            if (input.Length != 11)
                return new ValidationResult(false, "Номер должен состоять из 11 цифр");

            return ValidationResult.ValidResult;
        }
    }
}
