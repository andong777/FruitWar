using UnityEngine;
using System.Collections;

public class SaveLoad {

    private static SaveLoad _instance = new SaveLoad();
    private static object _lock = new object();

    const int start = 1;
    const int recordsPerPage = 5;
    const int maxRecords = 30;
    int cursor; // cursor to read records

    private SaveLoad() {
        cursor = start;
    }

    public static SaveLoad Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new SaveLoad();
                }
            }
            return _instance;
        }
    }

    public void ResetCursor()
    {
        cursor = start;
    }

    public void Save(Data data)
    {
        if (data.score <= 0)    // invalid record
            return;
        string oldName = data.name;
        int oldScore = data.score;
        Debug.Log("Save: " + oldName + " " + oldScore);
        int i = start;
        while (i <= maxRecords && PlayerPrefs.HasKey(i + "Name"))
        {
            
            int score = PlayerPrefs.GetInt(i + "Score");
            if (oldScore > score)
            {
                string name = PlayerPrefs.GetString(i + "Name");
                PlayerPrefs.SetString(i + "Name", oldName);
                PlayerPrefs.SetInt(i + "Score", oldScore);
                oldName = name;
                oldScore = score;
            }
            i++;
        }

        PlayerPrefs.SetString(i + "Name", oldName);
        PlayerPrefs.SetInt(i + "Score", oldScore);
    }

    public int HighScore()
    {
        if (PlayerPrefs.HasKey("1Name"))
        {
            return PlayerPrefs.GetInt("1Score");
        }
        else
        {
            return 0;
        }
    }

    public Data[] Prev()
    {
        int i = 0;
        var page = new Data[recordsPerPage];
        Debug.Log("---Prev---"+cursor);
        cursor = cursor - recordsPerPage >= start ? cursor - recordsPerPage : start;
        while (i < recordsPerPage && PlayerPrefs.HasKey(cursor + "Name"))
        {
            string name = PlayerPrefs.GetString(cursor + "Name");
            int score = PlayerPrefs.GetInt(cursor + "Score");
            page[i++] = new Data(cursor, name, score);
            
            cursor ++;
        }
        return page;
    }

    public Data[] Next()
    {
        int i=0;
        var page = new Data[recordsPerPage];
        Debug.Log("---Next---"+cursor);
        while (i < recordsPerPage && PlayerPrefs.HasKey(cursor + "Name"))
        {
            string name = PlayerPrefs.GetString(cursor + "Name");
            int score = PlayerPrefs.GetInt(cursor + "Score");
            page[i++] = new Data(cursor, name, score);
            
            cursor ++;
        }
        return page;
    }

    // only for test
    public void Dump()
    {
        Clean();
        Save(new Data("an", 10000));
        Save(new Data("dong", 20000));
        Save(new Data("qi", 15000));
        Save(new Data("andong", 30000));
        Save(new Data("dongan", 35000));
        Save(new Data("andong777", 70000));
    }

    // only for test
    public void Clean()
    {
        int i = 0;
        while(PlayerPrefs.HasKey(i+"Name")){
            PlayerPrefs.DeleteKey(i+"Name");
            PlayerPrefs.DeleteKey(i+"Score");
            i++;
        }
    }

    public struct Data {
        public int no;
        public string name;
        public int score;

        // for saving
        public Data (string name, int score){
            no = 0;   // no use here
            this.name = name;
            this.score = score;
        }
        // for loading, containing rank number
        public Data(int no, string name, int score)
        {
            this.no = no;
            this.name = name;
            this.score = score;
        }
    }
}
