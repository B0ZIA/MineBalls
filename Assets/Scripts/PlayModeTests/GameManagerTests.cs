using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManagerTest
{
    [UnityTest]
    public IEnumerator LoadGameScene()
    {
        GameObject gameObject = new GameObject();
        GameManager gameManager = gameObject.AddComponent<GameManager>();
        int startSceneIndex = SceneManager.GetActiveScene().buildIndex;

        gameManager.StartGame();
        yield return null;
        int endSceneIndex = SceneManager.GetActiveScene().buildIndex;

        Assert.AreEqual(GameManager.GAME_SCENE_INDEX, endSceneIndex);
        Assert.AreNotEqual(startSceneIndex, endSceneIndex);
    }
}
