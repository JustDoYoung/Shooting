using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//점수를 표현하고 싶다.
//점수가 갱신되면 UI에도 반영하고 싶다.
//적이 총알과 부딪히면 점수를 1점 증가시키고 싶다.
//ScoreManager로 만든 객체(컴포넌트)를 어디서든 접근하고 싶다.
//싱글톤 패턴으로 만들고 싶다.(디자인 패턴 : 프로그래밍 초식)
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; //static : instance 변수는 class ScoreManager의 것! 객체의 것이 아님

    private void Awake()
    {
        ScoreManager.instance = this; //class로 만들어진 객체가 자기자신을 부를 때 : this
    }

    //Score=====================================================================================
    int score; //디폴트 값은 0
    public Text textScore; //Text에 해당되면 using 찾는 법 : alt + Enter, 객체의 디폴트 값은 null

    //외부에서도 score를 조작할 수 있게 get, set함수를 만들어 줬다.***
    //public int GetScore()
    //{
    //    return score;
    //}
    //public void SetScore(int value)
    //{
    //    this.score = value;
    //    textScore.text = score + " 점"; //string
    //}

    //property : 함수인데 변수처럼 사용할 수 있다.
    public int SCORE
    {
        get { return score; }
        set
        {
            this.score = value;
            textScore.text = "Your Score : " + score + " 점"; //string
            //만약에 현재점수가 최고점수보다 크면
            if (score > bestScore)
            {
                //최고점수를 현재점수로 갱신하고 싶다.
                BESTSCORE = score;
                //최고점수를 파일로 저장하고 싶다.
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
            textBestScore.text = "Best Score : " + bestScore + " 점";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //태어날 때 점수를 0점으로 하고 UI에도 0점이라고 표현하고 싶다.
        //SetScore(0);
        SCORE = 0; //set
        //int a = SCORE; //get
        //태어날 때 최고점수를 불러오고 싶다.(파일입출력)
        BESTSCORE = PlayerPrefs.GetInt("BESTSCORE", 0); //저장공간에 BESTSCORE 키를 가진 값을 가져온다. 값이 없으면 0이 기본이다.
    }
}
