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
    public class BirthdayValid : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "Дата обязательна");

            DateTime date;
            bool isValid = DateTime.TryParse(value.ToString(), out date);

            if (!isValid)
                return new ValidationResult(false, "Неверный формат даты");

            if (date < DateTime.Today)
                return new ValidationResult(false, "Дата не может быть раньше сегодняшней");

            return ValidationResult.ValidResult;
        }
    }
}
