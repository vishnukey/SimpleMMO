using UnityEngine;
using System.Collections;

public class RandomColour : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
