using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speeding : MonoBehaviour
{
    public const float normalBulletSpeed = 10f;
    public const float boostedBulletSpeed = 60f;



    public void SpeedUp()
    {
        BulletManager.Instance.SetBulletsSpeed(boostedBulletSpeed);
        BulletManager.Instance.allBulletsSpeedup = true;
        BulletSpawner.timeBeetwenSpawn = 0.01f;
        Ground.Instance.AllBulletsReturned += ResetBulletSpeed;
    }

    public void ResetBulletSpeed()
    {
        BulletManager.Instance.SetBulletsSpeed(normalBulletSpeed);
        BulletManager.Instance.allBulletsSpeedup = false;
        BulletSpawner.timeBeetwenSpawn = 0.1f;
    }
}
