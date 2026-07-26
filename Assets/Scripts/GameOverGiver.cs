using UnityEngine;

public class GameOverGiver : MonoBehaviour
{
	[SerializeField, Tooltip("Object to display when game is over")]
	private GameObject _gameOverObject2;

	[SerializeField, Tooltip("Where the player will respawn")]
	public Transform _respawnLocation2;

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
            GameSessionManager.Instance._gameOverObject = _gameOverObject2;
            GameSessionManager.Instance._respawnLocation = _respawnLocation2;
		}
        else
            return;
    }
}
