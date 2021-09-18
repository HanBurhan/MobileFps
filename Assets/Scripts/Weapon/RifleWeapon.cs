using UnityEngine;

public class RifleWeapon : MonoBehaviour
{
    [SerializeField] AudioClip readySound, fireSound;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] Vector3 scopePos;
    [SerializeField] private float zoomSpeed;

    private Vector3 normalPos;
    private AudioSource RifleSource;
    private Animator anim;

    private float fireRate;
    private float rifleCoolDown = 0.12f;

    private bool autoFire = true;
    private bool scopeOn;


    private void Awake()
    {
        normalPos = transform.position;
    }

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

        //if (scopeOn)
        //{
        //    transform.position = GetScopePos();
        //}
        //else
        //{
        //    transform.position = GetNormalPos();
        //}
    }

    public void OpenScope()
    {
        scopeOn = !scopeOn;
        Debug.Log(scopeOn.ToString());
    }

    private Vector3 GetScopePos()
    {
        Vector3 pos = Vector3.Lerp(transform.position, scopePos, zoomSpeed * Time.deltaTime);
        return pos;
    }

    private Vector3 GetNormalPos()
    {
        Vector3 pos = Vector3.Lerp(transform.position, normalPos, zoomSpeed * Time.deltaTime);
        return pos;
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
