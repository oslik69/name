using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB_RieltorCompany
{
    class Flat
    {
        public int FlatCount;
        #region Свойства

        public int id;
        string realtyType;
        int roomsCount;
        int floor;
        int area;
        int price;
        string address;
        public Client clienttt;
        string description;
        int clientID;


        

        //private string[] Items; //массив объектов строки
        public Flat(string stroka, Clients clients)
        {
            try
            {

                string[] ItemsClient = stroka.Split(';');
                id = Convert.ToInt32(ItemsClient[0]);
                realtyType = ItemsClient[1];
                roomsCount = Convert.ToInt32(ItemsClient[2]);
                floor = Convert.ToInt32(ItemsClient[3]);
                area = Convert.ToInt32(ItemsClient[4]);
                price = Convert.ToInt32(ItemsClient[5]);
                address = ItemsClient[6];
                description = ItemsClient[7];
                clientID = Convert.ToInt32(ItemsClient[8]);
                this.clienttt = clients.returnClient(clientID);
            }
            catch
            {
                 throw;

            }
        }

        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string RealtyType
        {
            get
            {
                return realtyType;
            }
            set
            {
                realtyType = value.ToString();
            }
        }

        public int RoomsCount
        {
            get
            {
                return roomsCount;
            }
            set
            {
                roomsCount = value;
            }
        }

        public int Floor
        {
            get
            {
                return floor;
            }
            set
            {
                floor = value;
            }
        }
        public int Area
        {
            get
            {
                return area;
            }
            set
            {
                area = value;
            }
        }
        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value.ToString();
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value.ToString();
            }
        }
        public int ClientID
        {
            get
            {
                return clientID;
            }
            set
            {
                clientID = value;
            }
        }

        #endregion


        

        public string ToString(string delimeter) 
        {
            string outS = "";
            //foreach (string item in this.Items)
            //{
            //outS += item + delimeter;
            //}
            outS += id + delimeter + realtyType + delimeter + roomsCount + delimeter + floor + delimeter + area + delimeter + price + delimeter + address + delimeter + description + delimeter + clienttt.Name;
            return outS;
        }
        public string conservation(string delimeter)
        {
            string outS = "";
            //foreach (string item in this.Items)
            //{
            //outS += item + delimeter;
            //}
            outS += id + delimeter + realtyType + delimeter + roomsCount + delimeter + floor + delimeter + area + delimeter + price + delimeter + address + delimeter + description + delimeter + ClientID;
            return outS;
        }

        public override string ToString()
        {
            return this.ToString(";");
        }


    }
}
