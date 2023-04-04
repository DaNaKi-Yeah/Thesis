using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thesis.Domain.Entities.Common;

namespace Thesis.Domain.Entities.Models
{
    public class Department : BaseEntity<int>
    {
        [MaxLength(100)]
        public string Title { get; set; }
        public string Summary { get; set; }
        public ICollection<News> News { get; set; }
    }
}
