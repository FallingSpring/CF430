using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Win32;

namespace CameraView
{
    public class WriteRegistryKey
    {
        private static RegistryKey Laser_CNC_UV = Registry.CurrentUser.CreateSubKey("Software\\Laser_CNC_UV");
        private static RegistryKey Laser_CNC = Laser_CNC_UV.CreateSubKey("Laser_CNC");

        ~WriteRegistryKey()
        {
            Laser_CNC.Close();
            Laser_CNC_UV.Close();
        }


        public static bool WriteParam(string Section, string Key, object value)
        {
            bool Res = true;
            do
            {
                try
                {
                    RegistryKey rKey = Laser_CNC.CreateSubKey(Section);
                    rKey.SetValue(Key, value);
                    Laser_CNC_UV.Flush();
                    rKey.Close();
                }
                catch
                {
                    Res = false;
                }

            } while (false);

            return Res;
        }
        public static object ReadParam(string Section, string Key, object Default)
        {
            object value;
            try
            {
                RegistryKey rKey = Laser_CNC.OpenSubKey(Section);
                value = rKey.GetValue(Key);
            }
            catch
            {
                value = Default;
            }

            return value;
        }

        public static double ReadParam(string Section, string Key, double Default)
        {
            double value = Default;
            try
            {
                RegistryKey rKey = Laser_CNC.OpenSubKey(Section);
                Double.TryParse((string)rKey.GetValue(Key), out value);
            }
            catch
            {
                value = Default;
            }

            return value;
        }
    }
}
