using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{

    public void ChangeScene(int numberScenes)
    {
        SceneManager.LoadScene("love");
        Time.timeScale = 1f;
    }
}