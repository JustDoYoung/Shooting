using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //[HideInInspector] : public인데 유니티 컴포넌트 속성에 안 나타나게 하고 싶다.
    public float speed = 5f;
    //[SerializeField] : private인데 유니티 컴포넌트 속성에 나타나게 하고 싶다.

    void Update()
    {
        //현재위치에서 이동(상하좌우)
        //이동공식 P = P0 + vt
        //가속도공식 v = v0 + at
        //힘의공식 f = ma;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, v, 0);
        dir.Normalize();

        transform.position += dir * speed * Time.deltaTime;
    }
}
