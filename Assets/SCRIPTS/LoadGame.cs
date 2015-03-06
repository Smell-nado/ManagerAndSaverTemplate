using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour {
    GameManager GM;

    bool _isLoaded = false;
    Slider thisSlider;

	// Use this for initialization
	void Start () {
        thisSlider = GetComponent<Slider>();

        GM = GameManager.Instance;
        GM.OnStateChange += StartGameScene;

        StartCoroutine("LoadingBarAnim");
	}

    void OnDisable()
    {
        GM.OnStateChange -= StartGameScene;
    }

    IEnumerator LoadingBarAnim()
    {
        thisSlider.value += 0.01f;

        yield return new WaitForEndOfFrame();

        if (thisSlider.value >= 1)
            _isLoaded = true;

        if (!_isLoaded)
            StartCoroutine("LoadingBarAnim");
        else
        {
            GM.SetGameState(GameState.MainMenu);
            StopCoroutine("LoadingBarAnim");
        }
    }

    void StartGameScene()
    {
        Application.LoadLevel("MainMenu");
    }
}
