using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HealthManager : MonoBehaviour
{
    public float _maxHealth = 10;
    public float _curHealth = 10;
    public float _inFramesMax = 1;
    public float _inFramesCur = 0;
    public float _KnockBackX = 1;
    public float _knockBacky = 1;
    public GameObject _playerEyes;
    public AudioSource _audioSource;
    public AudioClip _damageSound;
    public AudioClip _deathSound;

	public float GetHealthMax() { return _maxHealth; }
	public float GetHealthCur() { return _curHealth; }
	//i dont remember why i added this i never used it
	//bool _isDead = false;

	private Animator _deathAnim;
    public float _deathAnimTime;

    private PlayerMovement _pMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        if (GetComponent<PlayerMovement>())
            _pMove = GetComponent<PlayerMovement>();
        _deathAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //invincibility frames
        if (_inFramesCur > 0)
            _inFramesCur -= Time.deltaTime;
		if (_inFramesCur < 0)
		{
            _inFramesCur = 0;
            _playerEyes.SetActive(false);
		}

        if (_inFramesCur > 0 && GetComponent<PlayerMovement>())
        {
            if (_playerEyes.activeSelf == false)
                _playerEyes.SetActive(true);
        }

		
    }

    public void PlayDamageSound()
    {
        if (_audioSource && _damageSound)
            _audioSource.PlayOneShot(_damageSound, 1f);
    }

    public void PlayDeathSound()
    {
        if (_audioSource && _deathSound)
            _audioSource.PlayOneShot(_deathSound, 1f);
    }

    //Appying damage or healing
    public void ChangeHealth(float change)
    {
        if (_inFramesCur > 0)
            return;

        _curHealth += change;
        if (change < 0)
        {
            _inFramesCur = _inFramesMax;
            PlayDamageSound();

            if (GetComponent<PlayerMovement>())
            {
                if (_pMove._isFacingRight == true)
                {
                    _KnockBackX *= -1;
                    _pMove.rb.linearVelocity = new Vector2(_KnockBackX, _knockBacky);
                }
                else if (_pMove._isFacingRight == false)
                {
                    if (_KnockBackX < 0)
                        _KnockBackX *= -1;
                        _pMove.rb.linearVelocity = new Vector2(_KnockBackX, _knockBacky);
				}
            }
        }

        if (_curHealth <= 0)
        {
            _curHealth = 0;
            if (GetComponent<PlayerMovement>())
            {
                _deathAnim.SetBool("isDead", true);
                PlayDeathSound();
                Invoke(nameof(OnDeath), _deathAnimTime);
            }
            else
                GameObject.Destroy(gameObject);
        }

        if (_curHealth > _maxHealth)
            _curHealth = _maxHealth;
    }
    //dead
    void OnDeath()
    {
        Debug.Log("dead");
        _playerEyes.SetActive(false);
		GameSessionManager.Instance.OnPlayerDeath(gameObject);
	}
	public void Reset()
	{
		_deathAnim.SetBool("isDead", false);
		_curHealth = _maxHealth;
		_inFramesCur = 0;
	}
}
