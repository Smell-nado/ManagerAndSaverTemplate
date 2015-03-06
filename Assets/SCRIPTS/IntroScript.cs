using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour {
    GameManager GM;

    public bool HasPlayed { get { return _hasPlayed; } set { value = _hasPlayed; } }
    bool _hasPlayed = false;

    void Start()
    {
        GM = GameManager.Instance;
        GM.OnStateChange += HandleStateToLoad;

        GM.SetGameState(GameState.Intro);//this broadcasts to Game Manager to change the state from NUll to Intro.
    }
	void OnDisable()//Needed or Unity totally crashes
    {
        GM.OnStateChange -= HandleStateToLoad;
    }

    public void HandleStateToLoad()
    {
        if (_hasPlayed)
        {
            Application.LoadLevel("LoadScene");
        }
        else
        {
            StartCoroutine("PlayAnimation");
        }
    }

    IEnumerator PlayAnimation()
    {
        Debug.Log("Start Animation");
        yield return new WaitForSeconds(3);
        Debug.Log("End Animation");
        _hasPlayed = true;
        Application.LoadLevel("LoadScene");
    }
}
