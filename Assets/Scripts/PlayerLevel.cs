using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    public static PlayerLevel Instance;
    private int level = 1;
    [SerializeField]
    private Text levelText;


    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public int GetLevel()
    {
        return level;
    }

    public void LevelUp()
    {
        level++;
        levelText.text = "Level: " + level.ToString();
    }
}
