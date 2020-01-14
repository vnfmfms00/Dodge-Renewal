using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static int totalEnemy_cnt = 0;
    GameObject target;
    [SerializeField] float speed = 0.0f;
    int collided_cnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        transform.eulerAngles = new Vector3(0, 0, -getAngle(transform.position.x,
            transform.position.y, target.transform.position.x, target.transform.position.y));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private float getAngle(float x1, float y1, float x2, float y2)
    {
        float dx = x2 - x1;
        float dy = y2 - y1;

        float rad = Mathf.Atan2(dx, dy);
        float degree = rad * Mathf.Rad2Deg;

        return degree;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            collided_cnt += 1;
        }

        if(collided_cnt >= 2 || collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            totalEnemy_cnt--;
        }
    }
}
