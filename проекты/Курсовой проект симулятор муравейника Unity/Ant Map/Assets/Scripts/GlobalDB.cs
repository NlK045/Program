using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalDB : MonoBehaviour {

    public int grass;
    public int food;
    public List<GameObject> obj = new List<GameObject>();
	public int numIntersection;

	void Start () {
        
    }

    void Update()
    {

    }

    public void activationTrigger ()
	{
		for(int i = 0; i < obj.Count; i++)
		{
			obj[i].GetComponent<BoxCollider>().isTrigger = true;
		}
	}
	
	public void deactivationTrigger ()
	{
		for(int i = 0; i < obj.Count; i++)
		{
			obj[i].GetComponent<BoxCollider>().isTrigger = false;
		}
	}
}
