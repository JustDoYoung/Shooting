using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �������� ���ؼ� �̵��ϰ�ʹ�.
public class Tail : MonoBehaviour
{
    // �ӷ�
    public float speed = 4;
    // ������
    public GameObject target;

    void Start()
    {
    }

    void Update()
    {
        // 1. �������� ���ϴ� ������ �����
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        // 2. �� �������� �̵��ϰ�ʹ�.
        transform.position += dir * speed * Time.deltaTime;
    }
}
