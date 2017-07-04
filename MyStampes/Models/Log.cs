using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStampes.ViewModel
{
    public class LogItem
    {
        public int Id { get; set; }

        public string Info { get; set; }

        public float Price { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }

        public string SpecInfo { get; set; }

        public int SellerId { get; set; }

        public string SellerInfo { get; set; }

        public int Index { get; set; }
    }
}
