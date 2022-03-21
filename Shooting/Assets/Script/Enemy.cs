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


    //�������� �ε��� ���� ȣ��
    //�������� �ε����� ���߰��忡�� ������ ���� �� ��ġ�� ������ ����ʹ�.
    public GameObject explosionFactory;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;
        ParticleSystem ps = explosion.GetComponent<ParticleSystem>(); //Play on awake ��ɱ���
        ps.Play();
        Destroy(explosion); //3�� �� �ı�(shuriken ���);

        //Enemy�� ���������� �ε��� ��Ȳ
        //Player�� �� Bullet�� �� �����ϰ� �ʹ�.
        //���� ������ �̸��� "Bullet" ���ڿ��� ���ԵǾ� �ִٸ� ������ 1�� ������Ű�� �ʹ�.(ScoreManager.cs)
        if (collision.gameObject.name.Contains("Bullet"))
        {
            // 1. ScoreManager ���ӿ�����Ʈ�� ã�Ƽ�
            // 2. �� ���ӿ�����Ʈ�κ��� ScoreManager ������Ʈ�� �޾ƿ��� �ʹ�.
            // 3. ScoreManager ������Ʈ�� ������ 1�� ������Ű�� �ʹ�.

            //GetScore(), SetScore() (ScoreManager.cs ����, 24��° ��)
            //GameObject scoreManagerGo = GameObject.Find("ScoreManager");
            //ScoreManager sm = scoreManagerGo.GetComponent<ScoreManager>();
            //int score = sm.GetScore() + 1;
            //sm.SetScore(score);

            //�̱���(ScoreManager.cs ����, 14��° ��)
            //int score = ScoreManager.instance.GetScore() + 1;
            //ScoreManager.instance.SetScore(score);

            //property : get, set(ScoreManager.cs ����, 36��° ��)
            ScoreManager.instance.SCORE ++; //SCORE�� set ����� ȣ���ؼ� 1�� �����ش�.
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name.Contains("Player"))
        {
            //"�÷��̾�� �ε�����." ��� �������� ����.

            //���� �ε����� �� ü���� 1 ���ҽ�Ű�� �ʹ�.(PlayerHP.cs ����)
            PlayerHP php = collision.gameObject.GetComponent<PlayerHP>();
            php.HP--;
            //���� �÷��̾��� ü���� 0���϶��
            if(php.HP <= 0)
            {
                //�÷��̾� �׾�.
                Destroy(collision.gameObject);
                //�÷��̾ �ı��� �� GameOverUI�� Ȱ��ȭ�ϰ� �ʹ�.
                GameManager.instance.GameOverUI.SetActive(true);
            }
        }
        Destroy(gameObject);
    }
}
