using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 4f;
    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        int randValue = Random.Range(0, 10);
        if (randValue < 3)
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }


    //누군가와 부딪힌 순간 호출
    //누군가와 부딪히면 폭발공장에서 폭발을 만들어서 내 위치에 가져다 놓고싶다.
    public GameObject explosionFactory;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;
        ParticleSystem ps = explosion.GetComponent<ParticleSystem>(); //Play on awake 기능구현
        ps.Play();
        Destroy(explosion); //3초 뒤 파괴(shuriken 대신);

        //Enemy가 누구군가와 부딪힌 상황
        //Player인 지 Bullet인 지 구분하고 싶다.
        //만약 상대방의 이름에 "Bullet" 문자열이 포함되어 있다면 점수를 1점 증가시키고 싶다.(ScoreManager.cs)
        if (collision.gameObject.name.Contains("Bullet"))
        {
            // 1. ScoreManager 게임오브젝트를 찾아서
            // 2. 그 게임오브젝트로부터 ScoreManager 컴포넌트를 받아오고 싶다.
            // 3. ScoreManager 컴포넌트의 점수를 1점 증가시키고 싶다.

            //GetScore(), SetScore() (ScoreManager.cs 참고, 24번째 줄)
            //GameObject scoreManagerGo = GameObject.Find("ScoreManager");
            //ScoreManager sm = scoreManagerGo.GetComponent<ScoreManager>();
            //int score = sm.GetScore() + 1;
            //sm.SetScore(score);

            //싱글톤(ScoreManager.cs 참고, 14번째 줄)
            //int score = ScoreManager.instance.GetScore() + 1;
            //ScoreManager.instance.SetScore(score);

            //property : get, set(ScoreManager.cs 참고, 36번째 줄)
            ScoreManager.instance.SCORE ++; //SCORE의 set 기능을 호출해서 1씩 더해준다.
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name.Contains("Player"))
        {
            //"플레이어와 부딪혔다." 라는 조건으로 들어옴.

            //적과 부딪혔을 때 체력을 1 감소시키고 싶다.(PlayerHP.cs 참고)
            PlayerHP php = collision.gameObject.GetComponent<PlayerHP>();
            php.HP--;
            //만약 플레이어의 체력이 0이하라면
            if(php.HP <= 0)
            {
                //플레이어 죽어.
                Destroy(collision.gameObject);
                //플레이어가 파괴될 때 GameOverUI를 활성화하고 싶다.
                GameManager.instance.GameOverUI.SetActive(true);
            }
        }
        Destroy(gameObject);
    }
}
