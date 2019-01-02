using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Look : MonoBehaviour {

    public Transform target;
    private GameObject TargetObj;



    // Use this for initialization
    void Start () {
        TargetObj = target.transform.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (TargetObj != null) // if the target remains unchanged due to discovery issues
        {
            transform.LookAt(target, Vector3.up);
          
        }
    }
}
