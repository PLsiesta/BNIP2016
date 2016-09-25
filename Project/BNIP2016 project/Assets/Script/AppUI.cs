using UnityEngine;
using System.Collections;

public class AppUI : MonoBehaviour {

	private static Vector3 Touchposition = Vector3.zero;
	private static Vector3 PreviousPosition = Vector3.zero;

	public static TouchInfo GetTouch()
	{
        if (Application.platform != RuntimePlatform.Android)
        {
			if (Input.GetMouseButtonDown (0)) {
				return TouchInfo.Begin;
			}
			if (Input.GetMouseButton (0)) {
				return TouchInfo.Moved;
			}
			if (Input.GetMouseButtonUp (0)) {
				return TouchInfo.Ended;
			}
		} else {
			if(Input.touchCount > 0)
				return (TouchInfo)((int)Input.GetTouch(0).phase);
		}
		return TouchInfo.None;
	}

	public static Vector3 GetTouchPosition(){
        if (Application.platform == RuntimePlatform.Android)
        {
			TouchInfo touch = AppUI.GetTouch ();
			if (touch != TouchInfo.None) {
				PreviousPosition = Input.mousePosition;
				return PreviousPosition;
			}
		} else {
			if (Input.touchCount > 0) {
				Touch touch = Input.GetTouch (0);
				Touchposition.x = touch.position.x;
				Touchposition.y = touch.position.y;
				return Touchposition;
			}
		}
		return Vector3.zero;
	}

	public static Vector3 GetDeltaPosition()
	{
		TouchInfo info = AppUI.GetTouch ();
		if (info != TouchInfo.None) {
			Vector3 currentPosition = Input.mousePosition;
			Vector3 delta = currentPosition - PreviousPosition;
			PreviousPosition = currentPosition;
			return delta;
		} else {
			if (Input.touchCount > 0) {
				Touch touch = Input.GetTouch(0);
				PreviousPosition.x = touch.deltaPosition.x;
				PreviousPosition.y = touch.deltaPosition.y;
				return PreviousPosition;
			}
		}
		return Vector3.zero;
	}

	public static Vector3 GetTouchWorldPosition(Camera camera){
		return camera.ScreenToWorldPoint (GetTouchPosition());
	}
}

public enum TouchInfo
{
	None = -1,
	Begin = 0,
	Moved = 1,
	Stationary = 2,
	Ended = 3,
	Canceled = 4,
}