using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class Fade2 : MonoBehaviour {

	public float speed;
	private bool fadein = false;
	private float time = 0.0f;
	private Image image;
	private Canvas canvas;

	// Use this for initialization
	void Start () {
		speed = 1.0f;
		image = GetComponent<Image>();
		canvas = GetComponentInParent<Canvas>();
	}

	// Update is called once per frame
	void Update () {
		TouchInfo info = AppUI.GetTouch ();

		time += Time.deltaTime * speed;
		if(fadein)
			image.color = new Color(1.0f, 1.0f, 1.0f, Mathf.Lerp(0.0f, 1.0f, time));
		else
			image.color = new Color(1.0f, 1.0f, 1.0f, Mathf.Lerp(1.0f, 0.0f, time));

		if (time >= 1.0f) {
			fadein ^= true;
			time = 0.0f;
		}

		if (info == TouchInfo.Begin) {
			speed = 10.0f;
			Invoke ("StartGame",2.0f);
		}
	}
	void StartGame()
	{
		Invoke ("NextStage",2.0f);
		GameObject.FindObjectOfType<Fade> ().StartFadeout ();
	}
	void NextStage()
	{
		SceneManager.LoadScene("Main");
	}
}
