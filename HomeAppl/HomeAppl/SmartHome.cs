using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppl
{
    public class GenericDevice
    {
        public bool state = false;
        public string name = "";
        public InterfaceDevice ifd = null;
        public GenericDevice(bool state, InterfaceDevice ifd, string name)
        {
            this.state = state;
            this.ifd = ifd;
            this.name = name;
        }
    }
    public class Light: GenericDevice
    {
        public int brightness = 0;
        public Light(bool state, int brightness, InterfaceDevice ifd, string name) : base(state, ifd, name)
        {
            this.brightness = brightness;
        }
        public bool validateBrightness(int level)
        {
            return level >= 1 && level <= 10;
        }
    }
    public class Fan: GenericDevice
    {
        public int speed = 0;
        public Fan(bool state, int speed, InterfaceDevice ifd, string name) : base(state, ifd, name)
        {
            this.state = state;
            this.speed = speed;
        }
        public bool validateSpeed(int level)
        {
            return level >= 1 && level <= 5;
        }
    }
}
