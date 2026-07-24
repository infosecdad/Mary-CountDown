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
        //invincibility frames
        if (_inFramesCur > 0)
            _inFramesCur -= Time.deltaTime;
		if (_inFramesCur < 0)
		{
            _inFramesCur = 0;
		}

		
    }

    //Appying damage or healing
    public void ChangeHealth(float change)
    {
        if (_inFramesCur > 0)
            return;

        _curHealth += change;
        if (change < 0)
        {
            _inFramesCur = _inFramesMax;
        }

        if (_curHealth <= 0)
        {
            _curHealth = 0;
            OnDeath();
        }

        if (_curHealth > _maxHealth)
            _curHealth = _maxHealth;
    }
    //dead
    void OnDeath()
    {
        Debug.Log("dead");
        GameObject.Destroy(gameObject);
    }
}
