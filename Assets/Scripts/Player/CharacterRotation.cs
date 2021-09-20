using UnityEngine.EventSystems;
using UnityEngine;

public class CharacterRotation : MonoBehaviour, IDragHandler
{
    [SerializeField] Transform player;
    [SerializeField] Transform cam;

    [SerializeField] float minLookAngle;
    [SerializeField] float maxLookAngle;

    public static float lookSensitivity;
    private float upLook = 0;

    public void OnDrag(PointerEventData eventData)
    {
        if (!WeaponScrolling.isScrolling)
        {
            float xRot = eventData.delta.x * lookSensitivity * Time.fixedDeltaTime;
            float yRot = eventData.delta.y * lookSensitivity * Time.fixedDeltaTime;

            upLook -= yRot;
            upLook = Mathf.Clamp(upLook, minLookAngle, maxLookAngle);

            cam.localRotation = Quaternion.Euler(upLook, 0, 0);

            player.Rotate(Vector3.up * xRot);
        }
    }
}
