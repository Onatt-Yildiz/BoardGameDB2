namespace BoardGameDB.Models
{
    public class RolePage
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public int PageId { get; set; }
        public virtual Page Page { get; set; }
    }
}
