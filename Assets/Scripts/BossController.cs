using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject hpbar;

    public float currentHp = 100f;
    public float totalHp = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        hpbar.transform.localScale = new Vector3(currentHp / totalHp * 0.05f,
            hpbar.transform.localScale.y, hpbar.transform.localScale.z);

        if (currentHp <= 0f)
            Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
            currentHp -= 10;
    }
}
