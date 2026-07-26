using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject _cameraTarget;
    public Vector3 _targetOffset;
    public float _cameraDistance = -1;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
      GameObject player = GameObject.FindGameObjectWithTag("Player");
      if(player != null)
      {
          _cameraTarget = player;
      }
    }

    // Update is called once per frame
    void Update()
    {
		if (!_cameraTarget)
			return;
			Vector3 targetPos = _cameraTarget.transform.position;
		targetPos += _targetOffset;
		targetPos.z += _cameraDistance;

		Vector3 camPos = transform.position;
		transform.position = Vector3.Lerp(camPos, targetPos, Time.deltaTime * 5f);
	}
}
