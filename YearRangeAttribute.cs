using System.ComponentModel.DataAnnotations;

namespace BookLibraryAPI
{
    public class YearRangeAttribute : ValidationAttribute
    {
        private readonly int _minYear;

        public YearRangeAttribute(int minYear)
        {
            _minYear = minYear;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int year)
            {
                int maxYear = DateTime.Now.Year;

                if (year < _minYear || year > maxYear)
                {
                    return new ValidationResult(
                        $"Year must be between {_minYear} and {maxYear}.");
                }

                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid year format.");
        }
    }
}
