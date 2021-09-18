using UnityEngine;

public class LaserSight : MonoBehaviour
{
    private LineRenderer laser;

    public static bool enemyDetected;

    private void Start()
    {
        laser = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 ray = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        Physics.Raycast(ray, Camera.main.transform.forward, out hit);

        Vector3 laserDsitance = new Vector3(0, 0, hit.distance);
        Vector3 target = hit.point - transform.position;

        laser.transform.localScale = laserDsitance;
        laser.transform.rotation = Quaternion.LookRotation(target, Vector3.up);

        if (hit.transform != null && hit.transform.tag == "Enemy")
        {
            enemyDetected = true;
        }
        else { enemyDetected = false; }
    }
}
