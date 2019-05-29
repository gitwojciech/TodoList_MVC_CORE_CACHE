using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace TodoApp.Models
{
    public class TodoTaskViewModel
    {
        [Required]
        [StringLength(128, ErrorMessage = "Descriptoin can be only 128 charcters.")]
        public string Description { get; set; }
    }
}
