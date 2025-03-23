using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager
{
    public static void save_data(Custom data)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        string saveFileName = "CustomData";
        string savePath = Application.persistentDataPath + "/" + saveFileName;

        FileStream fileStream = new FileStream(savePath, FileMode.Create);
        CustomData customdata = new CustomData(data);

        binaryFormatter.Serialize(fileStream, customdata);
        fileStream.Close();
    }

    public static CustomData load_data()
    {
        string saveFileName = "CustomData";
        string loadPath = Application.persistentDataPath + "/" + saveFileName;

        if(File.Exists(loadPath))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(loadPath, FileMode.Open);

            CustomData customData = binaryFormatter.Deserialize(fileStream) as CustomData;
            fileStream.Close();

            return customData;
        }
        else
        {
            return null;
        }
    }
}
