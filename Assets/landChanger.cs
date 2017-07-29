using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landChanger : MonoBehaviour
{

  GameController gameController;
  public Material forestMaterial;
  public Material clearedLandMaterial;
  public Material solarMaterial;

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
    meshRen = gameObject.GetComponent<MeshRenderer>();
    meshRen.material = forestMaterial;
    currentState = state.forest;
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
      UpdateActionText();
    }
  }

  private void UpdateActionText()
  {
    string actionString;
    switch (currentState)
    {
      case state.forest:
        actionString = string.Concat("Buy land for: ", landValue.ToString("C2"), ".");
        gameController.ChangeActionText(actionString);
        break;
      case state.owened:
        actionString = string.Concat("Clear land for ", clearingCost.ToString("C2"), ".");
        gameController.ChangeActionText(actionString);
        break;
      case state.cleared:
        actionString = string.Concat("Build Solar for ", developmentCost.ToString("C2"), ".");
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
      //add fence
      currentState = state.owened;
      gameController.ChangeMoney(-landValue);
    }
    else if (currentState == state.owened)
    {
      meshRen.material = clearedLandMaterial;
      currentState = state.cleared;
      gameController.ChangeMoney(-clearingCost);

    }
    else if (currentState == state.cleared)
    {
      meshRen.material = solarMaterial;
      currentState = state.solar;
      gameController.ChangeMoney(-developmentCost);
      gameController.ChangeSupply(supplyProduced);
    }
  }
}