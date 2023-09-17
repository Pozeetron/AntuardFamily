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

    public void LoadLevel(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void PauseMenu()
    {
        Time.timeScale = 0;
    }

    public void BackButton()
    {
        Time.timeScale = 1;
    }

    public void NextButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
}
