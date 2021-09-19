using UnityEngine;

public class WeaponScrolling : MonoBehaviour
{
    [SerializeField] GameObject scrollingPanel;

    public void BeginScroll()
    {
        scrollingPanel.SetActive(true);
        Time.timeScale = 0.2f;
    }
    public void EndScroll()
    {
        scrollingPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
