using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class reset : MonoBehaviour {


  public Text anyKeyText;
  public float hangTime;
  float theDrop = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    theDrop += Time.deltaTime;
    if (theDrop > hangTime)
    {
      if (!anyKeyText.IsActive())
      {
        anyKeyText.gameObject.SetActive(true);
      }
      if (Input.GetMouseButtonDown(0) || Input.anyKeyDown)
      {
        SceneManager.LoadScene("MainMenu");
      }
    }
	}
}
