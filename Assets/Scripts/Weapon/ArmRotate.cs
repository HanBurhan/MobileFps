using UnityEngine;

public class ArmRotate : MonoBehaviour
{
    [SerializeField] private float turnSmooth;

    Transform cameraPos;

    void Start()
    {
        cameraPos = Camera.main.transform;
    }

    private void LateUpdate()
    {
        float xAxis = cameraPos.transform.eulerAngles.x;
        float yAxis = cameraPos.transform.eulerAngles.y;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(xAxis, yAxis, 0), turnSmooth * Time.deltaTime);
    }
}
