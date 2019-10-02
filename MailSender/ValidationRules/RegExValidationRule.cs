using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace MailSender.ValidationRules
{
    public class RegExValidationRule : ValidationRule
    {
        private Regex _Regex;

        public string Pattern
        {
            get => _Regex?.ToString();
            set => _Regex = value is null ? null : value == string.Empty ? null : new Regex(value);
        }

        public bool AllowNull { get; set; } = true;

        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is null)
                return AllowNull
                    ? ValidationResult.ValidResult
                    : new ValidationResult(false, ErrorMessage ?? "Отсутствует ссылка на строку");

            if (_Regex is null) return ValidationResult.ValidResult;

            if (!(value is string str))
                str = value.ToString();

            return _Regex.IsMatch(str)
                ? ValidationResult.ValidResult
                : new ValidationResult(false, ErrorMessage ?? $"Строка не удовлетворяет регулярному выражению {Pattern}");

            //return new ValidationResult(false, "Сообщение об ошибке");
            //return ValidationResult.ValidResult;

            //string null_str1 = null;
            //string null_str2 = null;
            //var s1 = "Hello world";

            //var s = null_str1 ?? null_str2 ?? s1;
            //var s = null_str1;
            //if (s == null) s = null_str2;
            //if (s == null) s = s1;

        }
    }
}
