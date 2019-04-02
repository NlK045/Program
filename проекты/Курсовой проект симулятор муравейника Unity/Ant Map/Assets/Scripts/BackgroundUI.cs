using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundUI : MonoBehaviour {

    public GUISkin mainUI;
    public int numDepth = 0;

    public string nameWindow;
    public Texture2D pictureSelectObject;
    public int grass;
    public int food;

    public Texture2D pictureDefault;
    public RenderTexture map;
    public Material mat;

    private GlobalDB _GDB;
    private GameMenu _GM;

	// Use this for initialization
	void Start () {
        _GM = gameObject.GetComponent<GameMenu>();
        _GDB = gameObject.GetComponent<GlobalDB>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            _GM.pause = true;
        }
        grass = _GDB.grass;
	}

    private void OnGUI()
    {
        GUI.depth = numDepth;
        GUI.skin = mainUI;
        #region left block
        GUI.Box(new Rect(0, Screen.height - 256, 256, 256), "", GUI.skin.GetStyle("Line"));
        if (Event.current.type.Equals(EventType.Repaint)) //Event.current.type == EventType.Repaint Event.current.type.Equals(EventType.Repaint)
            Graphics.DrawTexture(new Rect(0, Screen.height - 256, 256, 256), map, mat);
        GUI.Box(new Rect(0, Screen.height - 256, 256, 256), "", GUI.skin.GetStyle("Frame"));
        #endregion

        #region center block
        GUI.Box(new Rect(256, Screen.height - 200, Screen.width - 512, 200), "", GUI.skin.GetStyle("Line"));
        #endregion

        #region right block
        if (pictureSelectObject != null) GUI.DrawTexture(new Rect(Screen.width - 256, Screen.height - 256, 256, 256), pictureSelectObject);
        else GUI.DrawTexture(new Rect(Screen.width - 256, Screen.height - 256, 256, 256), pictureDefault);

        GUI.Box(new Rect(Screen.width - 256, Screen.height - 256, 256, 256), "", GUI.skin.GetStyle("Frame"));
        #endregion

        #region up block
        GUI.Box(new Rect(Screen.width - 170, 0, 200, 30), "");
        GUI.Label(new Rect(Screen.width - 165, 3, 200, 30), "Ресурсы " + grass.ToString(), GUI.skin.label);
        GUI.Label(new Rect(Screen.width - 55, 3, 200, 30), "Еда " + food.ToString(), GUI.skin.label);

        if (GUI.Button(new Rect(0, 0, 100, 25), "Меню"))
        {
            _GM.pause = true;
        }
        #endregion
    }
}