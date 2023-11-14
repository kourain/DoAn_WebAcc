﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn_WebAcc.Models
{
    [Table("Footer")]
    public class Footer
    {
        [Key]
        public int FooterId { get; set; }
        public string? ItemText { get; set; }
        public int Column { get; set; }
        public int ParentID { get; set; }
        public int ItemOrder { get; set; }
        public bool IsActive { get; set; }
        public string? Icon { get; set; }
        public string? TextLink { get; set; }
        public string? Link { get; set; }
    }
}
