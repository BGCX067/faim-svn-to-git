using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Data
{
    static class Logger
    {

        //error log
        private const String LOG_FILE = "Errors.log";

        //event log object
        private static System.Diagnostics.EventLog evntLog = new System.Diagnostics.EventLog();



        /// <summary>
        /// Static Constructor
        /// </summary>
        static Logger()
        {

            //if the log file doesn't exist, create it
            if (System.IO.File.Exists(LOG_FILE) == false)
                System.IO.File.Create(LOG_FILE).Close();

            //check if our app has a section in the event log
            if (System.Diagnostics.EventLog.SourceExists(Application.ProductName) == false)
                System.Diagnostics.EventLog.CreateEventSource(Application.ProductName, "FAim");

        }

        /// <summary>
        /// Write a standard, non-fatal error to the log file.
        /// </summary>
        /// <param name="ex">The EXCEPTION object to write to file.</param>
        public static void WriteExceptionToFile(Exception ex)
        {

            //stream to write to
            System.IO.StreamWriter sw = null;

            //in try block for safety
            try
            {

                //create stream and write out info
                sw = System.IO.File.AppendText(LOG_FILE);
                sw.WriteLine("Severity: " + "LOW" + "~DateTime: " + DateTime.Now.ToString("MM/DD/YYYY:HH/MM/SS") + "~Exception: " + ex.Message + "~StackTrace: " + ex.StackTrace + "~");

            }
            catch (System.IO.IOException excep)
            {

                //we cant write to log file....this is bad. write a fatal exception to the system error log.
                WriteFatalExceptionToFile(excep);

            }
            finally
            {

                //cleanup if necessary
                if (sw != null)
                {

                    //sw can be a memory leak, so clean it up
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();

                }

            }

        }

        /// <summary>
        /// Fatal exception occured within the application and the application cannot continue. Data will be written to System Log and the application will be killed.
        /// </summary>
        /// <param name="ex">The exception to write to the System Event Log.</param>
        public static void WriteFatalExceptionToFile(Exception ex)
        {

            //write the data to the System Event Log
            evntLog.Source = Application.ProductName;
            evntLog.WriteEntry("Severity: " + "HIGH" + "~DateTime: " + DateTime.Now.ToString("MM/DD/YYYY:HH/MM/SS") + "~Exception: " + ex.Message + "~StackTrace: " + ex.StackTrace + "~");
            
            //fatal error, so alert the user, tell them to check the error log, then kill the app
            MessageBox.Show(Application.ProductName + " has encountered a fatal error and must close. Please check the System Event Log for details.");
            System.Diagnostics.Process.GetCurrentProcess().Kill();

        }

    }
}
