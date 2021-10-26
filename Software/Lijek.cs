using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

        
namespace Ljekarna.Database___Entity_Framework
{
    public partial class Lijek
    {
        public override string ToString()
        {
            return this.Naziv;
        }
    }
}
