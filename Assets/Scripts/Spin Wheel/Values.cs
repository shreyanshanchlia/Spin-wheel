/*
* Author - @Shreyansh Anchlia 
* ©SquareDragon Games
*/

using TMPro;
using UnityEngine;

public class Values : MonoBehaviour
{
	public GameObject ValueTextPrefab;
	public int numberOfElementsInWheel;
	private void Start()
	{
		for (int i = 0; i < numberOfElementsInWheel; i++)
		{
			GameObject ValueTextClone = Instantiate(ValueTextPrefab, this.transform.position, Quaternion.identity, this.transform);
			ValueTextClone.GetComponent<TextMeshProUGUI>().text = (Random.Range(1, 50) * 100).ToString();
			float rotationAngle = -i * 360f / numberOfElementsInWheel;
			ValueTextClone.transform.eulerAngles = new Vector3(0, 0, rotationAngle);
			ValueTextClone.transform.localPosition = new Vector3(
				180 * Mathf.Cos(Mathf.Deg2Rad * rotationAngle), 180 * Mathf.Sin(Mathf.Deg2Rad * rotationAngle), 0);
		}
	}
}
