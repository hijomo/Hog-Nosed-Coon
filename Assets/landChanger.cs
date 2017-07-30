using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landChanger : MonoBehaviour
{

  
  GameController gameController;
  public Material forestMaterial;
  public Material clearedLandMaterial;
  public Material solarMaterial;

  public GameObject land;
  public GameObject fence;
  Transform fenceTransform;
  public GameObject tree;
  Transform treeTransform;
  public GameObject solarFarm;
  Transform solarFarmTransform;


  public float landValue = 100f;
  public float clearingCost = 200f;
  public float developmentCost = 300f;
  public float supplyProduced = 50;

  MeshRenderer meshRen;
  enum state
  {
    forest,
    owened,
    cleared,
    solar
  }
  state currentState;


  // Use this for initialization
  void Start()
  {
    gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    meshRen = land.GetComponent<MeshRenderer>();
    meshRen.material = forestMaterial;
    currentState = state.forest;
    fenceTransform = fence.GetComponent<Transform>();
    treeTransform = tree.GetComponent<Transform>();
    treeTransform.Rotate(Vector3.up, Random.Range(0, 360));
    solarFarmTransform = solarFarm.GetComponent<Transform>();
  } 

  // Update is called once per frame
  void Update()
  {
    
  }

  private void OnMouseEnter()
  {
    UpdateActionText();
    Debug.Log("enter");
  }

  private void OnMouseExit()
  {
    Debug.Log("exit");
    gameController.ChangeActionText("");
  }

  private void OnMouseOver()
  {
    if (Input.GetMouseButtonDown(0))
    {
      Debug.Log("clicked");
      ChangeTexture();
      
    }
    UpdateActionText();
  }

  private void UpdateActionText()
  {
    string actionString;
    switch (currentState)
    {
      case state.forest:
        if (gameController.GetMoney() < landValue)
        {
          actionString = string.Concat("Can not afford ", landValue.ToString("C2"), " for land.");
        }
        else
        {
          actionString = string.Concat("Buy land for: ", landValue.ToString("C2"), ".");
          
        }
        gameController.ChangeActionText(actionString);
        break;
      case state.owened:
        if (gameController.GetMoney() < clearingCost)
        {
          actionString = string.Concat("Can't afford ", clearingCost.ToString("C2"), " to clear land.");
        }
        else
        {
          actionString = string.Concat("Clear land for ", clearingCost.ToString("C2"), ".");
        }
        gameController.ChangeActionText(actionString);
        break;
      case state.cleared:
        if (gameController.GetMoney() < developmentCost)
        {
          actionString = string.Concat("Can not afford ", developmentCost.ToString("C2"), " to build solar.");
        }
        else
        {
          actionString = string.Concat("Build Solar for ", developmentCost.ToString("C2"), ".");
        }
        gameController.ChangeActionText(actionString);
        break;
      case state.solar:
        actionString = string.Concat("Produces ", supplyProduced.ToString("F0"), " power.");
        gameController.ChangeActionText(actionString);
        break;
      default:
        break;
    }
  }

  private void ChangeTexture()
  {
    if (currentState == state.forest)
    {
      if (gameController.GetMoney() < landValue)
      {
        return;
      }
      fence.SetActive(true);
      currentState = state.owened;
      gameController.ChangeMoney(-landValue);
    }
    else if (currentState == state.owened)
    {
      if (gameController.GetMoney() < clearingCost)
      {
        return;
      }
      tree.SetActive(false);
      meshRen.material = clearedLandMaterial;
      currentState = state.cleared;
      gameController.ChangeMoney(-clearingCost);

    }
    else if (currentState == state.cleared)
    {
      if (gameController.GetMoney() < developmentCost)
      {
        return;
      }
      solarFarm.SetActive(true);
      meshRen.material = solarMaterial;
      currentState = state.solar;
      gameController.ChangeMoney(-developmentCost);
      gameController.ChangeSupply(supplyProduced);
    }
  }
}