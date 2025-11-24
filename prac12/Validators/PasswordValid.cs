using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace prac12.Validators
{
    public class PasswordValid : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (input == string.Empty)
                return new ValidationResult(false, "Ввод поля обязателен");

            if (input.Length < 8)
                return new ValidationResult(false, "Пароль должен включать быть из минимум 8 символов");

            bool allLower = input.All(char.IsLower);
            bool allUpper = input.All(char.IsUpper);

            if (allLower)
                return new ValidationResult(false, "Пароль должен включать буквы в верхнем и нижнем регистре");

            if (allUpper)
                return new ValidationResult(false, "Пароль должен включать буквы в верхнем и нижнем регистре");

            if (!Regex.IsMatch(input, "[0-9]"))
                return new ValidationResult(false, "Пароль должен включать цифры");

            if (!Regex.IsMatch(input, "[!@#$%^&*()_+=\\-{}\\[\\]:;\"'<>,.?/]"))
                return new ValidationResult(false, "Пароль должен включить символы");

            return ValidationResult.ValidResult;
        }
    }
}
