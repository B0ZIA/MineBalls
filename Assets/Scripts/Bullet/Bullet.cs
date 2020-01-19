using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public const string TAG = "bullet";

    [SerializeField]
    private float moveSpeed = 10;
    private new Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigidbody2D.velocity = rigidbody2D.velocity.normalized * moveSpeed;

        if (CheckBulletIsOutOfScreen())
        {
            RemoveBullet();
        }
    }

    private bool CheckBulletIsOutOfScreen()
    {
        if (transform.position.x < -5 || transform.position.x > 20
                    || transform.position.y < -5 || transform.position.y > 20)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void RemoveBullet()
    {
        Debug.Log("Pocisk spierdolił poza ekran");
        Ground.Instance.RemoveBullet(this);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == Ground.TAG)
        {
            BulletManager.Instance.RemoveBullet(this);
            Destroy(gameObject);
        }
    }

    public void SetSpeed(float speed)
    {
        moveSpeed = speed;
    }
}
