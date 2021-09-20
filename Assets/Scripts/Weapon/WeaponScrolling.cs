using UnityEngine;

public class WeaponScrolling : MonoBehaviour
{
    [SerializeField] GameObject scrollingPanel;

    public static bool isScrolling;

    public void BeginScroll()
    {
        scrollingPanel.SetActive(true);
        Time.timeScale = 0.2f;
        isScrolling = true;
    }
    public void EndScroll()
    {
        scrollingPanel.SetActive(false);
        Time.timeScale = 1f;
        isScrolling = false;
    }
}
