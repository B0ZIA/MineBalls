using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Ground : MonoBehaviour
{
    private int currentCounter;
    [SerializeField]
    private BulletSpawner bulletSpawner;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "bullet")
        {
            currentCounter--;

            if (currentCounter == 0)
                bulletSpawner.AllBulletsDestroyed();
        }
    }

    public void Reset(int bullet)
    {
        currentCounter = bullet;
    }
}
