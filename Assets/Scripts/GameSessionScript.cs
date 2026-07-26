using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSessionManager : MonoBehaviour
{

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

	[SerializeField, Tooltip("Timer in seconds")]
	public int _secTime;

	[SerializeField, Tooltip("Timer in minutes")]
	public int _minTime;

	static public GameSessionManager Instance;

	

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
}
