using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SparkyScript : MonoBehaviour
{
    public AudioSource _audioSource;
    public AudioClip _sparkySound;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySparkySound()
    {
        if (_audioSource && _sparkySound)
            _audioSource.PlayOneShot(_sparkySound, 1f);
    }
}
