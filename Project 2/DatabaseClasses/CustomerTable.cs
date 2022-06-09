using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using CustomerClasses;

namespace DatabaseClasses
{
    public class CustomerTable
    {
        private const string HOST = "calvin.humber.ca";
        private const string SID = "grok";
        internal const string PASSWORD = "oracle";
        private const string USER_ID = "N01432291";

        private static readonly string myConnectionString = string.Format("DATA SOURCE=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)" +
                                                            "(HOST={0})(PORT=1521))(CONNECT_DATA=(SID={1}))); " +
                                                            "PASSWORD={2}; USER ID={3}", HOST, SID, PASSWORD, USER_ID);
        private OracleConnection oracleConnection;
        private OracleCommand oracleCommand;
        private OracleDataReader oracleDataReader;

        public CustomerTable()
        {
            oracleConnection = new OracleConnection(myConnectionString);
            oracleCommand = new OracleCommand();
            oracleCommand.Connection = oracleConnection;
            oracleConnection.Open();
        }

        //Table name is CustomersTest Because Customer Table Already Exist with diffrent data in the data base
        public void CreateTable()
        {

            //Code creates table if table dosent exist, if table exists then drop it and re create it.
            try
            {
                oracleCommand.CommandText = "Create table CustomersTest(FirstName Varchar2(20), LastName Varchar2(20), Address Varchar2(30), Intrests NUMBER(3))";
                oracleCommand.ExecuteNonQuery();
            }
            catch (OracleException)
            {
                oracleCommand.CommandText = "Drop table CustomersTest";
                oracleCommand.ExecuteNonQuery();
                oracleCommand.CommandText = "Create table CustomersTest(FirstName Varchar2(20), LastName Varchar2(20), Address Varchar2(30), Intrests NUMBER(3))";
                oracleCommand.ExecuteNonQuery();
            }
            //Inserts Values Into Table
            oracleCommand.CommandText = "INSERT INTO CustomersTest VALUES('George', 'Smith','3 Yonge St. Toronto', 211)";
            oracleCommand.ExecuteNonQuery();
            oracleCommand.CommandText = "INSERT INTO CustomersTest VALUES('Navjot', 'Singh','526 Blue Rocks Road', 212)";
            oracleCommand.ExecuteNonQuery();
            oracleCommand.CommandText = "INSERT INTO CustomersTest VALUES('Tyler', 'Meira','425 Bloor Street', 122)";
            oracleCommand.ExecuteNonQuery();
            oracleCommand.CommandText = "INSERT INTO CustomersTest VALUES('Bill', 'Gates','123 Apple Street', 221)";
            oracleCommand.ExecuteNonQuery();
            oracleCommand.CommandText = "INSERT INTO CustomersTest VALUES('Steve', 'Jobs','123 Microsoft Ave', 222)";
            oracleCommand.ExecuteNonQuery();
        }

        public void DropTable()
        {
            oracleCommand.CommandText = "Drop table CustomersTest";
            oracleCommand.ExecuteNonQuery();
            oracleConnection.Close();
        }

        public Customer getCustomer(string lastname)
        {
            Customer cust = null;
            try { 
            oracleCommand.CommandText = "select * from CustomersTest where LastName = '" + lastname + "'";
            oracleDataReader = oracleCommand.ExecuteReader();
            while (oracleDataReader.Read())
            {
                cust = new Customer(oracleDataReader[0].ToString(), oracleDataReader[1].ToString(), oracleDataReader[2].ToString(), Convert.ToInt32(oracleDataReader[3]));
            }
            }catch(OracleException e)
            {
                throw e;
            }
            return cust;
        }

        public void changeAddress(string lastname, string firstname, string newAdd)
        {
                //Handles execpetion is user doesnt view data before updating address
            if(firstname == "" || lastname == "" || newAdd == "")
            {
                //do nothing
            }
            else
            {
                int intrests = 0;
                oracleCommand.CommandText = "select * from CustomersTest WHERE LastName = '" + lastname + "'";
                oracleDataReader = oracleCommand.ExecuteReader();
                while (oracleDataReader.Read())
                {
                    intrests = Convert.ToInt32(oracleDataReader["Intrests"]);

                }
                oracleCommand.CommandText = "delete from CustomersTest WHERE LastName = '" + lastname + "'";
                oracleCommand.ExecuteNonQuery();
                oracleCommand.CommandText = "INSERT INTO CustomersTest VALUES('" + firstname + "', '" + lastname + "','" + newAdd + "','" + intrests + "')";
                oracleCommand.ExecuteNonQuery();
            }
        }
            

}
}
