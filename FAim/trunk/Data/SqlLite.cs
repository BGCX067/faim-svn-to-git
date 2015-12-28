using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;

namespace Data
{
    static class SqlLite
    {

        //constants for db
        internal const String DB_FILE = "FAim.db";
        internal const String DB_DATA = "Data";
        internal const String DB_DEV_KEYS = "Dev_Keys";
        internal const String DB_REL_KEYS = "Rel_Keys";
        internal const String DB_IMS = "Ims";
        internal const String DB_USERS = "Users";

        //connection object
        private static System.Data.SQLite.SQLiteConnection sqlCon;

        /// <summary>
        /// Gets the Sqlite Connection. NOTE: DO NOT CLOSE THE CONNECTION!!!!
        /// </summary>
        public static System.Data.SQLite.SQLiteConnection Connection
        {
           get { return sqlCon; }
        }



        static SqlLite()
        {

            //make sure file exists, if not, create it
            if (System.IO.File.Exists(DB_FILE))
                OpenDatabase();
            else
                CreateDatabase();

            //subscribe to the state change event
            sqlCon.StateChange += new System.Data.StateChangeEventHandler(sqlCon_StateChange);

        }


        private static void sqlCon_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {

            //if ((e.CurrentState == System.Data.ConnectionState.Broken) || (e.CurrentState == System.Data.ConnectionState.Closed))
            System.Diagnostics.Debug.WriteLine("Old DB State: " + e.OriginalState.ToString() + "\tCurrent State: " + e.CurrentState.ToString());

        }

        private static void OpenDatabase()
        {

            try
            {

                //open connection
                sqlCon = new System.Data.SQLite.SQLiteConnection("Data Source=" + DB_FILE + ";Compress=True;");

            }
            catch (System.Data.SQLite.SQLiteException ex)
            {
                
                //log the error
                Logger.WriteExceptionToFile(ex);

                //we couldnt open the DB so rename the old one and try a new one. 
                System.IO.File.Move(DB_FILE, DB_FILE + "OLD");
                System.Windows.Forms.MessageBox.Show("Cannot access Database. Renaming the old one and attempting to create a new one. Please verify database integrity.");
                CreateDatabase();

            }

        }

        private static void CreateDatabase()
        {

            //create the file itself 
            File.Create(DB_FILE).Close();

            //copy all bytes from resource file to the newly created file
            File.WriteAllBytes(DB_FILE, GetResource());

        }

        /// <summary>
        /// Gets the Database file from Embedded Resources
        /// NOTE: I had to change the "Compile Action" of the file to "Embedded Resource" event after adding it as a resource.
        /// </summary>
        /// <returns></returns>
        private static Byte[] GetResource()
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            StreamReader sr = new StreamReader(assembly.GetManifestResourceStream(assembly.GetName().Name + ".Resources." + DB_FILE));
            Byte[] bt = new Byte[sr.BaseStream.Length];
            sr.BaseStream.Read(bt, 0, bt.Length);
            sr.Close();

            return bt;
        }

        /// <summary>
        /// Close the connection to the DB
        /// </summary>
        public static void CloseConnection()
        {

            //cleanup
            sqlCon.Close();
            sqlCon.Dispose();

        }

    }
}
