﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace sneaker_heaven
{
    internal class Connect
    {
        public MySqlConnection Connection;
        public string Host;
        public string Database;
        public string User;
        public string Password;
        public string ConnectionString;

        public Connect()
        {
            Host = "localhost";
            Database = "sneakerheaven";
            User = "root";
            Password = "";

            ConnectionString = "SERVER=" + Host + ";DATABASE=" + Database + ";UID=" + User + ";PASSWORD=" + Password + ";SslMode=None";

            Connection = new MySqlConnection(ConnectionString);
        }
    }
}
