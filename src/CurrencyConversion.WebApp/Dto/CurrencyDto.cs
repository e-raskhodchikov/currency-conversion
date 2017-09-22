namespace CurrencyConversion.WebApp.Dto
{
    public class CurrencyDto
    {
        public int Id { get; set; }

        public string AlphabeticCode { get; set; }

        public string Name { get; set; }

        public string FullName => $"{Name} ({AlphabeticCode})";
    }
}
