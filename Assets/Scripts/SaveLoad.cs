using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class SaveLoad : MonoBehaviour {

    private static SaveLoad _instance = null;
    const int start = 0;
    const int recordsPerPage = 5;
	const string URL = "http://fruitwarrank.sinaapp.com/scores";

    int cursor; // cursor to read records
	List<Data> data = null;

	public static SaveLoad Instance {
		get
		{
			if (_instance == null)
			{                                   
				GameObject go = new GameObject("SaveLoadGameObject");
				DontDestroyOnLoad(go);
				_instance = go.AddComponent<SaveLoad>();
			}
			return _instance;
		}
	}

    public void ResetCursor()
    {
        cursor = start - recordsPerPage;
		Load ();
    }

    public void Save(Data data)
    {
        if (data.score <= 0)    // invalid record
            return;
        
		Debug.Log ("--- Save ---");
		var jsonString = JsonMapper.ToJson(data);
		Debug.Log (jsonString);
		var headers = new Dictionary<string, string> ();
		headers.Add ("Content-Type", "application/json");
		var scores = new WWW (URL, new System.Text.UTF8Encoding ().GetBytes (jsonString), headers);
		StartCoroutine (WaitForPost (scores));
    }

	IEnumerator WaitForPost(WWW www){
		yield return www;
		Debug.Log (www.text);
	}

	public void Load()
	{
		Debug.Log("--- Load ---");
		var scores = new WWW (URL);

		StartCoroutine(WaitForGet(scores));
	}

	IEnumerator WaitForGet(WWW www){
		yield return www;
		if (www.error == null && www.isDone) {
			var dataList = JsonMapper.ToObject<DataList>(www.text);
			data = dataList.data;
			GameObject.Find("Background").SendMessage("HandleNext");
		}else{
			Debug.Log ("Failed to connect to server!");
			Debug.Log (www.error);
		}
	}

    public int HighScore()
    {
        if (data == null || data.Count == 0)
			return 0;
		return data [0].score;
    }

    public Data[] Prev()
    {
		if (data == null || data.Count == 0)
			return null;

		if (cursor - recordsPerPage >= start)
			cursor = cursor - recordsPerPage;

		int size = cursor - start + 1 < recordsPerPage ? cursor - start + 1 : recordsPerPage;
		var page = new Data[size];
		
		for (int i = 0; i < size; i++) {
			int idx = cursor + i;
			page[i] = new Data(idx + 1, data[idx].name, data[idx].score);
		}

		return page;
    }

    public Data[] Next()
    {
		if (data == null || data.Count == 0)
			return null;

		if (cursor + recordsPerPage < data.Count)
			cursor = cursor + recordsPerPage;

		int size = data.Count - cursor < recordsPerPage ? data.Count - cursor : recordsPerPage;
		var page = new Data[size];

		for (int i = 0; i < size; i++) {
			int idx = cursor + i;
			page[i] = new Data(idx + 1, data[idx].name, data[idx].score);
		}

		return page;
    }

    public struct Data {
        public int id;
        public string name;
        public int score;

        // for saving
        public Data (string _name, int _score){
            id = 0;   // no use here
            name = _name;
            score = _score;
        }
        // for loading, containing rank number
        public Data(int _id, string _name, int _score)
        {
			id = _id;
			name = _name;
			score = _score;
        }
    }

	public class DataList {
		public List<Data> data;
	}
}
