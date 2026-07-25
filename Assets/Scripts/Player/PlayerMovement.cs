using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
	public BoxCollider2D groundCollider2D;
    public float _moveSpeed = 5f;
    public bool _isFacingRight = true;
	public float _jumpForce = 5f;
	public float _curJumpForce = 0f;
	public float _jumpSpeed = 0.5f;
	bool _startJumpAnim = false;
	public AudioClip _jumpSound;
	public AudioSource _audioSource;
	public AudioClip _walkSound;

	private Animator _playerAnims;

	public bool _isJumping = false;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		_playerAnims = GetComponent<Animator>();
		_audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

		//All of these 4 are so that the jumping works
		if (_curJumpForce >= _jumpForce)
		{
			_curJumpForce = 0f;
			_isJumping = true;
		}

		if (_curJumpForce > 0 && !Input.GetKey(KeyCode.Space))
			_isJumping = true;

		if (_isJumping == true)
		{
			_curJumpForce = 0f;
		}
		if (_curJumpForce > 0)
			_startJumpAnim = true;

	}

	void FixedUpdate()
	{

		float xinput = Input.GetAxis("Horizontal");

		//for moving on x axis
		if (Mathf.Abs(xinput) > 0)
		{
			rb.linearVelocity = new Vector2(xinput * _moveSpeed, rb.linearVelocity.y);
			
		}

		//for checking if we are jumping
		if (Input.GetKey(KeyCode.Space) && _isJumping == false)
		{
			_curJumpForce += _jumpSpeed;

		}
		else
		{
			_curJumpForce = 0f;
		}

		//jump
		if (_curJumpForce > 0f)
		{
			rb.linearVelocity = new Vector2(rb.linearVelocity.x, _curJumpForce);
		}
	
		//flipping the sprite when we turn around
			FlipSprite();

		#region *** Animations ***
		if (Mathf.Abs(xinput) == 0)
		{
			_playerAnims.SetBool("isIdle", true);
			_playerAnims.SetBool("isWalking", false);
		}
		else if (Mathf.Abs(xinput) > 0)
		{
			_playerAnims.SetBool("isWalking", true);
			_playerAnims.SetBool("isIdle", false);
			PlayWalkSound();
		}
		if (_startJumpAnim) {
			_playerAnims.SetBool("isJumping", true);
			PlayJumpSound();
		}
		else
			_playerAnims.SetBool("isJumping", false);
		#endregion
	}


	void OnTriggerStay2D(Collider2D collider)
	{
		if (collider.gameObject.layer == 3)
		{
			_isJumping = false;
		}
		_startJumpAnim = false;
	}
	void OnCollisionExit2D(Collision2D collider)
	{
		if (!Input.GetKey(KeyCode.Space))
			_isJumping = true;
	}

	void FlipSprite()
	{
		if (_isFacingRight && rb.linearVelocity.x < 0f || !_isFacingRight && rb.linearVelocity.x > 0f)
		{
			_isFacingRight = !_isFacingRight;
			Vector3 ls = transform.localScale;
			ls.x *= -1f;
			transform.localScale = ls;
		}
	}

	public void PlayJumpSound()
    {
        if (_audioSource && _jumpSound)
            _audioSource.PlayOneShot(_jumpSound, 1f);
    }

	public void PlayWalkSound()
    {
        if (_audioSource && _walkSound)
            _audioSource.PlayOneShot(_walkSound, 1f);
    }
}
