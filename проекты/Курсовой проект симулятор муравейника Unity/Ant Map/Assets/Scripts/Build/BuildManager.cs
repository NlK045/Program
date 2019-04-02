using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {
	
	private GameObject _currentBuild;
	public LayerMask mask;
	
	private GlobalDB _GDB;

	void Start () {
		_GDB = GameObject.FindGameObjectWithTag("MainUI").GetComponent<GlobalDB>();
	}
	
	void Update () {
		if(_currentBuild != null)
		{
			Ray ray;
			RaycastHit hit;
			
			ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 10000.0f, mask))
			{
				_currentBuild.transform.position = hit.point;
			}
			
			if(Input.GetMouseButtonDown(0) && _GDB.numIntersection == 0)
			{
				_currentBuild.tag = "Untagged";
				_currentBuild = null;
				_GDB.deactivationTrigger();
			}
		}
	}
    
    public void setBuild (GameObject go)
    {
        _currentBuild = (GameObject)Instantiate(go);
        _currentBuild.tag = "CurBuild";
        _GDB.activationTrigger();
    }

}
