using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

namespace working_with_files_2
{
    static class Program
    {
       public static List<Equipment> equipmentList = new List<Equipment>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void addEquipment (Equipment item)
        {
            equipmentList.Add(item);
        }

        public static void removeEquipment(string name)
        {
            if (equipmentList.Count > 0)
            { 
                foreach (Equipment eachItem in equipmentList.ToList())
                {
                    if (eachItem.EquipmentName.Equals(name))
                    {
                        equipmentList.Remove(eachItem);
                    }
                }
            }
        }

        public static void Save()
        {
            Stream TestFileStream = File.Create("equipmentData.bin");
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(TestFileStream, equipmentList);
            TestFileStream.Close();
        }

        public static void Load()
        {
            if (File.Exists("equipmentData.bin"))
            {
                Stream TestFileStream = File.OpenRead("equipmentData.bin");
                BinaryFormatter deserializer = new BinaryFormatter();
                equipmentList = (List<Equipment>)deserializer.Deserialize(TestFileStream);
                TestFileStream.Close();
            }
        }
    }
}
