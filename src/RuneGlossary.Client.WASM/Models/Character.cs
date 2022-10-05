using RuneGlossary.Api.Responses;
using System.ComponentModel;
using System.Globalization;

namespace RuneGlossary.Client.WASM.Models
{
    public class Character
    {
        public int Id { get; }

        [TypeConverter(nameof(ClassConverter))]
        public Class? Class { get; set; }
        public string? Name { get; set; }
        public int? Level { get; set; }
        public IEnumerable<int> Runes { get; set; }

        public Character(int id)
        {
            Id = id;
        }
    }

    public class ClassConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
        {
            return (destinationType is not null && destinationType.Equals(typeof(string))) || base.CanConvertTo(context, destinationType);
        }

        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            if (destinationType.Equals(typeof(string))
                && value is not null && value is Class @class) return @class.Id;

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
