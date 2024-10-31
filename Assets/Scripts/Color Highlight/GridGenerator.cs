/*
* Author - @Shreyansh Anchlia 
* ©SquareDragon Games
*/

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
	[Header("Grid Parameters")]
	[SerializeField] int gridSize = 6;
	public Transform topLeftTransform;

	[Header("Colors")]
	[SerializeField] List<Color> colorsToApply;

	[Header("Prefabs")]
	public GameObject CellPrefab;

	public static int GRID_SIZE = 6;

	private void OnValidate() => GRID_SIZE = gridSize;

#if UNITY_EDITOR
	[ContextMenu("Generate Grid")]
	public void GenerateGrid()
	{
		for (int i = 0; i < gridSize; i++)
		{
			for (int j = 0; j < gridSize; j++)
			{
				Vector3 instantiatePosition = topLeftTransform.position + new Vector3(i * 1.02f, -j * 1.02f, 0);
				GameObject instantiatedCube = PrefabUtility.InstantiatePrefab(CellPrefab) as GameObject;
				instantiatedCube.transform.position = instantiatePosition;
				instantiatedCube.transform.parent = this.transform;
			}
		}
	}
#endif

	[ContextMenu("Remove Grid")]
	public void RemoveGrid()
	{
		foreach (Transform child in this.transform)
		{
			Destroy(child.gameObject);
		}
	}

	[ContextMenu("Randomize Color")]
	public void RandomizeColor()
	{
		foreach (Transform child in this.transform)
		{
			try     //to Avoiding leaking of material into the scene use only at runtime
			{
				int _colorIndex = Random.Range(0, colorsToApply.Count);
				child.GetComponent<SelectHandler>()._matColor = Color.clear;
				child.GetComponent<SelectHandler>().selected = false;
				child.gameObject.GetComponent<MeshRenderer>().material.color = colorsToApply[_colorIndex];
			}
			catch { }
		}
	}
	public void ClearAllSelections()
	{
		foreach (Transform child in this.transform)
		{
			child.gameObject.GetComponent<SelectHandler>().ClearSelection();
		}
	}
}
