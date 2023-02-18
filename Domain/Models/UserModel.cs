using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
  public  class UserModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int PersonelCode { get; set; }
        public int InternalNumber { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Room { get; set; }
        public bool IsDeleted { get; set; }
    }
}
