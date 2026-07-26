using UnityEngine;

public class ClockRoomGiver : MonoBehaviour
{
	[SerializeField, Tooltip("Object to display when game is over")]
	private GameObject _gameOverObject2;

	[SerializeField, Tooltip("Where the player will respawn")]
	public Transform _respawnLocation2;

	[SerializeField, Tooltip("The finish object")]
	public GameObject _finsh;

	[SerializeField, Tooltip("Player")]
	public GameObject _playerObj;

	[SerializeField, Tooltip("Player's look")]
	public GameObject _playerLookState;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.GetComponent<PlayerMovement>())
		{
			_playerObj = col.gameObject;
			_playerLookState = GameSessionManager.Instance._playerLookState;
			GameSessionManager.Instance._gameOverObject = _gameOverObject2;
			GameSessionManager.Instance._respawnLocation = _respawnLocation2;
			_finsh.GetComponent<FinishScript>()._playerDoneState = _playerLookState;
			_finsh.GetComponent<FinishScript>()._player = _playerObj;
		}
		else
			return;
	}
}
