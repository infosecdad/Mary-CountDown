using UnityEngine;

public class NumberSet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<PlayerMovement>())
        {
            GameSessionManager.Instance._hasNumbers = true;
            Destroy(gameObject);
		}
    }
}
