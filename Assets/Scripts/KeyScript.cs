using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField]
    private AudioClip sound;

    private AudioSource audioSource;

    bool isPressed = false;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public async void KeyPress()
    {
        if (isPressed) return;

        isPressed = true;
        LowerKey();
        PlaySound();
        Invoke("RaiseKey", .5f);        
    }

    void PlaySound()
    {        
        audioSource.PlayOneShot(sound);        
    }

    void LowerKey()
    {
        StartCoroutine(LowerKeyAnim());
    }

    IEnumerator LowerKeyAnim()
    {
        Vector3 pos = transform.position;
        Vector3 target = transform.position - (Vector3.up * 0.1f * transform.localScale.y);

        while (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 0.1f);
            yield return new WaitForSeconds(0.01f);
        }
    }

    void RaiseKey()
    {
        StartCoroutine(RaiseKeyAnim());
    }

    IEnumerator RaiseKeyAnim()
    {
        Vector3 pos = transform.position;
        Vector3 target = transform.position + (Vector3.up * 0.1f * transform.localScale.y);

        while (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 0.1f);
            yield return new WaitForSeconds(0.01f);
        }

        isPressed = false;
    }
}
