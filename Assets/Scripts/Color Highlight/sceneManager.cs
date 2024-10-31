/*
* Author - @Shreyansh Anchlia 
* ©SquareDragon Games
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
	public void LoadScene(int level)
	{
		SceneManager.LoadScene(level);
	}
	public void Quit()
	{
		Application.Quit();
	}
}
