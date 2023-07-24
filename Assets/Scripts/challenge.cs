using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class challenge : MonoBehaviour
{
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
        Time.timeScale = 1.0f;
    }

    public void Challenge()
    {
        SceneManager.LoadScene("Challenge");
        Time.timeScale = 1.0f;

    }
    public void Level1()
    {
        SceneManager.LoadScene("LEVEL1");
        Time.timeScale = 1.0f;


    }
    public void Level2()
    {
        SceneManager.LoadScene("LEVEL2");
        Time.timeScale = 1.0f;


    }
    public void Level3()
    {
        SceneManager.LoadScene("LEVEL3");
        Time.timeScale = 1.0f;



    }
    public void Level4()
    {
        SceneManager.LoadScene("LEVEL4");
        Time.timeScale = 1.0f;



    }
    public void Level5()
    {
        SceneManager.LoadScene("LEVEL5");
        Time.timeScale = 1.0f;



    }
}
