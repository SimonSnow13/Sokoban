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
    //检测关卡是否完成及完成后执行相应操作的方法
    public void CheckFinish() 
    {
        if (finishedBoxes == totalBoxes) 
        {
            Debug.Log( "You win!");
            StartCoroutine(LoadNextStage());
        }
    }
    //等待两秒后进入下一场景
    IEnumerator LoadNextStage()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //重置关卡的方法
    void ResetStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
