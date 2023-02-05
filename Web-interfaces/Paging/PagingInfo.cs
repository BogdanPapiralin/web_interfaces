namespace Web_interfaces.Paging
{
    public class PagingInfo
    {
        // кількість товарів
        public int TotalItems { get; set; }

        // кількість товарів на сторінці
        public int ItemsPerPage { get; set; }

        // Номер сторінки
        public int CurrentPage { get; set; }

        // кількість сторінок
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}
