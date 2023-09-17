using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void AgainButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void NextLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene(1);
    }
    
    public void LoadLevelTwo()
    {
        SceneManager.LoadScene(2);
    }
    
    public void LoadLevelThree()
    {
        SceneManager.LoadScene(3);
    }
    
    public void LoadLevelFour()
    {
        SceneManager.LoadScene(4);
    }
    
    public void LoadLevelFive()
    {
        SceneManager.LoadScene(5);
    }
}
