using System;
using Phidget22;
using Phidget22.Events;

namespace PhidgetBridgeReader
{
    public class VoltageReader
    {
        private event Action<double> NewVoltage;
        private  VoltageRatioInput input;
        private int dataIntervalMs;

        public VoltageReader(int channel, Action<double> onNewVoltage, int dataIntervalMs = 10) {
            this.dataIntervalMs = dataIntervalMs;
            this.NewVoltage += onNewVoltage;
            input = new VoltageRatioInput();
            input.Channel = channel;
            input.Close();
            input.Open();
            input.Attach += OnAttach;
        }

        private void OnAttach(object sender, AttachEventArgs e) {
            input.DataInterval = this.dataIntervalMs;
            input.VoltageRatioChangeTrigger = 0;
            Console.WriteLine("Attached on channel " + input.Channel + " data interval " + input.DataInterval + "ms");
            input.VoltageRatioChange += OnVoltageChange;
        }

        private void OnVoltageChange(object sender, VoltageRatioInputVoltageRatioChangeEventArgs e) {
            NewVoltage?.Invoke(input.VoltageRatio);
        }
    }
}
