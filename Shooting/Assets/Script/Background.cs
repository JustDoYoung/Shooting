using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//배경을 스크롤하고 싶다
public class Background : MonoBehaviour
{
    //재질
    Material mat; //cache : 자주 쓰는 정보를 변수에 담아둔다.
    //스크롤 속도
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        //태어날 때 재질을 기억했다가
        MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>(); //느린 함수기 때문에 한 번 실행 후 정보를 변수 mat에 담아둔다.
        mat = renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        //살아가면서 재질의 offset값을 위로 이동하고 싶다.
        mat.mainTextureOffset += Vector2.up * speed * Time.deltaTime;
    }
}
