using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    // Update is called once per frame
    void Update()
    {
        //절대좌표의 방향 Vector3.up
        //상대좌표 : transform.up 근데 transform.down은 없다 -> -transform.up으로 나타내면 가능.
        Vector3 dir = transform.up;
        transform.position += dir * speed * Time.deltaTime;
    }
}
