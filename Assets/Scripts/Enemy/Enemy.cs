using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private bool IsDeactive = false;

    private const string BULLET_TAG = "bullet";
    [SerializeField]
    private Text text;
    [SerializeField]
    private Image image;
    [SerializeField]
    private EnemySprite enemySprite;

    private int partsToGameover = 8;

    private int hp;
    public int Hp
    {
        set
        {
            hp = value;

            if (value <= 0)
                Die();

            image.sprite = SetTexture(hp);

            text.text = value.ToString();
        }
    }



    public void Init(int hp, bool active)
    {
        IsDeactive = !active;
        if (!IsDeactive)
        {
            Hp = hp;
            image.sprite = SetTexture(hp);
        }

        PlayerLevel.Instance.OnPlayerLevelUp += LevelUp;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == BULLET_TAG)
        {
            Hp = hp - 1;
        }
    }

    private void Die()
    {
        IsDeactive = true;
        Destroy(text.gameObject);
        image.color = new Color();
        GetComponent<Collider2D>().isTrigger = true;
    }

    private Sprite SetTexture(int hp)
    {
        int i = hp / 10;

        if (enemySprite.sprites.Length <= i)
            return enemySprite.sprites[enemySprite.sprites.Length-1];

        return enemySprite.sprites[i];
    }

    private void LevelUp()
    {
        partsToGameover--;

        if (!IsDeactive)
        {
            if (partsToGameover <= 0)
                GameManager.Instance.GameOver();
        }
        else
        {
            if (partsToGameover <= 0)
            {
                PlayerLevel.Instance.OnPlayerLevelUp -= LevelUp;
                Destroy(this.gameObject);
            }
        }
    }
}
