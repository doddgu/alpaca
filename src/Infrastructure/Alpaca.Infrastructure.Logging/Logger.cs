using Alpaca.Infrastructure.Config;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Infrastructure.Logging
{
    /// <summary>
    /// Based on Serilog
    /// <see cref="https://github.com/serilog/serilog"/>
    /// <seealso cref="https://messagetemplates.org/"/>
    /// </summary>
    public class Logger
    {
        private static Serilog.Core.Logger _logger = null;

        static Logger()
        {
            _logger = new LoggerConfiguration()
                .ReadFrom.Configuration(AppConfigWrapper.GetConfiguration())
                .CreateLogger();

            AppConfigWrapper.RegisterChangeCallback((obj) =>
            {
                _logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(AppConfigWrapper.GetConfiguration())
                    .CreateLogger();
            });
        }

        #region Verbose

        public static void Verbose(string message)
        {
            _logger.Verbose(message);
        }

        public static void Verbose(Exception exception, string message)
        {
            _logger.Verbose(exception, message);
        }

        public static void Verbose<T>(string messageTemplate, T propertyValue)
        {
            _logger.Verbose(messageTemplate, propertyValue);
        }

        public static void Verbose(string messageTemplate, params object[] propertyValues)
        {
            _logger.Verbose(messageTemplate, propertyValues);
        }

        public static void Verbose(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            _logger.Verbose(exception, messageTemplate, propertyValues);
        }

        public static void Verbose<T>(Exception exception, string messageTemplate, T propertyValue)
        {
            _logger.Verbose(exception, messageTemplate, propertyValue);
        }

        #endregion

        #region Debug

        public static void Debug(string message)
        {
            _logger.Debug(message);
        }

        public static void Debug(Exception exception, string message)
        {
            _logger.Debug(exception, message);
        }

        public static void Debug<T>(string messageTemplate, T propertyValue)
        {
            _logger.Debug(messageTemplate, propertyValue);
        }

        public static void Debug(string messageTemplate, params object[] propertyValues)
        {
            _logger.Debug(messageTemplate, propertyValues);
        }

        public static void Debug(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            _logger.Debug(exception, messageTemplate, propertyValues);
        }

        public static void Debug<T>(Exception exception, string messageTemplate, T propertyValue)
        {
            _logger.Debug(exception, messageTemplate, propertyValue);
        }

        #endregion

        #region Info

        public static void Info(string message)
        {
            _logger.Information(message);
        }

        public static void Info(Exception exception, string message)
        {
            _logger.Information(exception, message);
        }

        public static void Info<T>(string messageTemplate, T propertyValue)
        {
            _logger.Information(messageTemplate, propertyValue);
        }

        public static void Info(string messageTemplate, params object[] propertyValues)
        {
            _logger.Information(messageTemplate, propertyValues);
        }

        public static void Info(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            _logger.Information(exception, messageTemplate, propertyValues);
        }

        public static void Info<T>(Exception exception, string messageTemplate, T propertyValue)
        {
            _logger.Information(exception, messageTemplate, propertyValue);
        }

        #endregion

        #region Warning

        public static void Warning(string message)
        {
            _logger.Warning(message);
        }

        public static void Warning(Exception exception, string message)
        {
            _logger.Warning(exception, message);
        }

        public static void Warning<T>(string messageTemplate, T propertyValue)
        {
            _logger.Warning(messageTemplate, propertyValue);
        }

        public static void Warning(string messageTemplate, params object[] propertyValues)
        {
            _logger.Warning(messageTemplate, propertyValues);
        }

        public static void Warning(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            _logger.Warning(exception, messageTemplate, propertyValues);
        }

        public static void Warning<T>(Exception exception, string messageTemplate, T propertyValue)
        {
            _logger.Warning(exception, messageTemplate, propertyValue);
        }

        #endregion

        #region Error

        public static void Error(string message)
        {
            _logger.Error(message);
        }

        public static void Error(Exception exception, string message)
        {
            _logger.Error(exception, message);
        }

        public static void Error<T>(string messageTemplate, T propertyValue)
        {
            _logger.Error(messageTemplate, propertyValue);
        }

        public static void Error(string messageTemplate, params object[] propertyValues)
        {
            _logger.Error(messageTemplate, propertyValues);
        }

        public static void Error(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            _logger.Error(exception, messageTemplate, propertyValues);
        }

        public static void Error<T>(Exception exception, string messageTemplate, T propertyValue)
        {
            _logger.Error(exception, messageTemplate, propertyValue);
        }

        #endregion

        #region Fatal

        public static void Fatal(string message)
        {
            _logger.Fatal(message);
        }

        public static void Fatal(Exception exception, string message)
        {
            _logger.Fatal(exception, message);
        }

        public static void Fatal<T>(string messageTemplate, T propertyValue)
        {
            _logger.Fatal(messageTemplate, propertyValue);
        }

        public static void Fatal(string messageTemplate, params object[] propertyValues)
        {
            _logger.Fatal(messageTemplate, propertyValues);
        }

        public static void Fatal(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            _logger.Fatal(exception, messageTemplate, propertyValues);
        }

        public static void Fatal<T>(Exception exception, string messageTemplate, T propertyValue)
        {
            _logger.Fatal(exception, messageTemplate, propertyValue);
        }

        #endregion
    }
}
