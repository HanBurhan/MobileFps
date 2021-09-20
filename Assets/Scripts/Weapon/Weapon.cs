using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] AudioClip readySound, fireSound;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] GameObject impactEffect;
    [SerializeField] private float rifleCoolDown = 0.12f;

    private AudioSource source;
    private Animator anim;

    private float fireRate;
    private float weaponDamage;
    public WeaponType weaponType;
    

    private void Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        if (weaponType == WeaponType.rifle)
        {
            weaponDamage = 2f;
        }
        else if (weaponType == WeaponType.smg)
        {
            weaponDamage = 1.5f;
        }
        else if (weaponType == WeaponType.shotgun)
        {
            weaponDamage = 2.5f;
        }
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 ray = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        Physics.Raycast(ray, Camera.main.transform.forward, out hit);

        if (hit.transform != null && hit.transform.tag == "Enemy" && Time.time > fireRate)
        {
            Fire();
            fireRate = Time.time + rifleCoolDown;

            hit.transform.GetComponent<EnemyCombat>().TakeDamage(weaponDamage);
            GameObject newImpact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }

    public void Fire()
    {
        anim.SetTrigger("Fire");

        source.clip = fireSound;
        source.Play();
        muzzleFlash.Play();
    }

    public void ReadySound()
    {
        source.PlayOneShot(readySound);
    }

    public enum WeaponType { rifle, smg, shotgun};
}
