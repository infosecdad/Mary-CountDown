using UnityEngine;
using UnityEngine.SceneManagement;

public class TItleMenu : MonoBehaviour
{

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	/// <summary>
	/// When user presses the start game button we need to load main scene
	/// </summary>
	public void OnPressStartGameBtn()
	{
		SceneManager.LoadScene("Clock Room");
		GameSessionManager.Instance._timerInSeconds2 = 57;
		GameSessionManager.Instance._timerInSeconds = 57;
		GameSessionManager.Instance.lastSecond = 0;
		GameSessionManager.Instance._timerInMinutes = 56;
		GameSessionManager.Instance._updatedTimer = false;
		GameSessionManager.Instance._playerLookState.SetActive(false);
		GameSessionManager.Instance._playerObj.GetComponent<SpriteRenderer>().enabled = true;
		GameSessionManager.Instance._playerObj.GetComponent<PlayerMovement>()._moveSpeed = 5;
	}

	public void OnPressExitGameBtn()
	{
		Application.Quit();
	}
}
