using System;
using System.Collections.Generic;

namespace HomeAppl
{
    class Program
    {
        static void Main(string[] args)
        {
            Program pr = new Program();
            List<InterfaceDevice> ifds = new List<InterfaceDevice>();
            
            List<GenericDevice> genericDevices = new List<GenericDevice>();
            List<Light> lights = new List<Light>();
            List<Fan> fans = new List<Fan>();

            while(true)
            {
                string command = Console.ReadLine();
                if(command.StartsWith("add_interface_device"))
                {
                    //int index = command.IndexOf("(");
                    // string cmdParam = command.Substring(index);
                    // cmdParam = cmdParam.Trim('(');
                     // cmdParam = cmdParam.Trim(')');
                    string deviceName = "Alexa";//cmdParam.Split(',')[0];
                    string activationCommand = "Alexa";//cmdParam.Split(',')[1];
                    Console.WriteLine(deviceName);
                    Console.WriteLine(activationCommand);

                    InterfaceDevice ifd1 = new InterfaceDevice(deviceName, activationCommand);
                    ifds.Add(ifd1);
                }
                if(command.StartsWith("add_smarthome_device"))
                {
                    string smartDeviceName = "Drawing Room Light";
                    string interfaceDeviceName = "Alexa";

                    InterfaceDevice ifd = ifds.Find(x => x.deviceName == interfaceDeviceName);
                    if(ifd != null)
                    {
                        if (smartDeviceName.Contains("Fan"))
                        {
                            Fan _fan = new Fan(false, 0, ifd, smartDeviceName);
                            fans.Add(_fan);
                        }
                        else if(smartDeviceName.Contains("Light"))
                        {
                            Light _light = new Light(false, 0, ifd, smartDeviceName);
                            lights.Add(_light);
                        }
                        else
                        {
                            GenericDevice genericDevice = new GenericDevice(false, ifd, smartDeviceName);
                            genericDevices.Add(genericDevice);
                        }
                    }
                    else
                    {
                        Console.Write("interface device not available");
                    }

                }
                if(command.StartsWith("give_command"))
                {
                    string deviceCommand = "Alexa";

                    // checking if device available with that command
                    InterfaceDevice ifd = ifds.Find(x => x.activatedBy == deviceCommand);
                    if(ifd != null)
                    {
                        // check home Appliance available or not
                        string applianceName = "Drawing Room Light";
                        if(applianceName.Contains("Fan"))
                        {
                            Fan _fan = fans.Find(x => x.ifd.activatedBy == ifd.activatedBy && x.name == applianceName);
                            if(_fan != null)
                            {
                                string behaviour = "State";
                                string behaviourVal = "ON";
                                if(behaviour == "State")
                                {
                                    _fan.state = behaviourVal == "ON" ? true : false;
                                    if (_fan.state)
                                        Console.WriteLine($"OK, {_fan.name} Turned On");
                                }

                                if(behaviour == "Speed")
                                {
                                    int _speed = Int32.Parse(behaviourVal);
                                    if(_fan.validateSpeed(_speed))
                                    {
                                        _fan.speed = _speed;
                                    }
                                }

                            }
                            else
                            {
                                Console.WriteLine("Connected appliance is not available");
                            }
                        }
                        else if(applianceName.Contains("Light"))
                        {
                            Light _light = lights.Find(x => x.ifd.activatedBy == ifd.activatedBy && x.name == applianceName);
                            if (_light != null)
                            {
                                string behaviour = "Brightness";
                                string behaviourVal = "5";
                                if (behaviour == "State")
                                {
                                    _light.state = behaviourVal == "ON" ? true : false;
                                    if (_light.state)
                                        Console.WriteLine($"OK, {_light.name} Turned On");
                                }

                                if (behaviour == "Brightness")
                                {
                                    int _brightness = Int32.Parse(behaviourVal);
                                    if (_light.validateBrightness(_brightness))
                                    {
                                        _light.brightness = _brightness;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Connected appliance is not available");
                            }
                        }
                        else
                        {
                            GenericDevice _genericDevice = genericDevices.Find(x => x.ifd.activatedBy == ifd.activatedBy && x.name == applianceName);
                            if (_genericDevice != null)
                            {
                                string behaviour = "State";
                                string behaviourVal = "OFF";
                                if (behaviour == "State")
                                {
                                    _genericDevice.state = behaviourVal == "ON" ? true : false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Connected appliance is not available");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("device not available");
                    }
                }
            }
        }
    }
}
