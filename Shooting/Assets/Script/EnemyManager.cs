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
            //���࿡ ���ӿ����� ���� �ʾҴٸ� = GamaOverUI�� ��Ȱ��ȭ ���¶��
            if (GameManager.instance.GameOverUI.activeSelf == false)
            {
                //�� ����.
                GameObject enemy = Instantiate(enemyFactory);
                enemy.transform.position = transform.position;
            }
            currentTime = 0;
        }
    }
}
