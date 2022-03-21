using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����� ��ũ���ϰ� �ʹ�
public class Background : MonoBehaviour
{
    //����
    Material mat; //cache : ���� ���� ������ ������ ��Ƶд�.
    //��ũ�� �ӵ�
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        //�¾ �� ������ ����ߴٰ�
        MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>(); //���� �Լ��� ������ �� �� ���� �� ������ ���� mat�� ��Ƶд�.
        mat = renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        //��ư��鼭 ������ offset���� ���� �̵��ϰ� �ʹ�.
        mat.mainTextureOffset += Vector2.up * speed * Time.deltaTime;
    }
}
