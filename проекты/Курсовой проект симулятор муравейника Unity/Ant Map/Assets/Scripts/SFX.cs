using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFX : MonoBehaviour {

    public Slider sfx;
    public GameObject go;
    public GameObject go2;
    private AudioSource sourceSFX1;
    private AudioSource sourceSFX2;
    // Use this for initialization
    void Start () {
        sourceSFX1 = go.GetComponent<AudioSource>();
        sourceSFX2 = go2.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        sourceSFX1.volume = sfx.value;
        sourceSFX2.volume = sfx.value;
    }
}
