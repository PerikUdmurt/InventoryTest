using InventoryTest.Services.SaveLoad;
using System;
using System.IO;
using UnityEngine;

namespace InventoryTest.Services.FileData
{
    public class FileDataService
    {
        private string dataDirPath = "";
        private string dataFileName = "";

        public FileDataService(string dataDirPath, string dataFileName)
        {
            this.dataDirPath = dataDirPath;
            this.dataFileName = dataFileName;
        }

        public GameData Load() 
        { 
            string fullPath = Path.Combine(dataDirPath, dataFileName);
            GameData loadedData = null;

            if (File.Exists(fullPath))
            {
                try
                {
                    string dataToLoad = "";
                    using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            dataToLoad = reader.ReadToEnd();
                        }
                    }
                    loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
                }
                catch (Exception)
                {
                    Debug.LogError("Ошибка при попытке загрузки данных из файл, записаны новые данные");
                    Save(new GameData());
                }
            }
            return loadedData;
        }

        public void Save(GameData gameData) 
        { 
            string fullpath = Path.Combine(dataDirPath, dataFileName);
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fullpath));
                string data = JsonUtility.ToJson(gameData);

                using (FileStream stream = new FileStream(fullpath, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.Write(data);
                    }
                }
            }
            catch(Exception)
            {
                Debug.LogError("Ошибка при попытке сохранения данных в файл");
            }
        }
    }
}
