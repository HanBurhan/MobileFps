using UnityEngine;

public class WeaponScrolling : MonoBehaviour
{
    [SerializeField] GameObject scrollingPanel;
    [SerializeField] GameObject[] weapons;

    public static int currentWeaponIndex;

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

    public void SelectRifle()
    {
        currentWeaponIndex = 0;
        weapons[0].SetActive(true);
        weapons[1].SetActive(false);
        weapons[2].SetActive(false);
    }
    public void SelectSmg()
    {
        currentWeaponIndex = 1;
        weapons[1].SetActive(true);
        weapons[0].SetActive(false);
        weapons[2].SetActive(false);
    }
    public void SelectShotGun()
    {
        currentWeaponIndex = 2;
        weapons[2].SetActive(true);
        weapons[0].SetActive(false);
        weapons[1].SetActive(false);
    }
}
