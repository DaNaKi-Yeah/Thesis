using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thesis.Domain.Entities.Common;

namespace Thesis.Domain.Entities.Models
{
    public class News : BaseEntity<int>
    {
        [MaxLength(100)]
        public string Title { get; set; }
        public string Body { get; set; }
        public User Author { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
