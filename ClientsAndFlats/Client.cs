using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB_RieltorCompany
{
    class Client
    {
        #region свой.ва
        public int id;
        int phoneNumber;
        string name;
        string adress;
        string eMail;
        public Client(string stroka)
        {
            string[] ItemsClient = stroka.Split(';');
            id = Convert.ToInt32(ItemsClient[0]);
            phoneNumber = Convert.ToInt32(ItemsClient[1]);
            this.name = ItemsClient[2];
            this.adress = ItemsClient[3];
            this.eMail = ItemsClient[4];
        }
        // private string[] ItemsClient;
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public int PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value.ToString();
            }
        }
        public string Adress
        {
            get
            {
                return adress;
            }
            set
            {
                adress = value.ToString();
            }
        }
        public string EMail
        {
            get
            {
                return eMail;
            }
            set
            {
                eMail = value.ToString();
            }
        }
        #endregion

        
        public string ToString(string delimeter)
        {
            string outS = "";
            //foreach (string item in this.ItemsClient)
            //{
              //  outS += item + delimeter;
            //}
            outS += id + delimeter + phoneNumber + delimeter + name + delimeter + adress + delimeter + eMail;
            return outS;
        }
        public override string ToString()
        {
            return this.ToString(";");
        }
    }
}
