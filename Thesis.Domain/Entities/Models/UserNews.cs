using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thesis.Domain.Entities.Models
{
    public class UserNews
    {
        public string UserID { get; set; }
        public User User { get; set; }
        public int NewsID { get; set; }
        public News News { get; set; }
    }
}
