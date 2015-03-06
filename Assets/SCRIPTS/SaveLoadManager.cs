//Please see this video (start halfway): www.youtube.com/watch?v=J6FfcJpbPXE#t=114
//This works everywhere but the web browser build

//We probably want to make this a singleton -- Try making a singleton as a gameobject that is derived from Monobehaviour

using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadManager : MonoBehaviour {

    public int Health { get { return _health; } set { value = _health; } }
    [SerializeField] int _health = 1000;

    public int Experience { get { return _experience; } set { value = _experience; } }
    [SerializeField]int _experience = 120000;

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();//Makes a binary version of the save file
        FileStream file = File.Create(Application.persistentDataPath + "/PlayerInfo.dat");//Saves it in a persistent data path depending on platform
        Debug.Log("Save File Location: " + Application.persistentDataPath);

        PlayerData data = new PlayerData(); //Create the data below
        data.health = _health;
        data.experience = _experience;

        bf.Serialize(file, data);//Serializaed the data to the file.
        file.Close();//Closes the file
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/PlayerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/PlayerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file); //If you notice we are casting it.
            file.Close();

            _health = data.health;
            _experience = data.experience;
        }
    }
}

[Serializable] //This data will get serialized and I need to write this so Unity will know
class PlayerData
{
    //Any data you want to save
    public int health;
    public int experience;
}