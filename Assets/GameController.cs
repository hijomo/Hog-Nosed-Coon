using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {


  public GameObject landPlot;

  int mapHeight = 10;
  int mapWidth = 10;


  public Text demandText, supplyText, moneyText, incomeText, actionText;
  public float demand, supply;
  public float demandGrothRate = 0.5f;
  public float energyPrice = 1.5f;
  public float money; 

  [SerializeField]
  float income;


	// Use this for initialization
	void Start () {
    for (int i = 0; i < mapHeight; i++)
    {
      for (int j = 0; j < mapWidth; j++)
      {
        Vector3 pos = new Vector3(i * 11, 0, j * 11);
        GameObject obj = Instantiate(landPlot, pos, Quaternion.identity);
      }
    }
	}
	
	// Update is called once per frame
	void Update () {
    float delta = 0;

    demand += demandGrothRate * Time.deltaTime;

    delta = supply - demand;

    income = delta * energyPrice * Time.deltaTime;

    money += income;
    CheckFailure();
    UpdateUI();
	}

  private void UpdateUI()
  {
    demandText.text = string.Concat("Demand : ", demand.ToString("F0"));
    supplyText.text = string.Concat("Supply : ", supply.ToString("F0"));
    moneyText.text = string.Concat("Money : ", money.ToString("C2"));
    if (money <= 0)
    {
      moneyText.color = Color.red;
    }
    else
    {
      moneyText.color = Color.black;
    }
    incomeText.text = string.Concat("Income : ", income.ToString("C2"));
    if (income <= 0)
    {
      incomeText.color = Color.red;
    }
    else
    {
      incomeText.color = Color.black;
    }
  }

  public void ChangeSupply(float change)
  {
    supply += change;
  }

  public void ChangeActionText(string action)
  {
    actionText.text = action;
  }

  public float GetMoney()
  {
    return money;  
  }

  public void ChangeMoney(float change)
  {
    money += change;
  }

  void CheckFailure()
  {
    if (money <= 0f)
      SceneManager.LoadScene("GameOverScene");
  }



}
