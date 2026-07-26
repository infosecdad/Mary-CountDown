using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))] 
public class PauseMenu : MonoBehaviour
{
    public AudioSource _audioSource;
    public AudioClip _pauseSound;
    public GameObject _pauseMenu;
	bool _isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _pauseMenu.SetActive(false);
        _audioSource = GetComponent<AudioSource>();
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
            PlayPauseSound();
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
		SceneManager.LoadScene("Main Menu");
	}

    public void PlayPauseSound()
    {
        if (_audioSource && _pauseSound)
            _audioSource.PlayOneShot(_pauseSound, 1f);
    }
}
