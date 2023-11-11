using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn_WebAcc.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Username { get; set; }
        public string? Phone { get; set; }
        public string? Mail { get; set; }
        public string Password { get; set; }
    }
}