using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager Instance;
    public bool allBulletsSpeedup = false;

    private List<Bullet> bullets = new List<Bullet>();


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void SetBulletsSpeed(float speed)
    {
        foreach (var bullet in bullets)
        {
            if(bullet.gameObject != null)
                bullet.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.01f;
            bullet.SetSpeed(speed);
        }
    }

    private void Update()
    {
        if (allBulletsSpeedup)
        {
            SetBulletsSpeed(Speeding.boostedBulletSpeed);
        }
    }

    public void AddBullet(Bullet bullet)
    {
        bullets.Add(bullet);
    }

    public void RemoveBullet(Bullet bullet)
    {
        bullets.Remove(bullet);
    }
}
