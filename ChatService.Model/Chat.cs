using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatService.Model
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public DateTime Time { get; set; }
        public bool ToPrint { get; set; }
        public bool Printed { get; set; }
    }
}
