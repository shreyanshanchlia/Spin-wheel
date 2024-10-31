/*
* Author - @Shreyansh Anchlia 
* ©SquareDragon Games
*/

using UnityEngine;
public class SelectHandler : MonoBehaviour
{
	[HideInInspector] public Color _matColor;
	[HideInInspector] public bool selected = false;

	private void Start()
	{
		_matColor = Color.clear;
	}
	public void ClearSelection()
	{
		if(selected)
		{
			GetComponent<MeshRenderer>().material.color = _matColor;
			selected = false;
		}
	}
	private void OnMouseDown()
	{
		gameObject.transform.root.GetComponent<GridGenerator>().ClearAllSelections();
		if (!selected)
		{
			_matColor = GetComponent<MeshRenderer>().material.color;
			PassedMouseDownEvent(_matColor);
		}
	}
	public void PassedMouseDownEvent(Color _passedColor)
	{
		if (!selected)
		{
			selected = true;
			_matColor = GetComponent<MeshRenderer>().material.color;
			GetComponent<MeshRenderer>().material.color /= 1.5f;
			CellCheck(Physics.OverlapSphere(this.transform.position + Vector3.left, 0.1f), _passedColor);
			CellCheck(Physics.OverlapSphere(this.transform.position + Vector3.right, 0.1f), _passedColor);
			CellCheck(Physics.OverlapSphere(this.transform.position + Vector3.up, 0.1f), _passedColor);
			CellCheck(Physics.OverlapSphere(this.transform.position + Vector3.down, 0.1f), _passedColor);
		}
	}
	public void CellCheck(Collider[] cell, Color _passedColor)
	{
		if(cell.Length == 0) return;
		if(cell[0].CompareTag("Player") && cell[0].GetComponent<MeshRenderer>().material.color == _passedColor)
		{
			cell[0].gameObject.GetComponent<SelectHandler>().PassedMouseDownEvent(_passedColor);
		}
	}
}
