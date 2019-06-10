using System.ComponentModel.DataAnnotations;

namespace Store.DAL.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
       
}
