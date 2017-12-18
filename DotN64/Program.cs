﻿using System.IO;

namespace DotN64
{
    using Diagnostics;

    internal static class Program
    {
        private static void Main(string[] args)
        {
            var nintendo64 = new Nintendo64();
            Debugger debugger = null;

            for (int i = 0; i < args.Length; i++)
            {
                var arg = args[i];

                switch (arg)
                {
                    case "--pif-rom":
                        nintendo64.PIF.BootROM = File.ReadAllBytes(args[++i]);
                        break;
                    case "--debug":
                    case "-d":
                        debugger = new Debugger(nintendo64);
                        break;
                    default:
                        nintendo64.Cartridge = Cartridge.FromFile(new FileInfo(arg));
                        break;
                }
            }

            nintendo64.PowerOn();

            if (debugger == null)
                nintendo64.Run();
            else
                debugger.Run(true);
        }
    }
}
