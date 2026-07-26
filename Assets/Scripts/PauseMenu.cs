using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject _pauseMenu;
	bool _isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isPaused = TogglePause();
        }
    }

    bool TogglePause()
    {
        if (Time.timeScale == 0f)
        {
            Debug.Log("unPaused");
            Time.timeScale = 1f;
            _pauseMenu.SetActive(false);
            return false;
        }
        else
        {
			Debug.Log("pause");
			Time.timeScale = 0f;
            _pauseMenu.SetActive(true);
            return true;
			
		}
    }

    public void OnPressResumeBtn()
    {
        _isPaused = TogglePause();
    }
    public void OnPressLeaveGameBtn()
    {
        Time.timeScale = 1f;
		SceneManager.LoadScene("Clock Room");
	}
}
