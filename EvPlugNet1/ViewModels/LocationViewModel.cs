namespace EvPlugNet1.ViewModels
{
    public class LocationViewModel
    {

        public string ChargePointId { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ClientCertThumb { get; set; }
        public string TagId { get; set; }
        public string TagName { get; set; }
        public string ParentTagId { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool? Blocked { get; set;}


    }
}
