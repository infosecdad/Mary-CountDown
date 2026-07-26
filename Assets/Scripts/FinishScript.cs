using UnityEngine;
using TMPro;

public class FinishScript : MonoBehaviour
{
	public TextMeshProUGUI _clockValue;
	public TextMeshProUGUI _11Value;
	public int _timerInSeconds1 = 55;
	public int _timerInMinutes1 = 59;
    public float _timerInSec2 = 55f;
    bool _updatedTimer;

	[SerializeField, Tooltip("Player's looking up sprite")]
    public GameObject _playerDoneState;

    [SerializeField, Tooltip("Player")]
    public GameObject _player;

    [SerializeField, Tooltip("Clock")]
    GameObject _clock;

    [SerializeField, Tooltip("HUD Clock")]
    GameObject _HUDClock;

    public GameObject _THX4PlayingText;
    public TextMeshProUGUI _dateYear;
    public GameObject _PMdot;
    public GameObject _ESCtext;

	bool _startClock = false;
    bool _hasControlHere = false;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_startClock)
        {
            _timerInSec2 += Time.deltaTime;
			_timerInSeconds1 = Mathf.RoundToInt(_timerInSec2);

				if (_timerInSeconds1 == 60)
				{
					_timerInSeconds1 = 0;
					_timerInSec2 = 0;
					if (_updatedTimer == false)
					{
						_timerInMinutes1 += 1;
						_updatedTimer = true;
					}
				}
				else
					_updatedTimer = false;

            if (_timerInMinutes1 == 60)
            {
                FinishClock();
            }
		}
        if (_hasControlHere)
        {
			if (_timerInSeconds1 < 10 && _timerInMinutes1 < 10)
				_clockValue.text = _timerInMinutes1 + "0.0" + _timerInSeconds1;
			if (_timerInSeconds1 > 9 && _timerInMinutes1 > 9)
				_clockValue.text = _timerInMinutes1 + "." + _timerInSeconds1;
			if (_timerInSeconds1 < 10 && _timerInMinutes1 > 9)
				_clockValue.text = _timerInMinutes1 + ".0" + _timerInSeconds1;
			if (_timerInSeconds1 > 9 && _timerInMinutes1 < 10)
				_clockValue.text = _timerInMinutes1 + "0." + _timerInSeconds1;
		}
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == _player)
        {
            if (GameSessionManager.Instance._hasNumbers == true)
            {
                _hasControlHere = true;
                _startClock = true;
                _HUDClock.SetActive(false);
                _player.transform.position = new Vector3(0, -1.5f, 0);
                _player.GetComponent<SpriteRenderer>().enabled = false;
                _playerDoneState.SetActive(true);
                _player.GetComponent<PlayerMovement>()._moveSpeed = 0;
                _clock.GetComponent<ClockTimer>()._thisHasControl = false;
                GameSessionManager.Instance._thisAlsoHasControl = false;


			}

		}
    }

    void FinishClock()
    {
        _timerInMinutes1 = 0;
        _11Value.text = "12:";
        _dateYear.text = "Jan. 1, 2000";
        _PMdot.SetActive(false);
        _THX4PlayingText.SetActive(true);
        _ESCtext.SetActive(true);
        _playerDoneState.GetComponent<Animator>().SetBool("Partying", true);
	}
}
