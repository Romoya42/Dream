using UnityEngine;
using UnityEngine.SceneManagement;

public class S_MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Yann");
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
