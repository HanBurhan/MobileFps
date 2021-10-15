using UnityEngine.SceneManagement;
using UnityEngine;

public class CharacterDamage : MonoBehaviour
{
    [Header("Stats")]
    public float playerHealth;

    private void Update()
    {
        if (playerHealth <= 0)
        {
            PlayerDie();
        }
    }

    private void PlayerDie()
    {
        SceneManager.LoadScene(0);
    }
}
