using System;
using System.IO.Ports;

namespace rpg_tabel.Connections
{
    public class ArduinoConnection : IDisposable
    {
        private SerialPort _serialPort;

        // Connect to Arduino with a specified port and baud rate
        public bool Connect(string portName, int baudRate = 9600)
        {
            try
            {
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    // Already connected
                    return true;
                }

                _serialPort = new SerialPort(portName, baudRate);
                _serialPort.Open();
                return _serialPort.IsOpen;
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Error connecting to Arduino: {ex.Message}");
                return false;
            }
        }

        // Disconnect from Arduino
        public void Disconnect()
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
                _serialPort.Dispose();
                _serialPort = null; // Ensure the serial port is no longer referenced
            }
        }

        // Implement IDisposable to ensure proper cleanup
        public void Dispose()
        {
            Disconnect(); // Ensure that resources are cleaned up
            GC.SuppressFinalize(this); // Suppress finalization
        }
    }
}
