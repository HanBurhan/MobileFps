using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject player;
    [SerializeField] private Slider slider;

    private AudioSource source;

    private void Start()
    {
        CharacterRotation.lookSensitivity = 15;
        source = player.GetComponent<AudioSource>();
    }

    private void Update()
    {
        CharacterRotation.lookSensitivity = slider.value;
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

    public void MenuSounds(AudioClip audio)
    {
        source.PlayOneShot(audio);
    }

    public void ScrollingSounds(AudioClip audio)
    {
        source.PlayOneShot(audio);
    }
}
