using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VNCreator
{
    public static class GameSaveManager
{
    public static string currentLoadName = string.Empty;

    // Metode untuk memuat data dengan nama tertentu
    public static List<string> Load(string loadName)
    {
        if (loadName == string.Empty)
        {
            currentLoadName = loadName;
            return null;
        }

        // Memeriksa apakah ada data tersimpan dengan nama yang diberikan
        if (!PlayerPrefs.HasKey(currentLoadName))
        {
            Debug.LogError("You have not saved anything with the name " + currentLoadName);
            return null;
        }

        // Mendapatkan data yang tersimpan dalam bentuk string
        string _loadString = PlayerPrefs.GetString(currentLoadName);
        // Memisahkan string menjadi elemen-elemen berdasarkan tanda '_' dan mengubahnya menjadi daftar
        List<string> _loadList = _loadString.Split('_').ToList();
        // Menghapus elemen terakhir yang kosong dari daftar
        _loadList.RemoveAt(_loadList.Count - 1);
        currentLoadName = loadName;
        return _loadList;
    }

    // Metode untuk memuat data tanpa menentukan nama
    public static List<string> Load()
    {
        if (currentLoadName == string.Empty)
        {
            return null;
        }

        // Memeriksa apakah ada data tersimpan dengan nama yang saat ini aktif
        if (!PlayerPrefs.HasKey(currentLoadName))
        {
            Debug.LogError("You have not saved anything with the name " + currentLoadName);
            return null;
        }

        // Mendapatkan data yang tersimpan dalam bentuk string
        string _loadString = PlayerPrefs.GetString(currentLoadName);
        // Memisahkan string menjadi elemen-elemen berdasarkan tanda '_' dan mengubahnya menjadi daftar
        List<string> _loadList = _loadString.Split('_').ToList();
        return _loadList;
    }

    // Metode untuk menyimpan data
    public static void Save(List<string> storyPath)
    {
        // Menggabungkan elemen-elemen daftar menjadi satu string dengan tanda '_' sebagai pemisah
        string _save = string.Join("_", storyPath.ToArray());
        // Menyimpan string hasil gabungan ke dalam PlayerPrefs dengan nama yang aktif
        PlayerPrefs.SetString(currentLoadName, _save);
    }

    // Metode untuk memulai pembebanan data baru dengan nama tertentu
    public static void NewLoad(string saveName)
    {
        // Menetapkan nama pembebanan yang baru
        currentLoadName = saveName;
        // Menyimpan string kosong dalam PlayerPrefs dengan nama yang baru
        PlayerPrefs.SetString(saveName, string.Empty);
    }
}

}
