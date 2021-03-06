﻿#define WithCallBack

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPluginManager
{
    class Program
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll")]
        private static extern bool FreeLibrary(IntPtr hModule);

        static void Main(string[] args)
        {
            Guid guid = Guid.NewGuid();

            IntPtr hModule = LoadLibrary("Win32Plugin.dll");
            IntPtr procAddress;
#if WithCallBack
            procAddress = GetProcAddress(hModule, "LoadPluginWithReleaseMethod");

            var hLoadPluginWithReleaseMethod = Marshal.GetDelegateForFunctionPointer<LoadPluginWithReleaseMethodHandler>(procAddress);

            IntPtr hPlugin;
    #if false
            IntPtr phRelease;
            hPlugin = hLoadPluginWithReleaseMethod(guid, out phRelease);

            var hReleasePlugin = Marshal.GetDelegateForFunctionPointer<ReleasePluginHandler>(phRelease);
    #else
            hPlugin = hLoadPluginWithReleaseMethod(guid, out ReleasePluginHandler hReleasePlugin);
#endif
#else
            procAddress = GetProcAddress(hModule, "LoadPlugin");

            var hLoadPlugin = Marshal.GetDelegateForFunctionPointer<LoadPluginHandler>(procAddress);

            procAddress = GetProcAddress(hModule, "ReleasePlugin");
            var hReleasePlugin = Marshal.GetDelegateForFunctionPointer<ReleasePluginHandler>(procAddress);

            IntPtr hPlugin = hLoadPlugin(guid);
#endif
            procAddress = GetProcAddress(hModule, "Plugin_Name");
            var hPluginName = Marshal.GetDelegateForFunctionPointer<PluginNameHandler>(procAddress);
            StringBuilder sb = new StringBuilder();
            bool success = hPluginName(hPlugin, sb);
            Console.WriteLine("{0}:    \"{1}\"", success, sb.ToString());

            hReleasePlugin(hPlugin);

            FreeLibrary(hModule);
            ;
        }

#if WithCallBack
        delegate IntPtr LoadPluginWithReleaseMethodHandler(Guid guid, out
#if false
            IntPtr
#else
            ReleasePluginHandler
#endif
            phRelease);
#else
        delegate IntPtr LoadPluginHandler(Guid guid);
#endif
        
        delegate void ReleasePluginHandler(IntPtr hPlugin);

        delegate bool PluginNameHandler(IntPtr hPlugin, StringBuilder sb);
    }
}
