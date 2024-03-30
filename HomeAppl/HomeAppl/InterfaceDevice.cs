using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppl
{
    public class InterfaceDevice
    {
        public string deviceName;
        public string activatedBy;
        public InterfaceDevice(string deviceName, string activatedBy)
        {
            this.deviceName = deviceName;
            this.activatedBy = activatedBy;
        }
    }
}
