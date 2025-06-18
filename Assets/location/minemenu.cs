using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); // замените на вашу сцену с игрой
    }

    public void OpenSettings()
    {
        // Здесь логика открытия настроек
        Debug.Log("Открыть настройки");
    }

    public void ShowBestTime()
    {
        // Здесь выводим лучшее время
        Debug.Log("Лучшее время: " + PlayerPrefs.GetFloat("BestTime", 0));
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Выход из игры");
    }
}
