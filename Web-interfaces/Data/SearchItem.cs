namespace Web_interfaces.Data
{
    public  class SearchItem
    {
        public static string Genre { get; set; }
        public static string Title { get; set; }
        public static string Author { get; set; }
        public static int MinPrice { get; set; }
        public static int MaxPrice { get; set; }
        public static int MinPages { get; set; }
        public static int MaxPages { get; set; }
        public static int Year { get; set; }

        public SearchItem(string genre, string title, string author, int minPrice, int maxPrice, int minPages, int maxPages, int year)
        {
            Genre = genre;
            Title = title;
            Author = author;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
            MinPages = minPages;
            MaxPages = maxPages;
            Year = year;
        }
    }
}
