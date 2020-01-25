using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace BaseOfCarsRemadeVersion
{
    class CarManager // Singleton
    {
      /*  static CarManager managerInstance;

        protected CarManager()
        {
        }

        public static CarManager Instance()
        {
            if (managerInstance == null)
                managerInstance = new CarManager();

            return managerInstance;
        }*/

        StorageManager storageManager = new StorageManager();

        public List<AbstractCar> GetCollection()
        {
            return storageManager.cars;
        }

        //Collection for Search
        List<AbstractCar> findList = null;

        public void AddCar(AbstractCar car)
        {
            storageManager.cars.Add(car);
        }

        public void DeleteCarString(int i)
        {
            storageManager.cars.RemoveAt(i);
        }

        public void Find(string pattern)
        {
            pattern = pattern.Trim();
            // Regex for the finder
            var regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            findList = new List<AbstractCar>();

            foreach (var item in storageManager.cars)
            {
                if (regex.IsMatch((string)item.owner) | regex.IsMatch((string)item.model) | regex.IsMatch((string)item.color) | regex.IsMatch((string)item.speed))
                {
                    findList.Add(item);
                }
            }
        }
        public void DeleteAllCars()
        {
            storageManager.cars.Clear();
        }

        public void SaveFile()
        {
            storageManager.SaveCarsToFile();
        }

        public void OpenFile()
        {
            storageManager.OpenCarsFromFile();
        }























        /* static CarManager uniqueInstance;      

        protected CarManager()
        {
        }

        public static CarManager Instance()
        {
            if (uniqueInstance == null)
                uniqueInstance = new CarManager();

            return uniqueInstance;
        }*/

        /* string singletonData = string.Empty;

         public void SingletonOperation()
         {
             singletonData = "SingletonData";
         }

         public string GetSingletonData()
         {
             return singletonData;
         }*/


    }
}
