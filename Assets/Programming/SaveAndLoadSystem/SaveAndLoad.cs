using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveAndLoad
{

    public static List<int> SavedStarsList = new List<int>();

    public static int count0, count1, count2, count3;

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/sgs1_2.mdb");
        for (int i = 1; i < 61; i++)
        {
            if (PlayerPrefs.HasKey("Stars" + i.ToString()))
                SavedStarsList.Add(PlayerPrefs.GetInt("Stars" + i.ToString()));
            else
                SavedStarsList.Add(0);


        }

        bf.Serialize(file, SavedStarsList);
        file.Close();
       SavedStarsList.Clear();
    }

    public static void Load()
    {
        int sound = PlayerPrefs.GetInt("SoundOff");
        PlayerPrefs.DeleteAll();


        PlayerPrefs.SetInt("SoundOff", sound);
        if (File.Exists(Application.persistentDataPath + "/sgs1_2.mdb"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/sgs1_2.mdb", FileMode.Open);
            SavedStarsList = (List<int>) bf.Deserialize(file);
            file.Close();

            for (int i = 1; i < 61; i++)
            {


                 PlayerPrefs.SetInt(("Stars" + i.ToString()), SavedStarsList[i-1]);
                

            }

        }
        SavedStarsList.Clear();
    }

    public static void SaveAllStarAndHelp(int count, int whatIsIt)
    {
        switch (whatIsIt)
        {
            case 0:
                BinaryFormatter bf0 = new BinaryFormatter();
                FileStream file0 = File.Create(Application.persistentDataPath + "/sgp2.mdb");
                bf0.Serialize(file0, count);
                file0.Close();
                break;
            case 1:
                BinaryFormatter bf1 = new BinaryFormatter();
                FileStream file1 = File.Create(Application.persistentDataPath + "/sgpah1.mdb");
                bf1.Serialize(file1, count);
                file1.Close();
                break;
            case 2:
                BinaryFormatter bf2 = new BinaryFormatter();
                FileStream file2 = File.Create(Application.persistentDataPath + "/sgpah2.mdb");
                bf2.Serialize(file2, count);
                file2.Close();
                break;
            case 3:
                BinaryFormatter bf3 = new BinaryFormatter();
                FileStream file3 = File.Create(Application.persistentDataPath + "/smp.mdb");
                bf3.Serialize(file3, count);
                file3.Close();
                break;
        }
    }


    public static int LoadAllStar()
    {
        if (File.Exists(Application.persistentDataPath + "/sgp2.mdb"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/sgp2.mdb", FileMode.Open);
            count0 = (int) bf.Deserialize(file);
            file.Close();
        }
        else
        {
            count0 = 0;
        }
        return count0;
    }

    public static int LoadAnsw()
    {
        if (File.Exists(Application.persistentDataPath + "/sgpah1.mdb"))
        {
            BinaryFormatter bf1 = new BinaryFormatter();
            FileStream file1 = File.Open(Application.persistentDataPath + "/sgpah1.mdb", FileMode.Open);
            count1 = (int)bf1.Deserialize(file1);
            file1.Close();
        }
        else
        {
            count1 = 3;
        }
        return count1;
    }

    public static int LoadTwoAns()
    {

        if (File.Exists(Application.persistentDataPath + "/sgpah2.mdb"))
        {
            BinaryFormatter bf2 = new BinaryFormatter();
            FileStream file2 = File.Open(Application.persistentDataPath + "/sgpah2.mdb", FileMode.Open);
            count2 = (int)bf2.Deserialize(file2);
            file2.Close();
        }
        else
        {
            count2 = 2;
        }
        return count2;
    }

    public static int LoadMarathon()
    {
        if (File.Exists(Application.persistentDataPath + "/smp.mdb"))
        {
            BinaryFormatter bf3 = new BinaryFormatter();
            FileStream file3 = File.Open(Application.persistentDataPath + "/smp.mdb", FileMode.Open);
            count3 = (int)bf3.Deserialize(file3);
            file3.Close();

        }
        else
        {
            count3 = 0;
        }
        return count3;
    }


}
