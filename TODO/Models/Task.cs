using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TODO.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Priority { get; set; }
        public String DueDate { get; set; }
        public String CategoryName { get; set; }
        public Boolean IsDeleted { get; set; }
        public Boolean Favourite { get; set; }

    }
}
