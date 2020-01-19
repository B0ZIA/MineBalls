using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpritesData", menuName = "ScriptableObjects/EnemySpritesData", order = 1)]
public class EnemySprite : ScriptableObject
{
    public Sprite[] sprites;
}
