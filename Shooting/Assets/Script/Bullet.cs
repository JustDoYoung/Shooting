using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    // Update is called once per frame
    void Update()
    {
        //������ǥ�� ���� Vector3.up
        //�����ǥ : transform.up �ٵ� transform.down�� ���� -> -transform.up���� ��Ÿ���� ����.
        Vector3 dir = transform.up;
        transform.position += dir * speed * Time.deltaTime;
    }
}
