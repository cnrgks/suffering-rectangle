using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void CloseButton()
    {
        Application.Quit();
    }
}
