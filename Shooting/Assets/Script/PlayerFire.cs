using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public GameObject firePosition;
    // Update is called once per frame
    void Update()
    {
        //Input.GetMouseButtonDown(0 or 1 or 2) : 0 ���콺 ����, 1 ���콺 ������, 2 ���콺 ��
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePosition.transform.position;
        }
    }
}
