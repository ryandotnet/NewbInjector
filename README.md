# NewbInjector
A WinForms DLL injector written in C#. Targets the .NET Framework 4.7.2. Heavily uses P/Invoke and supports both 32-bit and 64-bit processes.   

The application uses "Win32Helper.exe" which is a 32-bit .NET application written to return the library address for when the targetted process is also 32-bit.   

Future private implementations include the ability to manually map payloads / bytes, use other injection methods such as LoadLibrary or SetWindowsHookEx.
