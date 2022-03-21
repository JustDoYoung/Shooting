using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//������ ǥ���ϰ� �ʹ�.
//������ ���ŵǸ� UI���� �ݿ��ϰ� �ʹ�.
//���� �Ѿ˰� �ε����� ������ 1�� ������Ű�� �ʹ�.
//ScoreManager�� ���� ��ü(������Ʈ)�� ��𼭵� �����ϰ� �ʹ�.
//�̱��� �������� ����� �ʹ�.(������ ���� : ���α׷��� �ʽ�)
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; //static : instance ������ class ScoreManager�� ��! ��ü�� ���� �ƴ�

    private void Awake()
    {
        ScoreManager.instance = this; //class�� ������� ��ü�� �ڱ��ڽ��� �θ� �� : this
    }

    //Score=====================================================================================
    int score; //����Ʈ ���� 0
    public Text textScore; //Text�� �ش�Ǹ� using ã�� �� : alt + Enter, ��ü�� ����Ʈ ���� null

    //�ܺο����� score�� ������ �� �ְ� get, set�Լ��� ����� ���.***
    //public int GetScore()
    //{
    //    return score;
    //}
    //public void SetScore(int value)
    //{
    //    this.score = value;
    //    textScore.text = score + " ��"; //string
    //}

    //property : �Լ��ε� ����ó�� ����� �� �ִ�.
    public int SCORE
    {
        get { return score; }
        set
        {
            this.score = value;
            textScore.text = "Your Score : " + score + " ��"; //string
            //���࿡ ���������� �ְ��������� ũ��
            if (score > bestScore)
            {
                //�ְ������� ���������� �����ϰ� �ʹ�.
                BESTSCORE = score;
                //�ְ������� ���Ϸ� �����ϰ� �ʹ�.
                PlayerPrefs.SetInt("BESTSCORE", score);
            }
        }
    }

    //BestScore=====================================================================================
    int bestScore;
    public Text textBestScore;

    public int BESTSCORE
    {
        get { return bestScore; } 
        set
        {
            this.bestScore = value;
            textBestScore.text = "Best Score : " + bestScore + " ��";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //�¾ �� ������ 0������ �ϰ� UI���� 0���̶�� ǥ���ϰ� �ʹ�.
        //SetScore(0);
        SCORE = 0; //set
        //int a = SCORE; //get
        //�¾ �� �ְ������� �ҷ����� �ʹ�.(���������)
        BESTSCORE = PlayerPrefs.GetInt("BESTSCORE", 0); //��������� BESTSCORE Ű�� ���� ���� �����´�. ���� ������ 0�� �⺻�̴�.
    }
}
