using UnityEngine;

public class HealthModifier : MonoBehaviour
{

    public float _healthChange = 0;

    public HealthTarget _changeTarget = HealthTarget.Player;

    //all the targets we can have
    public enum HealthTarget
    {
        Player,
        Enemies,
        All,
        None
    }

	public bool _destroyOnCollision = false;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        GameObject hitObj = collider.gameObject;

        HealthManager healthManager = hitObj.GetComponent<HealthManager>();

        if (healthManager && IsVaildTarget(hitObj))
        {
            //add the damage or healing to target
            healthManager.ChangeHealth(_healthChange);

            if (_destroyOnCollision)
                GameObject.Destroy(gameObject);
        }
    }

    //Check if the thing we hit is the droid we're looking for
    bool IsVaildTarget(GameObject possibleTarget)
    {
        if (_changeTarget == HealthTarget.All)
            return true;
        if (_changeTarget == HealthTarget.None)
            return false;
        if (_changeTarget == HealthTarget.Player && possibleTarget.GetComponent<PlayerMovement>())
            return true;
        else
            return false;
        //Add same thing for enemies once they are made
    }
}
