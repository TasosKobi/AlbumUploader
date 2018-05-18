using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("photo")]
    public class Photo
    {
        [Key]
        public int photoid { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        [ForeignKey("userid")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime AddedDate { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public string Path { get; set; }

        public double longitude { get; set; }

        public double latitude { get; set; }


    }
}
