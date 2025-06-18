using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); // �������� �� ���� ����� � �����
    }

    public void OpenSettings()
    {
        // ����� ������ �������� ��������
        Debug.Log("������� ���������");
    }

    public void ShowBestTime()
    {
        // ����� ������� ������ �����
        Debug.Log("������ �����: " + PlayerPrefs.GetFloat("BestTime", 0));
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("����� �� ����");
    }
}
