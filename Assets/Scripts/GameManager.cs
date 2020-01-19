using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public const int GAME_SCENE_INDEX = 1;



    void Awake()
    {
        if (Instance == null)
            Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

	public void StartGame()
    {
        LoadGameScene();
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene(GAME_SCENE_INDEX);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Game Over!");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
