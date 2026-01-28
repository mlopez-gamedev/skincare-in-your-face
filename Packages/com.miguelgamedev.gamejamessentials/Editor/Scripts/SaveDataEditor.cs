using UnityEngine;
using UnityEditor;
using System.IO;

namespace MiguelGameDev.Editor
{
    public class SaveDataEditor
    {
        [MenuItem("Miguel GameDev/Saved Data/Delete All")]
        static void DeleteAllData()
        {
            string[] files = Directory.GetFiles(Application.persistentDataPath);
            for (int i = 0; i < files.Length; ++i)
            {
                File.Delete(files[i]);
            }
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }

        [MenuItem("Miguel GameDev/Saved Data/Delete PlayerPrefs")]
        static void DeletePlayerPrefsData()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}