using UnityEngine;

public class MainMenuReset : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameSessionManager.Instance._playerLives = 2;
        GameSessionManager.Instance._hasNumbers = false;
		GameSessionManager.Instance._thisAlsoHasControl = true;
        //HealthManager.Instance._curHealth = 10;
		

}

    // Update is called once per frame
    void Update()
    {
        
    }
}
