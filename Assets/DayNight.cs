using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour {

  Transform tran;
  public float nightRotationRate;
  public float dayRotationRate;

	// Use this for initialization
	void Start () {
    tran = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
    Debug.Log(tran.rotation.eulerAngles.x);
    if (tran.rotation.eulerAngles.x > 0 && tran.rotation.eulerAngles.x < 180 )
    {
      tran.Rotate(Vector3.right, dayRotationRate * Time.deltaTime);
    }
    else
    {
      tran.Rotate(Vector3.right, nightRotationRate * Time.deltaTime);
    }
    
	}
}
