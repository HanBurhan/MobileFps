using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSounds : MonoBehaviour
{
    [SerializeField] private float stepOffset;
    [SerializeField] private AudioClip[] dirtWalk;

    private AudioSource source;
    private CharacterController controller;
    private LayerMask whatLayer;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.velocity.x > 0.1f || controller.velocity.z > 0.1f)
        {
            StartCoroutine(StepEnum());
            Debug.Log("Oldu");
        }
    }

    private AudioClip RandomClip(AudioClip[] clips)
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }

    IEnumerator StepEnum()
    {
        while (true)
        {
            source.PlayOneShot(RandomClip(dirtWalk));
            yield return new WaitForSeconds(stepOffset);
        }
    }
}
