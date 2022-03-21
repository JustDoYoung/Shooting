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
        //Input.GetMouseButtonDown(0 or 1 or 2) : 0 마우스 왼쪽, 1 마우스 오른쪽, 2 마우스 휠
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePosition.transform.position;
        }
    }
}
