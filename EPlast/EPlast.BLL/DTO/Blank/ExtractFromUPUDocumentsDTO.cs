﻿using System.ComponentModel.DataAnnotations;

namespace EPlast.BLL.DTO.Blank
{
   public class ExtractFromUPUDocumentsDTO
    {
        public int ID { get; set; }
        public string BlobName { get; set; }
        [Required, MaxLength(120)]
        public string FileName { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
