//using UnityEngine;
//using System;
//using System.Data;
//using System.Text;
//using System.Collections;
//using System.Collections.Generic;
//using System.Security.Cryptography;
//using MySql.Data;
//using MySql.Data.MySqlClient;

//public class MySQLData : MonoBehaviour
//{
//    public string host, database, user, password;
//    public bool pooling = true;

//    private string connectionString;
//    private MySqlConnection con = null;
//    private MySqlCommand cmd = null;
//    private MySqlDataReader rdr = null;

//    void Awake()
//    {
//        DontDestroyOnLoad(this.gameObject);
//        connectionString = "Server=" + host + ";Database=" + database + ";User=" + user + ";Password=" + password + ";Pooling=";
//        if (pooling)
//        {
//            connectionString += "True";
//        }
//        else
//        {
//            connectionString += "False";
//        }
//        try
//        {
//            con = new MySqlConnection(connectionString);
//            con.Open();
//            Debug.Log("Mysql state: " + con.State);

//            string sql = "SELECT * FROM HighScore";
//            cmd = new MySqlCommand(sql, con);
//            cmd = new MySqlCommand(sql, con);
//            rdr = cmd.ExecuteReader();

//            while (rdr.Read())
//            {
//                Debug.Log("???");
//                Debug.Log(rdr[0] + " -- " + rdr[1]);
//            }
//            rdr.Close();

//        }
//        catch (Exception e)
//        {
//            Debug.Log(e);
//        }
//    }

//    void onApplicationQuit()
//    {
//        if (con != null)
//        {
//            if (con.State.ToString() != "Closed")
//            {
//                con.Close();
//                Debug.Log("Mysql connection closed");
//            }
//            con.Dispose();
//        }
//    }
//}