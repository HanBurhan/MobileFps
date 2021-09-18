using UnityEngine;

public class CharacterLook : MonoBehaviour
{
    [SerializeField] Transform player;
    public static float lookSensitivity;
    [SerializeField] float minLookAngle;
    [SerializeField] float maxLookAngle;

    private float upLook = 0;

    private void LateUpdate()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x > Screen.width / 2 && touch.phase == TouchPhase.Began)
            {
                float xLook = touch.deltaPosition.x * lookSensitivity * Time.fixedDeltaTime;
                float yLook = touch.deltaPosition.y * lookSensitivity * Time.fixedDeltaTime;

                upLook -= yLook;
                upLook = Mathf.Clamp(upLook, minLookAngle, maxLookAngle);

                transform.localRotation = Quaternion.Euler(upLook, 0, 0);

                player.Rotate(Vector3.up * xLook);
            }
        }
    }
}
