using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class BPos
{
    public float posX;
    public float posY;
    public float posZ;
    public BPos(float posX, float posY, float posZ)
    {
        this.posX = posX;
        this.posY = posY;
        this.posZ = posZ;
    }
}
public class BossController : MonoBehaviour
{
    public GameObject hpbar;

    public float currentHp = 100f;
    public float totalHp = 100f;
    BPos[] bpos = new BPos[5];

    float movingTimer = 0f;
    public float speed = 0f;
    bool isMortal = false;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position = new Vector3(10f, 0f, 0f);
        bpos[0] = new BPos(0f, 0f, 0f); //중앙
        bpos[1] = new BPos(-7f, 0f, 0f); //왼
        bpos[2] = new BPos(7f, 0f, 0f); //오른
        bpos[3] = new BPos(0f, 3.5f, 0f); //위쪽
        bpos[4] = new BPos(0f, -3.5f, 0f); //아래
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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

    void Move()
    {
        movingTimer += Time.deltaTime;
        
    }
}
