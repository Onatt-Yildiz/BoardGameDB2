namespace BoardGameDB.Models
{
    public class UserLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public DateTime LogTime { get; set; }
        public string IpAdress { get; set; }
    }
}
