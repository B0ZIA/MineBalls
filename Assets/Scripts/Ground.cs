using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Ground : MonoBehaviour
{
    public static Ground Instance;
    public const string TAG = "ground";

    public delegate void ReturnBullets();
    public ReturnBullets AllBulletsReturned;

    [SerializeField]
    private BulletSpawner bulletSpawner;

    private List<Bullet> bulletsToReturn = new List<Bullet>();



    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == Bullet.TAG)
        {
            RemoveBullet(other.collider.GetComponent<Bullet>());
        }
    }

    public void AddBullet(Bullet bullet)
    {
        bulletsToReturn.Add(bullet);
    }

    public void RemoveBullet(Bullet bullet)
    {
        foreach (var currentBullet in bulletsToReturn)
        {
            if (currentBullet == bullet)
            {
                bulletsToReturn.Remove(bullet);

                if (bulletsToReturn.Count <= 0 && AllBulletsReturned != null)
                {
                    Debug.Log("pociski powróciły!");
                    AllBulletsReturned();
                    return;
                }
                return;
            }
        }

        Debug.LogWarning("Ground bullets list don't have bullet " + bullet);
    }
}
