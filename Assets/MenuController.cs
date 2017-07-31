using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
  bool isStory = false;
  public GameObject storyPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isStory && Input.GetMouseButtonDown(0))
    {
      isStory = false;
      storyPanel.SetActive(false);
    }
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      ShutDown();
    }
  }

  public void ShutDown()
  {
    Application.Quit();
  }

  public void PlayButtonClick()
  {
    SceneManager.LoadScene("Scene01");
  }

  public void StoryButtonClicked()
  {
    isStory = true;
    storyPanel.SetActive(true);
  }
}
