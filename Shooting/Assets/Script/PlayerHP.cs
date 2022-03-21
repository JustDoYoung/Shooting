using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ü���� ǥ���ϰ� �ʹ�.
//���� �ε����� �� ü���� 1�� ���ҽ�Ű�� �ʹ�.(Enemy.cs)
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
        //���� �߿�! : �ڹٲ�� Player HP �ٰ� �� �� ��.
        //Slider�� maxValue�� maxHP�� �����ϰ� �ؾ� ��.
        sliderHP.maxValue = maxHP;
        //�¾ �� ü���� �ִ� ü������ �ϰ�ʹ�.
        HP = maxHP; //set
    }
}
