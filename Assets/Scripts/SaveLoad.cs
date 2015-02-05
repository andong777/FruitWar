using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class SaveLoad : MonoBehaviour {

    private static SaveLoad _instance = null;
    const int start = 0;
    const int recordsPerPage = 5;
	const string leaderboardID = "com.andong777.fruitwar.leaderboard";

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

    public void Save(long score)
    {
		if (score == 0)
			return;

		Debug.Log ("--- Save ---");

		Social.localUser.Authenticate (success => {
			if (success) {
				Debug.Log ("Authentication successful");
				Social.ReportScore (score, leaderboardID, success2 => {
					Debug.Log(success2 ? "Reported score successfully" : "Failed to report score");
				});
			}
			else
				Debug.Log ("Authentication failed");
		});
    }

	public void Load()
	{
		Debug.Log("--- Load ---");

		Social.LoadScores (leaderboardID, scores => {
			Debug.Log ("Got " + scores.Length + " scores");
			data = new List<Data>();
			for(int i=0; i<scores.Length; i++){
				data[i] = new Data(scores[i].rank, scores[i].userID, scores[i].value);
			}
		});
	}

//    public long HighScore()
//    {
//        if (data == null || data.Count == 0)
//			return 0;
//		return int.Parse(data [0].score);
//    }

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
			page[i] = new Data(data[idx].id, data[idx].name, data[idx].score);
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
			page[i] = new Data(data[idx].id, data[idx].name, data[idx].score);
		}

		return page;
    }

    public struct Data {
        public int id;
        public string name;
        public long score;

        public Data(int _id, string _name, long _score)
        {
			id = _id;
			name = _name;
			score = _score;
        }
    }
}
