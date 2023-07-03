using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Services
{
    public class Logger 
    {
        private string _logPath = @"C:\\Users\\install\\Desktop\\Practical 22\\Practical 22\\Data Access Layer\\logs\\logs.txt";

        public void Log(string message)
        {
            string formattedMessage = $"{DateTime.Now} : {message}";
            using(StreamWriter sr =File.AppendText(_logPath))
            {
                try
                {
                    sr.WriteLine(formattedMessage);
                } catch (Exception ex)
                {
                    string value = $"An exception has occured : {ex.Message}";
                    sr.WriteLine(value);
                }
            }
        }
    }
}
