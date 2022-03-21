using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�÷��̾ �ı��� �� GameOverUI�� Ȱ��ȭ �ϰ� �ʹ�.
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject GameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        //�¾ �� GameOverUI�� ��Ȱ��ȭ �ϰ�ʹ�.
        GameOverUI.SetActive(false);
    }

    //Restart, Quit��ư�� �������� �� ȣ��� �Լ��� �����ϰ� �ʹ�.
    public void OnClickRestart()
    {
        //���� Scene�� �ٽ� �ε��ϰ� �ʹ�.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //file - build settings
    }
    public void OnClickQuit()
    {
        Application.Quit(); //Unity Editor���� �� �ǰ� �������Ϸ� �������� �� �۵�.
    }
}
