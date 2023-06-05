using System;
using System.Globalization;
using System.Text;

namespace ConverterDictionaryAggregation
{
    /// <summary>
    /// Converts a real number to string.
    /// </summary>
    public class Converter
    {
        private readonly CharsDictionary charsDictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="Converter"/> class.
        /// </summary>
        /// <param name="charsDictionary">The dictionary with rules of converting.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when dictionary is null.</exception>
        /// <exception cref="System.ArgumentException">Thrown when charsDictionary.Dictionary is empty.</exception>
        public Converter(CharsDictionary charsDictionary)
        {
            this.charsDictionary = charsDictionary ?? throw new ArgumentNullException(nameof(charsDictionary));
            if (this.charsDictionary.Dictionary == null || this.charsDictionary.Dictionary.Count == 0)
            {
                throw new ArgumentException("The dictionary is empty.", nameof(charsDictionary));
            }
        }

        /// <summary>
        /// Converts double number into string.
        /// </summary>
        /// <param name="number">Double number to convert.</param>
        /// <returns>A number string representation.</returns>
        public string Convert(double number)
        {
            return double.IsNaN(number) || double.IsInfinity(number) || number == double.Epsilon ? this.ConvertSpecial(number) : this.ConvertNumber(number);
        }

        private string ConvertNumber(double number)
        {
            StringBuilder sb = new StringBuilder();

            var strNum = number.ToString(new CultureInfo(this.charsDictionary.CultureName!));

            foreach (var ch in strNum)
            {
                sb.Append(ch switch
                {
                    '0' => this.charsDictionary.Dictionary![Character.Zero],
                    '1' => this.charsDictionary.Dictionary![Character.One],
                    '2' => this.charsDictionary.Dictionary![Character.Two],
                    '3' => this.charsDictionary.Dictionary![Character.Three],
                    '4' => this.charsDictionary.Dictionary![Character.Four],
                    '5' => this.charsDictionary.Dictionary![Character.Five],
                    '6' => this.charsDictionary.Dictionary![Character.Six],
                    '7' => this.charsDictionary.Dictionary![Character.Seven],
                    '8' => this.charsDictionary.Dictionary![Character.Eight],
                    '9' => this.charsDictionary.Dictionary![Character.Nine],
                    '+' => this.charsDictionary.Dictionary![Character.Plus],
                    '-' => this.charsDictionary.Dictionary![Character.Minus],
                    '.' => this.charsDictionary.Dictionary![Character.Point],
                    ',' => this.charsDictionary.Dictionary![Character.Comma],
                    'E' => this.charsDictionary.Dictionary![Character.Exponent],
                    _ => throw new ArgumentException("Unknown character."),
                });
                sb.Append(' ');
            }

            return sb.ToString().Trim();
        }

        private string ConvertSpecial(double number) =>
            number switch
            {
                double.NaN => this.charsDictionary.Dictionary![Character.NaN],
                double.PositiveInfinity => this.charsDictionary.Dictionary![Character.PositiveInfinity],
                double.NegativeInfinity => this.charsDictionary.Dictionary![Character.NegativeInfinity],
                double.Epsilon => this.charsDictionary.Dictionary![Character.Epsilon],
                _ => string.Empty,
            };
    }
}
