using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {

	private int count;

	// Use this for initialization
	void Start () {
		count = 200;
	}
	
	// Update is called once per frame
	void Update () {
		TouchInfo info = AppUI.GetTouch ();

		if (info == TouchInfo.Begin)
			count = 0;

		if (count == 0) {
			OnClickStart ();
		}
		count -= 1;
	}
	void OnClickStart()
	{
		Invoke ("NextStage",2.0f);
		GameObject.FindObjectOfType<Fade>().StartFadeout ();
	}
	void NextStage()
	{
		SceneManager.LoadScene("title");
	}
}
