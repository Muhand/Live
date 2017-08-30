using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    [SerializeField]
    private Button musicBtn;

    [SerializeField]
    private Sprite[] musicIcons;

	// Use this for initialization
	void Start () {
        CheckToPlayMusic();
	}

    void CheckToPlayMusic()
    {
        if (GamePreferences.GetMusicState() == 1)
        {
            MusicController.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcons[1];
        } else
        {
            MusicController.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcons[0];
        }
    }

	// Update is called once per frame
	public void StartGame() {
        GameManager.instance.gameStartedFromMainMenu = true;
        SceneFader.instance.LoadLevel("Gameplay");
	}

    public void HighscoreMenu()
    {
        SceneManager.LoadScene("Highscore");
    }
    public void OptionsMenu()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void MusicButton()
    {
        if(GamePreferences.GetMusicState() == 0)
        {
            GamePreferences.SetMusicState(1);
            MusicController.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcons[1];
        } else
        {
            GamePreferences.SetMusicState(0);
            MusicController.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcons[0];
        }
    }
}
