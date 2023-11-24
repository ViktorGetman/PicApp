using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PicApp
{
    public class PinCodeManager
    {
        private const string PinCodeKey = "pin_code";

        public static void SavePinCode(string pinCode)
        {
            try
            {
                SecureStorage.SetAsync(PinCodeKey, pinCode);
            }
            catch (Exception ex)
            {
                // Обработка ошибок сохранения
                Console.WriteLine("Unable to save pin code: " + ex.Message);
            }
        }

        public static string GetPinCode()
        {
            try
            { 
                    return SecureStorage.GetAsync(PinCodeKey).Result;
            }
            catch (Exception ex)
            {
                // Обработка ошибок извлечения
                Console.WriteLine("Unable to get pin code: " + ex.Message);
            }

            return null;
        }

        public static void RemovePinCode()
        {
            try
            {
                SecureStorage.Remove(PinCodeKey);
            }
            catch (Exception ex)
            {
                // Обработка ошибок удаления
                Console.WriteLine("Unable to remove pin code: " + ex.Message);
            }
        }
    }
}
