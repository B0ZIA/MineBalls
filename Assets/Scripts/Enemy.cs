using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro text;

    [SerializeField]
    private int hp;
    private int Hp
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;

            if (value <= 0)
                Die();

            text.text = value.ToString();
        }
    }

    public void Init(int hp)
    {
        Hp = hp;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "bullet")
        {
            Hp--;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
