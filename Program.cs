using System;

namespace PhidgetBridgeReader
{
    class Program
    {
        static void Main(string[] args) {
            VoltageReader v0 = new VoltageReader(0, OnNewVoltage, 1000);
            VoltageReader v1 = new VoltageReader(1, OnNewVoltage2, 1000);
            Console.ReadLine();
        }

        private static void OnNewVoltage(double voltage) {
            Console.WriteLine(voltage);
        }

        private static void OnNewVoltage2(double voltage) {
            Console.WriteLine("            " + voltage);
        }
    }

}
