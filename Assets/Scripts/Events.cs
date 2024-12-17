using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Level()
    {
        SceneManager.LoadScene(1);
    }
      public void Levelsame()
    {
        SceneManager.LoadScene(1);
    }
    public void Levelnext()
    {
        SceneManager.LoadScene(2);
    }
    public void Levelnext2()
    {
        SceneManager.LoadScene(3);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
