using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    float time = 0f;
    float gameTime;
    public GameObject prefab;
    Text score;
    Text timeRecord;
    // Start is called before the first frame update
    void Start()
    {
        gameTime = 0.0f;   // 게임 시간 측정
        score = GameObject.Find("Canvas").transform.Find("Enemy_cnt_text").GetComponent<Text>();  // 컴포넌트 연결
        timeRecord = GameObject.Find("Canvas").transform.Find("Time_text").GetComponent<Text>(); // 연결
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        //10초 동안만 생성
        if(gameTime <= 20f)
        {
            // 실시간 시간을 더합니다.
            if (time > 1.0f)  // 만약 1초가 지났다면,
            {
                time -= 1.0f;       // 1초를 빼고
                respawnMissile();   // respawnMissile() 이라는 함수를 호출합니다.
                EnemyController.totalEnemy_cnt++;              // 미사일이 추가될 때 마다 카운트를 올립니다.
            }
        }

        score.text = "Enemy Count : " + EnemyController.totalEnemy_cnt.ToString();    // 리스폰시 사용하는 카운트를 연결
        timeRecord.text = "Time : " + gameTime.ToString("N2");   // 제한 시간을 연결합니다. N2는 소숫점 둘째짜리까지 출력
        gameTime += Time.deltaTime;     // 실시간으로 증가시킵니다.

    }

    void respawnMissile()
    {
        float x = 14f;
        float y = 5.47f;

        int rand = Random.Range(0, 4);
        // 4방향 중 한 군데를 랜덤으로 호출합니다. 0부터 3까지 랜덤입니다.
        // 예 : 0 > 왼쪽 1 > 오른쪽 2 > 위쪽 3 > 아래쪽
        switch (rand)
        {
            case 0:
                newUnit(-x, Random.Range(0.0f, y * 2) - y);
                break;
            case 1:
                newUnit(x, Random.Range(0.0f, y * 2) - y);
                break;
            case 2:
                newUnit(Random.Range(0.0f, x * 2) - x, y);
                break;
            case 3:
                newUnit(Random.Range(0.0f, x * 2) - x, -y);
                break;
            default:
                Debug.Log("I don't care. :D ");
                break;
        }
    }

    void newUnit(float x, float y)
    {
        Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);
        
    }

}
