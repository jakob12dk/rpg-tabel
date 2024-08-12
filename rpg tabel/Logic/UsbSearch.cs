using System;
using System.Collections.Generic;
using System.Management;
using System.Linq;

namespace rpg_tabel.Logic
{
    internal class UsbSearch
    {
        private readonly SettingsEditor _settingsEditor;

        // Constructor accepting SettingsEditor instance
        public UsbSearch(SettingsEditor settingsEditor)
        {
            _settingsEditor = settingsEditor;
        }

        // Method to find Arduino devices by Vendor ID and Product ID
        public List<string> FindArduinoDevices()
        {
            var deviceList = new List<string>();

            // Retrieve Vendor ID and Product ID from SettingsEditor
            string vendorId = _settingsEditor.GetSettingValue("VendorID") ?? "1234"; // Default value if not found
            string productId = _settingsEditor.GetSettingValue("ProductID") ?? "0043"; // Default value if not found

            // Build the query to search for devices with the specified Vendor ID
            string query = $"SELECT * FROM Win32_PnPEntity WHERE DeviceID LIKE '%VID_{vendorId}%' AND DeviceID LIKE '%PID_{productId}%'";
            var searcher = new ManagementObjectSearcher(query);

            try
            {
                var devices = searcher.Get();

                foreach (ManagementObject device in devices)
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

            return deviceList;
        }
    }
}
