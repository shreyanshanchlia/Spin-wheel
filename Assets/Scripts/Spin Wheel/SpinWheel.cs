/*
* Author - @Shreyansh Anchlia 
* ©SquareDragon Games
*/

using UnityEngine;

public class SpinWheel : MonoBehaviour
{

	public float reducer;
	public float multiplier = 1;
	bool round1 = false;
	public bool isStoped = false;
	public bool isStopping = false;

	public int NumberOfPartitions = 12;
	public float targetRotation = 0;
	void Start()
	{
		this.transform.eulerAngles = new Vector3(0, 0, Random.Range(0f, 360f));
		round1 = true;
	}

	void FixedUpdate()
	{

		if (Input.GetKey(KeyCode.Space))
		{
			Reset();
		}
		if (multiplier > 0)
		{
			transform.Rotate(Vector3.forward, 1 * multiplier);
		}
		else
		{
			if(!isStoped)
			{
				float currentRotation = transform.eulerAngles.z / (360f / 12f);
				targetRotation = Mathf.CeilToInt(currentRotation) * 360 / 12f;
				//targetRotation = targetRotation >= 210f ? targetRotation - 360 : targetRotation;
				isStopping = true;
				print($"current rotation = {this.transform.eulerAngles.z}, tragetRotation = {targetRotation}");
			}
			isStoped = true;
		}

		if(multiplier < 0 && isStopping)
		{
			transform.Rotate(Vector3.forward, (targetRotation - transform.eulerAngles.z) * Time.fixedDeltaTime);
			if(Mathf.Approximately(transform.eulerAngles.z, targetRotation))
			{ 
				isStopping = false;
			}
		}

		if (multiplier < 20 && !round1)
		{
			multiplier += 0.1f;
		}
		else
		{
			round1 = true;
		}

		if (round1 && multiplier > 0)
		{
			multiplier -= reducer;
		}
	}


	public void Reset()
	{
		multiplier = 1;
		reducer = Random.Range(0.01f, 0.5f);
		round1 = false;
		isStoped = false;
	}
}