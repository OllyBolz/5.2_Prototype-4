using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 2f;

    private bool hasPowerUp = false;

    public GameObject bulletPrefab;
    private GameObject tempBullet;

    private PowerUpType currentPowerUpType;
	public Coroutine powerUpCountDown;
	private GameObject focalPoint;

	void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        if (currentPowerUpType == PowerUpType.Bullet && Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullets();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            currentPowerUpType = other.gameObject.GetComponent<PowerUp>().powerUpType;
            Destroy(other.gameObject);

            if (powerUpCountDown != null)
            {
                StopCoroutine(powerUpCountDown);
            }
            powerUpCountDown = StartCoroutine(PowerUpCountDown());
        }
    }

    IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(15);
        hasPowerUp = false;
        currentPowerUpType = PowerUpType.None;
    }

    private void ShootBullets()
    {
        foreach (var enemy in FindObjectsOfType<Enemy>())
        {
            tempBullet = Instantiate(bulletPrefab, transform.position + Vector3.up, Quaternion.identity);
            tempBullet.GetComponent<Bullet>().Shoot(enemy.transform);
        }
    }
}
