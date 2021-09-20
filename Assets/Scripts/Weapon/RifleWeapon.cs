using UnityEngine;

public class RifleWeapon : MonoBehaviour
{
    [SerializeField] AudioClip readySound, fireSound;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] GameObject impactEffect;

    private AudioSource RifleSource;
    private Animator anim;

    private float fireRate;
    private float rifleCoolDown = 0.12f;

    private void Start()
    {
        RifleSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 ray = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        Physics.Raycast(ray, Camera.main.transform.forward, out hit);

        if (hit.transform != null && hit.transform.tag == "Enemy" && Time.time > fireRate)
        {
            RifleFire();
            fireRate = Time.time + rifleCoolDown;

            hit.transform.GetComponent<EnemyCombat>().TakeDamage(2);
            GameObject newImpact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }

    public void RifleFire()
    {
        anim.SetTrigger("Fire");

        RifleSource.clip = fireSound;
        RifleSource.Play();
        muzzleFlash.Play();
    }

    public void RifleReadySound()
    {
        RifleSource.PlayOneShot(readySound);
    }
}
