using UnityEngine;
using TMPro;

public class MainGameHUD : MonoBehaviour
{

	[SerializeField, Tooltip("TMP object displaying our current health")]
	TextMeshProUGUI _healthValueText;

	//[SerializeField, Tooltip("TMP object displaying the # of coins collected.")]
	//TextMeshProUGUI _coinValueText;

	[SerializeField, Tooltip("The health icon")]
	private GameObject _healthIcon;

	[SerializeField, Tooltip("The health mannager wer're displaying data for")]
	HealthManager _healthManager;

	[SerializeField, Tooltip("TMP object displaying the # of lives we have.")]
	TextMeshProUGUI _livesValueText;

	private Animator _healthIAnim;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		_healthIAnim = _healthIcon.GetComponent<Animator>();
		GameObject player = GameObject.FindGameObjectWithTag("Player");
      if(player != null)
      {
          _healthManager = player.GetComponent<HealthManager>();
      }
		
		
		
	}

	// Update is called once per frame
	void Update()
	{
		int curHealth = Mathf.RoundToInt(_healthManager.GetHealthCur());
		int maxHealth = Mathf.RoundToInt(_healthManager.GetHealthMax());
		_healthValueText.text = curHealth + "/" + maxHealth;

		_livesValueText.text = GameSessionManager.Instance._playerLives.
			ToString();

		#region *** Health icon anims ***
		if (curHealth == maxHealth)
		{
			_healthIAnim.SetBool("isFull", true);
			_healthIAnim.SetBool("isNotFull", false);
			_healthIAnim.SetBool("isLow", false);
		}
		else if (curHealth < maxHealth && curHealth > 2)
		{
			_healthIAnim.SetBool("isFull", false);
			_healthIAnim.SetBool("isNotFull", true);
			_healthIAnim.SetBool("isLow", false);
		}
		else if (curHealth <= 2)
		{
			_healthIAnim.SetBool("isFull", false);
			_healthIAnim.SetBool("isNotFull", false);
			_healthIAnim.SetBool("isLow", true);
		}
		else
			Debug.Log("Error with health");
		#endregion

	}
}
