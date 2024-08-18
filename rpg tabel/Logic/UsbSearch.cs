using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Management;
using System.Linq;

namespace rpg_tabel.Logic
{
    public class UsbSearch
    {
        private readonly SettingsEditor _settingsEditor;

        public UsbSearch(SettingsEditor settingsEditor)
        {
            _settingsEditor = settingsEditor;
        }

        // Method to find Arduino devices
        public List<string> FindArduinoDevices()
        {
            var deviceList = new List<string>();

            // Retrieve Vendor ID and Product ID from SettingsEditor
            string vendorId = _settingsEditor.GetSettingValue("VendorID") ?? "1234"; // Default Vendor ID
            string productId = _settingsEditor.GetSettingValue("ProductID") ?? "0043"; // Default Product ID

            // Search for devices with the specified Vendor ID and Product ID
            string query = $"SELECT * FROM Win32_PnPEntity WHERE DeviceID LIKE '%VID_{vendorId}%' AND DeviceID LIKE '%PID_{productId}%'";
            var searcher = new System.Management.ManagementObjectSearcher(query);

            try
            {
                var devices = searcher.Get();

                foreach (var device in devices)
                {
                    string deviceName = device["Name"]?.ToString();
                    if (!string.IsNullOrEmpty(deviceName))
                    {
                        deviceList.Add(deviceName);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching for devices: {ex.Message}");
            }

            // If no devices found by ID, return COM3 for testing purposes
            if (deviceList.Count == 0)
            {
                deviceList.Add("COM3");
            }

            return deviceList;
        }
    }

}
