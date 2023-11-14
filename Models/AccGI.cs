using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn_WebAcc.Models
{
    [Table("GI")]
    public class AccGI
    {
        [Key]
        public int UID { get; set; }
        public int? LV { get; set; }
        public int? CharCount { get; set; }
        public int? Weapon { get; set; }
        public string? Server { get; set; }
        public string? Type { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int? Sold { get; set; }
        public int? HoyolabID { get; set; }
        public int? Price { get; set; }
    }
}