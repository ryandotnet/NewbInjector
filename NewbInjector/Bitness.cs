using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Management;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace NewbInjector
{
    public class Bitness
    {
        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWow64Process([In] IntPtr process, [Out] out bool wow64Process);


        public static string dllBitness;
        public static string procBitness;

        public enum Bit : ushort
        {
            IMAGE_FILE_MACHINE_AMD64 = 0x8664,
            IMAGE_FILE_MACHINE_I386 = 0x14c,
            IMAGE_FILE_MACHINE_IA64 = 0x200,
        }

        public static void getBitness(string dllPath)
        {
            FileStream fs = new FileStream(dllPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            fs.Seek(0x3c, SeekOrigin.Begin);
            int peOffset = br.ReadInt32();

            fs.Seek(peOffset, SeekOrigin.Begin);
            uint peHeader = br.ReadUInt32();

            if (peHeader != 0x00004550)
            {
                throw new Exception("Failed to read DLL Bitness!");
            }

            Bit bitness = (Bit)br.ReadUInt16();

            br.Close();
            fs.Close();

            if (bitness == Bit.IMAGE_FILE_MACHINE_AMD64 || bitness == Bit.IMAGE_FILE_MACHINE_IA64)
            {
                Injector.is64Bit = true;
                dllBitness = "64Bit";
            }

            else if (bitness == Bit.IMAGE_FILE_MACHINE_I386)
            {
                Injector.is64Bit = false;
                dllBitness = "32Bit";
            }
        }

        public static void getProcBitness(Process proc)
        {
            bool retVal;

            if (proc.HasExited)
            {
                procBitness = "";
            }

            else
            {
                IsWow64Process(proc.Handle, out retVal);

                if (retVal == true)
                {
                    procBitness = "32Bit";
                }

                else if (retVal == false)
                {
                    procBitness = "64Bit";
                }
            }
        }
    }
}
