using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int totalBoxes;
    public int finishedBoxes;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            ResetStage();
        }
    }
    //���ؿ��Ƿ���ɼ���ɺ�ִ����Ӧ�����ķ���
    public void CheckFinish() 
    {
        if (finishedBoxes == totalBoxes) 
        {
            Debug.Log( "You win!");
            StartCoroutine(LoadNextStage());
        }
    }
    //�ȴ�����������һ����
    IEnumerator LoadNextStage()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //���ùؿ��ķ���
    void ResetStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
