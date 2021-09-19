using UnityEngine;

public class RifleWeapon : MonoBehaviour
{
    [SerializeField] AudioClip readySound, fireSound;
    [SerializeField] private ParticleSystem muzzleFlash;

    private AudioSource RifleSource;
    private Animator anim;

    private float fireRate;
    private float rifleCoolDown = 0.12f;

    private bool autoFire = true;

    private void Start()
    {
        RifleSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (autoFire) { rifleCoolDown = 0.12f; }
        else { rifleCoolDown = 0.5f; }

        if (LaserSight.enemyDetected && Time.time > fireRate)
        {
            RifleFire();
            fireRate = Time.time + rifleCoolDown;
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

    public void ChangeFireMod()
    {
        autoFire = !autoFire;
    }
}
