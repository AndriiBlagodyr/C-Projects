using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BaseOfCarsRemadeVersion
{
    public class StorageManager
    {
        // Cars collection
        public List<AbstractCar> cars = null;

        SaveFileDialog mySaveFileDialog = new SaveFileDialog();
        OpenFileDialog myOpenFileDialog = new OpenFileDialog();

        // Cars collection for the finder
        //public List<Car> findList = null;

        public StorageManager()
        {
            cars = new List<AbstractCar>()
            {
                new SportCar ("Vasya", "Mersedes", "Black", "280"),
                new SportCar ("Peter", "Volga", "White", "220"),
                new SportCar ("Nikolay", "Volkswagen", "Blue", "240"),
            };
        }
      
        public void SaveCarsToFile()
        {
            // SaveDialog Windows properties  
        
            mySaveFileDialog.Filter = "car files (*.car)|*.car|All files(*.*)|*.*";
            mySaveFileDialog.FilterIndex = 1;
            mySaveFileDialog.FileName = "carDoc";

            // DialogResult.OK
            if (mySaveFileDialog.ShowDialog() == true) 
            {
                Stream myStream = mySaveFileDialog.OpenFile();
                // Binary Serialization
                var serializer = new BinaryFormatter();
                serializer.Serialize(myStream, cars);
                myStream.Close();
            }
        }

        public void OpenCarsFromFile()
        {
            // OpenDialog Windows properties 
   
            myOpenFileDialog.Filter = "car files (*.car)|*.car|All files(*.*)|*.*";
            myOpenFileDialog.FilterIndex = 1;
            myOpenFileDialog.RestoreDirectory = true;

            // Open saved file
            if (myOpenFileDialog.ShowDialog() == true) 
            {
                // Clear collection
                cars.Clear();
                //Deserialization of saved info
                Stream stream = myOpenFileDialog.OpenFile();
                var deserializer = new BinaryFormatter();
                cars = deserializer.Deserialize(stream) as List<AbstractCar>;
                stream.Close();    
            }
        }
    }
}
