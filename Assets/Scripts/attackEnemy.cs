using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackEnemy : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletPrefab;
    private GameObject playerSprite;
    private Vector3 target;
    private float bulletSpeed = 20.0f;
    private float playerSpeed = 10.0f;
    private float delay = 0;
    private bool repeaterMode = false;

    void Start()
    {
        playerSprite = GameObject.Find("PlayerSprite");
    }

    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 90f;
        playerSprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (Input.GetKeyDown(KeyCode.E))
        {
            repeaterMode = !repeaterMode;
            Debug.Log(repeaterMode);
        }

        if (Input.GetMouseButtonDown(0) && !repeaterMode)
        {
            fire(difference, rotationZ);
        }

        if (Input.GetMouseButton(0) && repeaterMode)
        {
            delay += Time.deltaTime;
            if (delay >= 0.1)
            {
                fire(difference, rotationZ);
                delay = 0;
            }
        }
    }

    void fire(Vector3 difference, float rotationZ)
    {
        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        direction.Normalize();
        fireBullet(direction, rotationZ);
    }

    void fireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = player.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}