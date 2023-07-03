using Data_Access_Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Singleton
{
    public sealed class SingletonClass
    {
        private static  ApplicationContext _context = null;
        private static  Logger _logger = null;

        public static ApplicationContext GetInstance()
        {
            if (_context == null)
            {
                _context = new ApplicationContext();
                return _context;
            }
            return _context;
        }

        public static Logger GetLoggerInstance()
        {
            if (_logger == null)
            {
                _logger = new Logger();
                return _logger;
            }
            return _logger;
        }
    }
}
