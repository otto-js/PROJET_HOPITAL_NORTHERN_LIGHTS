using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthenLights_LandierJeremy
{
    public partial class Patient
    {
        public override bool Equals(object obj)
        {
            return obj is Patient patient && NSS == patient.NSS;
        }
    }
}
