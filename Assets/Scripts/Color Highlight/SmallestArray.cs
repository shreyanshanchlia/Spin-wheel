/*
* Author - @Shreyansh Anchlia 
* ©SquareDragon Games
*/

using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class SmallestArray : MonoBehaviour
{
	public int ans = 1;
	public TMP_InputField inputField;
	public TextMeshProUGUI ansText;
	public List<int> arr;

	public void Calculate()
	{
		arr = inputField.text.Trim().Split(',').ToList().ConvertAll(int.Parse);
		int n = arr.Count;
		arr.Sort();
		if (arr[0] * arr[1] * arr[2] < arr[0] * arr[n - 1] * arr[n - 2])
		{
			ans = arr[0] * arr[1] * arr[2];
			ansText.text = $"ans = {ans} ({arr[0]},{arr[1]},{arr[2]})";
		}
		else
		{
			ans = arr[0] * arr[n - 1] * arr[n - 2];
			ansText.text = $"ans = {ans} ({arr[0]},{arr[n - 1]},{arr[n - 2]})";
		}
	}
}
