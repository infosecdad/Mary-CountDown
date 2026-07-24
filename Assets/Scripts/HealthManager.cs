using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float _maxHealth = 10;
    public float _curHealth = 10;
    public float _inFramesMax = 1;
    public float _inFramesCur = 0;
    bool _isDead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_inFramesCur > 0)
            _inFramesCur -= Time.deltaTime;

        if (_curHealth <= 0)
            OnDeath();

        if (Input.GetKey(KeyCode.G))
        {
            ChangeHealth(-1f);
        }
    }

    void ChangeHealth(float change)
    {
        if (_inFramesCur > 0)
            return;

        _curHealth += change;
        if (change < 0)
        {
            _inFramesCur = _inFramesMax;
        }
    }

    void OnDeath()
    {
        Debug.Log("dead");
    }
}
