using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

    public GUISkin mainUI;
    public int numDepth = 1;
    public int index;
    public bool pause = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        if (pause)
        {
            GUI.depth = numDepth;
            GUI.skin = mainUI;
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", GUI.skin.GetStyle("BackgroundMenu"));

            GUI.BeginGroup(new Rect((Screen.width - 150) / 2, (Screen.height - 150) / 2, 150, 150));

            GUI.Label(new Rect(56, 30, 100, 30), "Пауза", GUI.skin.label);
            if(GUI.Button(new Rect(0, 50, 150, 30), "Продолжить"))
            {
                pause = false;
            }
            if(GUI.Button(new Rect(0, 90, 150, 30), "Выход"))
            {
                SceneManager.LoadScene(index);
            }

            GUI.EndGroup();
        }
    }
}
