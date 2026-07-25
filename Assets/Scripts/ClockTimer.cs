using UnityEngine;

public class ClockTimer : MonoBehaviour
{

    public float _timerInSeconds2 = 57;
    public int _timerInSeconds = 57;
    public int _timerInMinutes = 30;
    bool _updatedTimer = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timerInSeconds2 += Time.deltaTime;
        _timerInSeconds = Mathf.RoundToInt( _timerInSeconds2 );

        if (_timerInSeconds == 60)
        {
            _timerInSeconds = 0;
            _timerInSeconds2 = 0;
            if (_updatedTimer == false)
            {
                _timerInMinutes += 1;
                _updatedTimer = true;
            }
        }
        else
            _updatedTimer = false;
    }
}
