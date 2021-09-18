using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private Slider slider;

    private void Start()
    {
        CharacterLook.lookSensitivity = 15;
    }

    private void Update()
    {
        CharacterLook.lookSensitivity = slider.value;
    }

    public void PauseMenu()
    {
        MenuPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        MenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
