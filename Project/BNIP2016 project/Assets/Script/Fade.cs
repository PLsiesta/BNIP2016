using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Fade : MonoBehaviour {
	public float speed = 1.0f;

	private bool play = false;
	private bool fadein = false;
	private float time = 0.0f;
	private Image image;
	private Canvas canvas;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
		canvas = GetComponentInParent<Canvas>();

		StartFadein();
	}

	// Update is called once per frame
	void Update () {
        if (play)
        {
            time += Time.deltaTime;
            if (fadein)
            {
                image.color = new Color(1.0f, 1.0f, 1.0f, Mathf.Lerp(1.0f, 0.0f, time * speed));
            }
            else
            {
                image.color = new Color(1.0f, 1.0f, 1.0f, Mathf.Lerp(0.0f, 1.0f, time * speed));
            }
            if (time >= 1.0f)
            {
                play = false;
                if (fadein)
                {
                    canvas.sortingOrder = 0;
                }
            }
        }
	}

	public void StartFadein() {
		play = true;
		fadein = true;
		time = 0.0f;
		canvas.sortingOrder = 4;
	}

	public void StartFadeout() {
		play = true;
		fadein = false;
		time = 0.0f;
		canvas.sortingOrder = 4;
	}
}
