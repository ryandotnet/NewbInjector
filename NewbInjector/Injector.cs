using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace NewbInjector
{
    public class Injector
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        public const int PROCESS_CREATE_THREAD = 0x0002;
        public const int PROCESS_QUERY_INFORMATION = 0x0400;
        public const int PROCESS_VM_OPERATION = 0x0008;
        public const int PROCESS_VM_WRITE = 0x0020;
        public const int PROCESS_VM_READ = 0x0010;

        public const uint MEM_COMMIT = 0x00001000;
        public const uint MEM_RESERVE = 0x00002000;
        public const uint PAGE_READWRITE = 4;

        public static IntPtr libAddress;

        public static int processID;
        public static bool is64Bit;
        public static string dllPath;
        public static string helperPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Newb\\Injector\\Win32Helper.exe");

        public static UIntPtr bytesWritten;

        // Inject Function
        public static void Inject()
        {
            // Getting the Process Handle + Privileges 
            IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, processID);

            // Getting the LoadLibraryA and Kernel32 Addresses
            if (is64Bit == true)
            {
                libAddress = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            }

            else
            {
                Process win32Helper = new Process();

                win32Helper.StartInfo.FileName = helperPath;
                win32Helper.StartInfo.UseShellExecute = false;
                win32Helper.StartInfo.CreateNoWindow = true;
                win32Helper.Start();
                win32Helper.WaitForExit();

                libAddress = (IntPtr)win32Helper.ExitCode;

                win32Helper.Close();
            }

            // Allocate Memory in Process for our DLL
            IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllPath.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);

            // Writing our DLL to Process Memory
            WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllPath), (uint)((dllPath.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);

            // Injecting our DLL

            CreateRemoteThread(procHandle, IntPtr.Zero, 0, libAddress, allocMemAddress, 0, IntPtr.Zero);
        }
    }
}
