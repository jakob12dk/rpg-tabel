using System;
using System.IO.Ports;

namespace rpg_tabel.Connections
{
    public class ArduinoConnection
    {
        private SerialPort _serialPort;

        public bool IsConnected => _serialPort != null && _serialPort.IsOpen;

        public ArduinoConnection()
        {
            _serialPort = new SerialPort();
        }

        public void Connect(string portName)
        {
            try
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                }

                _serialPort.PortName = portName;
                _serialPort.BaudRate = 9600;
                _serialPort.Open();
                Console.WriteLine($"Connected to Arduino on {portName}");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to connect to {portName}: {ex.Message}", ex);
            }
        }

        public void Disconnect()
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
                Console.WriteLine("Disconnected from Arduino.");
            }
        }

        public string[] GetAvailableMethods()
        {
            if (!IsConnected)
                throw new InvalidOperationException("Not connected to Arduino.");

            _serialPort.WriteLine("METHODS"); // Command to request available methods
            System.Threading.Thread.Sleep(500); // Wait for Arduino to respond

            var response = _serialPort.ReadExisting();
            return response.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public void CallMethod(string methodName)
        {
            if (!IsConnected)
                throw new InvalidOperationException("Not connected to Arduino.");

            _serialPort.WriteLine(methodName);
        }
    }
}
