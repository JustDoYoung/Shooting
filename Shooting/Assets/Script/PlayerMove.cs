using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //[HideInInspector] : public�ε� ����Ƽ ������Ʈ �Ӽ��� �� ��Ÿ���� �ϰ� �ʹ�.
    public float speed = 5f;
    //[SerializeField] : private�ε� ����Ƽ ������Ʈ �Ӽ��� ��Ÿ���� �ϰ� �ʹ�.

    void Update()
    {
        //������ġ���� �̵�(�����¿�)
        //�̵����� P = P0 + vt
        //���ӵ����� v = v0 + at
        //���ǰ��� f = ma;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, v, 0);
        dir.Normalize();

        transform.position += dir * speed * Time.deltaTime;
    }
}
