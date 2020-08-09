using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace SharedClassess
{
   public class AppLogger
    {
        // Install System.Diagnostics.EventLog

        /// <summary>
        ///  Windows Events log  
        /// </summary>
        /// <param name="text"></param>
        public static void WriteLog(string text)
        {
            try
            {
                using (EventLog log = new EventLog("Application"))
                {
                    log.Source = "Application";
                    log.WriteEntry(text, EventLogEntryType.Error, 234, (short)3);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
