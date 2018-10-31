using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour {

	public Transform SpinningIcon;
	// Update is called once per frame
	void Update () {
		SpinningIcon.Rotate(0, 60*Time.deltaTime, 0);
	}
}
