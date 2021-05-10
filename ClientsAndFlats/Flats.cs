using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace DB_RieltorCompany
{
    class Flats
    {

        private List<Flat> listFlat = new List<Flat>();
        const string titleConst = "id;Тип Недвижимости;Количество комнат;Этаж;Площадь;Цена;Адрес;Описание;Клиент";
        public int flatsCount { get { return listFlat.Count; } }//длинна листа
        Clients clients;

        #region Properties
        public string Title//возращает значение константы
        { get { return titleConst; } }



        /// Вычисляет номер строки по ID, если не находит, то выводит -1

        public int getNumberByID(int id)
        {
            for (int i = 0; i < this.listFlat.Count; i++)
            {
                if (this.listFlat[i].id == id) { return i; }
            }
            return -1;

        }

        public int nextId //поиск нового айди
        {
            get
            {
                int m = int.MinValue;
                foreach (Flat f in this.listFlat)
                {
                    if (f.id > m)
                    {
                        m = f.id;
                    }
                }
                return m + 1;
            }
        }
        #endregion


        public Flats(string fileName, Clients clientss) //конструктор по строке
        {
            string[] massivStrok = File.ReadAllLines(fileName, Encoding.Default);
            clients = clientss;
            //getClienT(clientss);
            //int n = 0;
            
            for (int i = 0; i < massivStrok.Length; i++)
            {
                //foreach (Flat F in this.listFlat)
                //    n = listFlat[listFlat.Count-1].id ;
                    
                //n += 1;
                Flat f = new Flat(massivStrok[i], clientss)
                {
                    FlatCount = flatsCount,
                    //id = n
                };

                listFlat.Add(f);
            }
        }


        //public void getClienT(Clients clients)
        //{
        //    for (int i = 0; i < flatsCount; i++)
        //    {

        //        for (int j = 0; j < clients.clientsCount; j++)
        //        {
        //            if (listFlat[i].ClientID == clients.getClient(j).id)
        //            {
        //                listFlat[i].clienttt = clients.getClient(j);
        //                break;
        //            }
        //        }
        //    }
        //}

        /////////// Вспомогательные методы
        public Flat getFlat(int number)
        {
            try
            {
                return listFlat[number];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void remove(Flat flat)//удаление строки
        {
            try
            {
                this.listFlat.Remove(flat);
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException("Ты не то удаляешь, скорее всего такого ID нет..." + e.Data);
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException("Ошибка индекс за пределами диапазона");
            }
        }

        public void add(Flat f)
        {
            this.listFlat.Add(f);
        }




        public void change(int Number, Flat newFlat)
        {
           this.listFlat[Number] = newFlat;
        }


        public void saveFlatsToFile()
        {
            string sOut = "";
            foreach (Flat f in this.listFlat)
            {
                sOut = sOut + f.conservation(";") + "\n";
            }

            File.WriteAllText("data.csv", sOut, Encoding.Default);


        }




    }
}
