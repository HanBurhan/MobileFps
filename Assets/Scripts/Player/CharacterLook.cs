using UnityEngine;

public class CharacterLook : MonoBehaviour
{
    [SerializeField] Transform player;
    public static float lookSensitivity;
    [SerializeField] float minLookAngle;
    [SerializeField] float maxLookAngle;

    private float upLook = 0;

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x > Screen.width / 2 && touch.phase == TouchPhase.Moved)
            {
                float xLook = touch.deltaPosition.x * lookSensitivity * Time.deltaTime;
                float yLook = touch.deltaPosition.y * lookSensitivity * Time.deltaTime;

                upLook -= yLook;
                upLook = Mathf.Clamp(upLook, minLookAngle, maxLookAngle);

                transform.localRotation = Quaternion.Euler(upLook, 0, 0);

                player.Rotate(Vector3.up * xLook);
            }
        }
    }
}
