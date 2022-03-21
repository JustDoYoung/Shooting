using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//체력을 표현하고 싶다.
//적과 부딪혔을 대 체력을 1씩 감소시키고 싶다.(Enemy.cs)
public class PlayerHP : MonoBehaviour
{
    int hp;
    public int maxHP = 3;
    public Slider sliderHP;

    public int HP
    {
        get { return hp; }
        set
        {
            this.hp = value;
            sliderHP.value = hp;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //순서 중요! : 뒤바뀌면 Player HP 바가 꽉 안 참.
        //Slider에 maxValue를 maxHP와 동일하게 해야 됨.
        sliderHP.maxValue = maxHP;
        //태어날 때 체력을 최대 체력으로 하고싶다.
        HP = maxHP; //set
    }
}
