using UnityEngine;
using System.Collections;

public class DrawDebugRays : MonoBehaviour {
	public bool	drawDebug = false;

	public void DrawThisRay(Ray ray, Color color){
		if (drawDebug){
			Debug.DrawRay(ray.origin, ray.direction, color);
		}
	}
	
}
