using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DoAn_WebAcc.Areas.Admin.Models
{
	[Table("AdminUser")]
	public class AdminUser
	{
		[Key]
       
        public int AdminUserID { get; set; }
		public string? UserName { get; set; }
		public string? Password { get; set; }
		public string? Email { get; set; }
	}
}
