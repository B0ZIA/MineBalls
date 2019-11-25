using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField]
    private bool aim = false;
    [SerializeField]
    private bool bulletsAreFlying = false;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Ground ground;
    [SerializeField]
    private EnemySpawner enemySpawner;
    [SerializeField]
    private PlayerLevel playerLevel;
    private Vector2 lastMouseClickPos;
    private Vector2 endPos;



    public void AllBulletsDestroyed()
    {
        bulletsAreFlying = false;
        playerLevel.LevelUp();
        enemySpawner.MoveSeries();
        enemySpawner.SpawnSeries();
    }

    void Update()
    {
        if (aim)
        {
            endPos = (Vector2)transform.position + (lastMouseClickPos - (Vector2)Input.mousePosition);
            Debug.DrawRay(transform.position, endPos/15, Color.green);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (aim && !bulletsAreFlying)
            {
                StartCoroutine(StartShooting(playerLevel.GetLevel()));
            }
        }

        SetAim();
    }

    private void SetAim()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            lastMouseClickPos = Input.mousePosition;
        }

        if (Input.mousePosition.y < lastMouseClickPos.y - 50 && Input.GetKey(KeyCode.Mouse0))
        {
            aim = true;
        }
        else
        {
            aim = false;
        }
    }

    IEnumerator StartShooting(int count)
    {
        ground.Reset(count);
        bulletsAreFlying = true;
        for (int i = 0; i < count; i++)
        {
            CreateBullet();
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

    void CreateBullet()
    {
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(endPos);
    }
}
