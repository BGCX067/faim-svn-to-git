using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Data
{
    public static class QueryManager
    {

        public static List<String> DevKeys()
        {

            //list of keys to return
            List<String> lst = new List<string>();

            //create a dataset
            System.Data.DataSet ds = new System.Data.DataSet();

            //get a command object
            using (System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(SqlLite.Connection))
            {

                //set the sql
                cmd.CommandText = "SELECT value FROM " + SqlLite.DB_DEV_KEYS;

                //create adapters
                using (System.Data.SQLite.SQLiteDataAdapter adapter = new System.Data.SQLite.SQLiteDataAdapter(cmd))
                {

                    //query
                    adapter.Fill(ds);

                    //get the keys
                    for (int i = 0; i < ds.Tables.Count; i++)
                        for (int j = 0; j < ds.Tables[i].Rows.Count; j++)
                            lst.Add(ds.Tables[i].Rows[j]["value"].ToString());

                }

            }

            //return the list
            return lst;

        }

        public static List<String> ReleaseKeys()
        {

            //list of keys to return
            List<String> lst = new List<string>();

            //create a dataset
            System.Data.DataSet ds = new System.Data.DataSet();

            //get a command object
            System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(SqlLite.Connection);
            cmd.CommandText = "SELECT value FROM " + SqlLite.DB_REL_KEYS;

            //create adapters
            System.Data.SQLite.SQLiteDataAdapter adapter = new System.Data.SQLite.SQLiteDataAdapter(cmd);

            //query
            adapter.Fill(ds);

            //get the keys
            for (int i = 0; i < ds.Tables.Count; i++)
                for (int j = 0; j < ds.Tables[i].Rows.Count; j++)
                    lst.Add(ds.Tables[i].Rows[j].ToString());

            //return the list
            return lst;

        }

    }
}
