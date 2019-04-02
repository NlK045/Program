using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Castle : MonoBehaviour {
	
	public bool visible = false;

    public GUISkin mainSkin;
    public int numDepth = 1;

    public Texture2D tex;

    public string nameCastle;
    public int xp;
    public int protection;
    public int lvl;

    public int costUp;
    public int costMining;
    public int costWarrior;
    public int costEarner;
    public int costMagic;

    public GameObject mining;
	public GameObject warrior;
	public GameObject earner;
	public GameObject magic;
	
	public GameObject lvl2;
	public GameObject lvl3;
	
	private GlobalDB _GDB;


    public Text nameText;
    public Text hpText;
    public Text protectionText;
    public Text lvlText;

    public GameObject uiObject;
    public SpawnObject _SO;

    public Text uiCostUp;
    public Text uiCostMining;
    public Text uiCostTower;
    public Text uiCostShop;
    public Text uiCostMagic;

    void Start () {
		_GDB = GameObject.FindGameObjectWithTag("MainUI").GetComponent<GlobalDB>();
    }
	
	void Update () {
    }

    void OnMouseDown()
    {
        visible = true;
       GameObject.FindGameObjectWithTag("MainUI").GetComponent<BackgroundUI>().pictureSelectObject = tex;  
    }

    void OnGUI ()
	{
		if(visible)
		{
			GUI.depth = numDepth;
			GUI.skin = mainSkin;
			
			GUI.BeginGroup(new Rect((Screen.width - 600)/2, Screen.height - 190, 880, 190));
			
			GUI.Label(new Rect(0, 30, 150, 30), "Название: " + nameCastle);
			GUI.Label(new Rect(0, 60, 150, 30), "Прочность: " + xp);
			GUI.Label(new Rect(0, 90, 150, 30), "Защита: " + protection);
			GUI.Label(new Rect(0, 120, 150, 30), "Уровень: " + lvl);
			
			GUI.Box(new Rect(160, 10, 2, 160), "", GUI.skin.GetStyle("BackgroudMenu"));
			
			if(GUI.Button(new Rect(170, 0, 60, 150), "Up"))
			{
				if(_GDB.grass >= costUp && lvl < 3)
				{
					if(lvl == 1)
					{
						lvl++;
						lvl2.SetActive(true);
						xp += 500;
						protection += 5;
						costUp += 500;
					} else
					if(lvl == 2)
					{
						lvl++;
						lvl3.SetActive(true);
						xp += 700;
						protection += 8;
					}
					_GDB.grass -= costUp;
				}
			}
			GUI.Box(new Rect(170, 155, 60, 20), costUp.ToString());

            GUI.Box(new Rect(240, 10, 2, 160), "", GUI.skin.GetStyle("BackgroudMenu"));

            if (GUI.Button(new Rect(250, 0, 90, 150), "Добыча"))
            {
                if (_GDB.grass >= costMining)
                {
                    Camera.main.GetComponent<BuildManager>().setBuild(mining);
                    _GDB.grass -= costMining;
                }
            }
            GUI.Box(new Rect(250, 155, 90, 20), costMining.ToString());

            if (GUI.Button(new Rect(350, 0, 90, 150), "Войны"))
            {
                if (_GDB.grass >= costWarrior)
                {
                    _SO.SpawnFood();
                    _GDB.grass -= costWarrior;
                }
            }
            GUI.Box(new Rect(350, 155, 90, 20), costEarner.ToString());

            if (GUI.Button(new Rect(450, 0, 90, 150), "Добытчики"))
            {
                if (_GDB.grass >= costEarner)
                {
                    //Camera.main.GetComponent<BuildManager>().setBuild(shop);
                    _GDB.grass -= costEarner;
                }
            }
            GUI.Box(new Rect(450, 155, 90, 20), costEarner.ToString());

            GUI.EndGroup();
        }
	}
}
