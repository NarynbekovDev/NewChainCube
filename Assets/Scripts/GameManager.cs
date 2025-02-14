using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int languege;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        languege = PlayerPrefs.GetInt("languege", languege);
    }

    public void RestartGame()
    {
        // Получаем текущую активную сцену и перезагружаем её
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        // Завершаем приложение (работает только в сборке)
        Application.Quit();
        Debug.Log("Game exited"); // Для проверки в редакторе
    }

    public void RussianLanguenge()
    {
        languege = 0;
        PlayerPrefs.SetInt("langeuge", languege);
    }

    public void EnglishLanguenge()
    {
        languege = 1;
        PlayerPrefs.SetInt("langeuge", languege);
    }

    public void TurkishLanguenge()
    {
        languege = 2;
        PlayerPrefs.SetInt("langeuge", languege);
    }
}
