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
		SceneManager.LoadScene("Test Room");
	}
}
