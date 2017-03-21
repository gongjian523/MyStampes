using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStampes.ViewModel
{
    class Log
    {
        public int Id { get; private set; }

        public string Info { get; private set; }

        public float Price { get; private set; }

        public DateTime Date { get; private set; }

        public string Status { get; private set; }

        public string SpecInfo { get; private set; }
    }
}
