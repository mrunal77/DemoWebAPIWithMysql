namespace Demo_Web_API.DTO
{
    public class BookRequestBody
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public int Pages { get; set; }
        public string Publisher { get; set; }
    }
}
