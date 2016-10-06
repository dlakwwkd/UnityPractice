using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    static ScoreManager _instance = null;
    public static ScoreManager Instance()
    {
        return _instance;
    }

	void Start ()
    {
        if (_instance == null)
        {
            _instance = this;
            LoadBestScore();
        }
        else
            Destroy(gameObject);
	}


    int _bestScore = 0;
    int _myScore = 0;

    public int bestScore
    {
        get
        {
            return _bestScore;
        }
    }

    public int myScore
    {
        get
        {
            return _myScore;
        }
        set
        {
            _myScore = value;
            if(_myScore > _bestScore)
            {
                _bestScore = myScore;
                SaveBestScore();
            }
        }
    }
	

    void SaveBestScore()
    {
        PlayerPrefs.SetInt("Best Score", _bestScore);
    }

    void LoadBestScore()
    {
        _bestScore = PlayerPrefs.GetInt("Best Score", 0);
    }
}
