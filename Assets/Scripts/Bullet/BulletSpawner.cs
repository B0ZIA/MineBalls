using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletSpawner : MonoBehaviour
{
    public static float timeBeetwenSpawn = 0.1f;

    [SerializeField]
    private bool aim = false;
    [SerializeField]
    private bool bulletsAreFlying = false;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Ground ground;
    [SerializeField]
    private EnemyManager enemySpawner;
    [SerializeField]
    private PlayerLevel playerLevel;
    private Vector2 lastMouseClickPos;
    private Vector2 endPos;
    private LineRenderer lineRenderer;

    public Button bostBtn;
    public Button pauseBtn;



    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        ground.AllBulletsReturned += NextPart;
    }

    private void NextPart()
    {
        bulletsAreFlying = false;
        playerLevel.LevelUp();
        enemySpawner.SpawnSeries();
    }

    void Update()
    {
        if (bulletsAreFlying)
        {
            bostBtn.interactable = true;
            pauseBtn.interactable = false;
        }
        else
        {
            bostBtn.interactable = false;
            pauseBtn.interactable = true;
        }

        if (aim)
        {
            endPos = (Vector2)transform.position + (lastMouseClickPos - (Vector2)Input.mousePosition);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(0, endPos);
        }
        else
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(0, transform.position);
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
        bulletsAreFlying = true;

        for (int i = 0; i < count; i++)
        {
            ground.AddBullet(CreateBullet());
            yield return new WaitForSecondsRealtime(timeBeetwenSpawn);
        }
    }

    Bullet CreateBullet()
    {
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(endPos);
        BulletManager.Instance.AddBullet(bullet.GetComponent<Bullet>());

        return bullet.GetComponent<Bullet>();
    }
}
