using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NumberSet : MonoBehaviour
{
    public AudioSource _audioSource;
    public AudioClip _numberSetSound;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<PlayerMovement>())
        {
            PlayNumberSetSound();
            GameSessionManager.Instance._hasNumbers = true;
            Destroy(gameObject);
            
		}
    }

    public void PlayNumberSetSound()
    {
        if (!_audioSource.enabled) {
            _audioSource.enabled = true;
        }
        if (_audioSource && _numberSetSound)
            _audioSource.PlayOneShot(_numberSetSound, 1f);
    }
    
}
