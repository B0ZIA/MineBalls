using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public const int GAME_SCENE_INDEX = 1;



	public void StartGame()
    {
        LoadGameScene();
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene(GAME_SCENE_INDEX);
    }

    public static void GameOver()
    {
        Debug.LogError("Game Over!");
    }
}
