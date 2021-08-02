using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

namespace FPP.Scripts.Systems
{
    public class SaveSystem
    {
        private readonly string _filePath = Application.persistentDataPath + "/player.data";

        public void SavePlayer(Player player)
        {
            FileStream dataStream = new FileStream(_filePath, FileMode.Create);
            BinaryFormatter converter = new BinaryFormatter();

            converter.Serialize(dataStream, player);
            dataStream.Close();
        }
        
        public Player LoadPlayer()
        {
            if (File.Exists(_filePath))
            {
                FileStream dataStream = new FileStream(_filePath, FileMode.Open);
                BinaryFormatter converter = new BinaryFormatter();
                Player saveData = converter.Deserialize(dataStream) as Player;

                dataStream.Close();
                return saveData;
            }

            return null;
        }
    }
}