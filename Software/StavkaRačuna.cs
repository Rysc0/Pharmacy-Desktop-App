using Ljekarna.Database___Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ljekarna
{
    public class StavkaRačuna
    {
        public Lijek Lijek { get; set; }
        public string Naziv { get { return Lijek.Naziv; }}
        public int Količina { get; set; }
    }
}
