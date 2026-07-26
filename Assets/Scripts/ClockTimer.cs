using UnityEngine;
using TMPro;

public class ClockTimer : MonoBehaviour
{

    public int _timerInSeconds1 = 57;
    public int _timerInMinutes1 = 30;
 
    public TextMeshProUGUI _clockValue;
    public TextMeshProUGUI _11Value;
    public bool _thisHasControl = true;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {

	}

    // Update is called once per frame
    void Update()
    {

        if (_thisHasControl)
        {
            _timerInSeconds1 = GameSessionManager.Instance._timerInSeconds;
            _timerInMinutes1 = GameSessionManager.Instance._timerInMinutes;

            if (_timerInSeconds1 < 10)
                _clockValue.text = _timerInMinutes1 + ".0" + _timerInSeconds1;
            if (_timerInSeconds1 > 9)
                _clockValue.text = _timerInMinutes1 + "." + _timerInSeconds1;

            if (_timerInMinutes1 >= 60)
            {
                Debug.Log("Timer has reached the end");
                GameSessionManager.Instance._timerInSeconds = 0;
                GameSessionManager.Instance._timerInMinutes = 0;
                _11Value.text = "12:";
                GameSessionManager.Instance.OnClockEnd();
            }
        }
    }
}
