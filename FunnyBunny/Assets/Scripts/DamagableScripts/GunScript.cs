using System.Collections;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform player;
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float shootCooldown = 1f;
    float timer;

    Coroutine shootCoroutine;

    /*
    void OnEnable()
    {
        shootCoroutine = StartCoroutine(ShootLoop());
    }

    void OnDisable()
    {
        if (shootCoroutine != null)
        {
            StopCoroutine(shootCoroutine);
            shootCoroutine = null;
        }
    }
    */

    private void Awake()
    {
        StopShooting();
    }

    private void Update()
    {
        if (player == null) return;

        Vector2 targetPos = player.position;
        Vector2 firePos = firePoint.position;

        Vector2 dir = (targetPos - firePos).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        angle += 180f;

        //Debug.Log($"angle = {angle}");

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void StartShooting()
    {
        shootCoroutine = StartCoroutine(ShootLoop());
    }

    public void StopShooting()
    {
        if (shootCoroutine != null)
        {
            StopCoroutine(shootCoroutine);
            shootCoroutine = null;
        }
    }

    IEnumerator ShootLoop()
    {
        while (true)
        {
            if (player != null && bulletPrefab != null && firePoint != null)
            {
                Shoot();
            }

            yield return new WaitForSeconds(shootCooldown);
        }
    }

    void Shoot()
    {
        if (player == null) return;

        Vector2 targetPos = player.position;
        Vector2 firePos = firePoint.position;

        Vector2 dir = (targetPos - firePos).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        angle += 180f;

        //Debug.Log($"angle = {angle}");

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        GameObject bulletGO = Instantiate(bulletPrefab, firePos, Quaternion.identity);
        BulletScript bullet = bulletGO.GetComponent<BulletScript>();
        bullet.SetDirection(dir);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("EXIT");
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("BANG BANG DESTROY BULLET");
            other.gameObject.GetComponent<BulletScript>().Destroy();
        }
    }
}
