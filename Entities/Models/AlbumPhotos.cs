using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("photosalbum")]
    public class AlbumPhotos
    {
        [Required]
        [ForeignKey("AlbumReference")]
        public int AlbumId { get; set; }

        [Required]
        [Key]
        [ForeignKey("PhotoReference")]
        public int PhotoId { get; set; }
    }
}
