using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.GameCenter;

public class SaveLoad : MonoBehaviour {

    private static SaveLoad _instance = null;
    const int start = 0;
    const int recordsPerPage = 5;
	const string leaderboardID = "com.andong777.fruitwar.leaderboard";

    int cursor; // cursor to read records
	List<Data> data = null;
	ILeaderboard m_Leaderboard;

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

	public void authenticate(){
		Social.localUser.Authenticate(success => {
			if (success) {
				Debug.Log ("Authenticated");
			}
			else{
				Debug.Log ("Failed to authenticate with Game Center.");
			}
		});
	}

    public void Save(long score)
    {
		if (score == 0)
			return;

		if(Social.localUser.authenticated){
			
			Social.ReportScore(score, leaderboardID, success => {
				if(success){
					Debug.Log ("--- Save ---");
				}
			});
		}else{
			Debug.Log("failed to save");
		}
    }

	public void Load()
	{
		if (Social.localUser.authenticated) {
			Debug.Log("--- Load ---");
			
			Social.LoadScores (leaderboardID, scores => {
				Debug.Log ("Got " + scores.Length + " scores");
				data = new List<Data>();
				for(int i=0; i<scores.Length; i++){
					data[i] = new Data(scores[i].rank, scores[i].userID, scores[i].value);
				}
			});
		}else{
			Debug.Log("failed to load");
		}
	}

//    public long HighScore()
//    {
//        if (data == null || data.Count == 0)
//			return 0;
//		return int.Parse(data [0].score);
//    }

	public void DoLeaderboard () {
//		if(m_Leaderboard == null){
//			m_Leaderboard = Social.CreateLeaderboard();
//			m_Leaderboard.id = leaderboardID;  // YOUR CUSTOM LEADERBOARD NAME
//			m_Leaderboard.LoadScores(result => {
//				Social.ShowLeaderboardUI();
//			});
//		}else{
			Social.ShowLeaderboardUI();
//		}
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
