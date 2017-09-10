using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDesktop.Persistance
{
    public class AccesJDBC
    {
        private MySqlConnection connection;
        public  static string server = "localhost";
        public static string database = "souriescharp";
        public static string uid ="root";
        public static string password ="root";
        public static string connectionString;
        public AccesJDBC() { init(); }
        public void init()
        {
    connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
    }
    //open connection to database
    private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public  void update(String reqSql){

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(reqSql, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public List<List<String>> get(String reqSql){

            //Create a list to store the result
            List<List<String>> listOfLists = new List<List<String>>();
           
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(reqSql, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                int columns = dataReader.FieldCount;
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    List<String> list = new List<String>();
                    for (int i = 0; i < columns; i++)
                    {
                        list.Add(dataReader[i].ToString());
                    }
                    listOfLists.Add(list);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return listOfLists;
            }
            else
            {
                return null;
            }

            
        }

        public int count(String tableName, String primaryKey, String Value) {
            string query = "SELECT count(*) FROM " + tableName + " WHERE " + primaryKey + "= " + Value;
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true){
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else{
                return Count;
            }
        }
    }
}
