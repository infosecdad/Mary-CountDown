using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]
public class GameSessionManager : MonoBehaviour
{
	[SerializeField, Tooltip("Audio source for the game session")]
	public AudioSource _audioSource;

	public AudioClip _clockTickSound;

	[SerializeField, Tooltip("Player lives")]
	public int _playerLives = 1;

	[SerializeField, Tooltip("Where the player will respawn")]
	public Transform _respawnLocation;

	[SerializeField, Tooltip("Object to display when game is over")]
	public GameObject _gameOverObject;

	[SerializeField, Tooltip("Title menu countdown after game is over")]
	private float _returnToMenuCountdown = 0;

	[SerializeField, Tooltip("The countdown clock")]
	public GameObject _countdownClock;

	[SerializeField, Tooltip("Do we have the numbers?")]
	public bool _hasNumbers = false;

	public bool _thisAlsoHasControl = true;

	public GameObject _playerObj;

	static public GameSessionManager Instance;

	public float _timerInSeconds2 = 57;
	public int _timerInSeconds = 57;
	public int lastSecond = 0;
	public int _timerInMinutes = 30;
	bool _updatedTimer = false;

	
	void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);

		_gameOverObject = GameObject.Find("/Canvas/GameOverText");
		if (_gameOverObject)
		{
			_gameOverObject.SetActive(false);
		}
	}
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		_audioSource = GetComponent<AudioSource>();
		lastSecond = _timerInSeconds;
	}

	// Update is called once per frame
	void Update()
	{
		if (_returnToMenuCountdown > 0)
		{
			_returnToMenuCountdown -= Time.deltaTime;
			if (_returnToMenuCountdown < 0)
				SceneManager.LoadScene("Main Menu");
		}

		if (_thisAlsoHasControl)
		{
			_timerInSeconds2 += Time.deltaTime;
			_timerInSeconds = Mathf.RoundToInt(_timerInSeconds2);

			if (_timerInSeconds != lastSecond)
			{
				lastSecond = _timerInSeconds;
				_audioSource.PlayOneShot(_clockTickSound, 1f);
			}

			if (_timerInSeconds == 60)
			{
				_timerInSeconds = 0;
				_timerInSeconds2 = 0;
				if (_updatedTimer == false)
				{
					_timerInMinutes += 1;
					_updatedTimer = true;
				}
			}
			else
				_updatedTimer = false;
		}

	}

	public void OnPlayerDeath(GameObject player)
	{
		if (_playerLives <= 0)
		{
			//player is out of lives
			GameObject.Destroy(player.gameObject);
			Debug.Log("Game over");

			if (_gameOverObject)
			{
				_gameOverObject.SetActive(true);
			}
			_returnToMenuCountdown = 2;
		}
		else
		{
			//Respawn
			_playerLives--;

			//heath back
			HealthManager playerHealth = player.
				GetComponent<HealthManager>();
			if (playerHealth)
				playerHealth.Reset();

			if (_respawnLocation)
				player.transform.position = _respawnLocation.position;
		}

	}

	public void OnClockEnd()
	{
		_playerLives = 0;
		_playerObj.GetComponent<HealthManager>()._isDead = true;
	}
}
