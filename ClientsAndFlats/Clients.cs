using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DB_RieltorCompany
{
    class Clients
    {
        private List<Client> listClient = new List<Client>();
        const string titleConst = "id;namber;name;adres;mail";
        public int clientsCount { get { return listClient.Count; } }
        #region Properties

        public string Title
        { get { return titleConst; } }

        public Client returnClient(int id)
        {
            int sch = 0;
                for (int j = 0; j < listClient.Count; j++)
                {
                    if (id == listClient[j].id)
                    {
                        sch = j;
                        break;
                    }
                }
            return listClient[sch];
        }


        #endregion
        public Clients(string fileName)
        {
            string[] massivStrok = File.ReadAllLines(fileName, Encoding.UTF8);
            for (int i = 0; i < massivStrok.Length; i++)
            {
                listClient.Add(new Client(massivStrok[i]));
            }
        }
        public Client getClient(int number)
        {
            try
            {
                return listClient[number];
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public void saveFlatsToFile()
        {
            string sOut = "";
            foreach (Client f in this.listClient)
            {
                sOut = sOut + f.ToString(";") + "\n";
            }

            File.WriteAllText("data.csv", sOut, Encoding.Default);


        }
    }
}
