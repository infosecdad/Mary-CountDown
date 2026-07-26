using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneOnCollision : MonoBehaviour
{
	[SerializeField, Tooltip("Name of scene to load")]
	private string _SceneToLoad;

	[SerializeField, Tooltip("Seconds between collision and load")]
	private float _transitionTime = 1f;

	private bool _hasCollided = false;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (_hasCollided)
		{
			_transitionTime -= Time.deltaTime;
			if (_transitionTime <= 0)
			{
				//time to load scene (Make sure it is added in build settings!)
				SceneManager.LoadScene(_SceneToLoad);
				GameObject player = GameObject.FindGameObjectWithTag("Player");
				if(player != null)
				{
					player.transform.position = new Vector3(-8, -1.5f, 0);
				}
				enabled = false;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.GetComponent<PlayerMovement>())
		{
			//player has collided
			_hasCollided = true;
		}
	}
}
