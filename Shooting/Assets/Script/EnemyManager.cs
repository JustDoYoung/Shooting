using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyFactory;
    float createTime;
    float currentTime = 0;
    public float maxTime;
    public float minTime;

    // Start is called before the first frame update
    void Start()
    {
        createTime = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > createTime)
        {
            //만약에 게임오버가 되지 않았다면 = GamaOverUI가 비활성화 상태라면
            if (GameManager.instance.GameOverUI.activeSelf == false)
            {
                //적 생성.
                GameObject enemy = Instantiate(enemyFactory);
                enemy.transform.position = transform.position;
            }
            currentTime = 0;
        }
    }
}
