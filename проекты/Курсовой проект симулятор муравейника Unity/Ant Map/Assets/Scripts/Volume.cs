using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour {

    public Slider volume;
    public GameObject go;
    private AudioSource sourceVolume;
    // Use this for initialization
    void Start()
    {
        sourceVolume = go.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        sourceVolume.volume = volume.value;
    }
}
