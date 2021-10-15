using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] AudioClip readySound, fireSound;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] GameObject impactEffect;
    [SerializeField] private float fireCoolDown = 0.12f;

    private AudioSource source;
    private Animator anim;
    private bool fireable;

    private float fireRate;
    private float weaponDamage;
    public WeaponType weaponType;
    

    private void Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        if (weaponType == WeaponType.rifle)
        {
            weaponDamage = .5f;
        }
        else if (weaponType == WeaponType.smg)
        {
            weaponDamage = .3f;
        }
        else if (weaponType == WeaponType.shotgun)
        {
            weaponDamage = 1f;
        }
    }

    private void Update()
    {
        if (fireable)
        {
            OpenFire();
        }
    }

    public void SetFireableTrue()
    {
        fireable = true;
    }

    public void SetFireableFalse()
    {
        fireable = false;
    }

    void OpenFire()
    {
        RaycastHit hit;
        Vector3 ray = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, Camera.main.transform.forward, out hit) && Time.time > fireRate)
        {
            Fire();
            fireRate = Time.time + fireCoolDown;

            GameObject newImpact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            if (hit.collider != null && hit.collider.CompareTag("Zombi"))
            {
                hit.collider.GetComponent<ZombiBehaviour>().zombiHealth -= weaponDamage;
            }
        }
    }

    public void Fire()
    {
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
