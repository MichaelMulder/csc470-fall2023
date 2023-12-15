using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BarnBuilding : MonoBehaviour
{
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 50000f, (1 << 8))){
            transform.position = hit.point;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown(){
        if (EventSystem.current.IsPointerOverGameObject()){
            return;
        }
        GameManager.SharedInstance.sellButton.SetActive(false);
        GameManager.SharedInstance.buyWheatSeedButton.SetActive(false);
        GameManager.SharedInstance.buyFertilizerButton.SetActive(false);
        GameManager.SharedInstance.buyFertilizerSpace.SetActive(true);
        GameManager.SharedInstance.buyWheatSpace.SetActive(true);
        GameManager.SharedInstance.buySeedSpace.SetActive(true);
        GameManager.SharedInstance.buyMoneySpace.SetActive(true);
    }
    public void OnBuyWheatSpace(){
        if(GameManager.SharedInstance.money >= 5){
            GameManager.SharedInstance.maxWheat = GameManager.SharedInstance.maxWheat + 10;
            GameManager.SharedInstance.money = GameManager.SharedInstance.money - 5;
            GameManager.SharedInstance.moneyText.text = "$" + GameManager.SharedInstance.money.ToString();
        }
    }
    public void OnBuySeedSpace(){
        if(GameManager.SharedInstance.money >= 5){
            GameManager.SharedInstance.maxSeeds = GameManager.SharedInstance.maxSeeds + 1;
            GameManager.SharedInstance.money = GameManager.SharedInstance.money - 5;
            GameManager.SharedInstance.moneyText.text = "$" + GameManager.SharedInstance.money.ToString();
        }
    }
    public void OnBuyMoneySpace(){
        if(GameManager.SharedInstance.money >= 5){
            GameManager.SharedInstance.maxMoney = GameManager.SharedInstance.maxMoney + 20;
            GameManager.SharedInstance.money = GameManager.SharedInstance.money - 5;
            GameManager.SharedInstance.moneyText.text = "$" + GameManager.SharedInstance.money.ToString();
        }
    }
    public void OnBuyFertilizerSpace(){
        if(GameManager.SharedInstance.money >= 5){
            GameManager.SharedInstance.maxFertilizer = GameManager.SharedInstance.maxFertilizer + 1;
            GameManager.SharedInstance.money = GameManager.SharedInstance.money - 5;
            GameManager.SharedInstance.moneyText.text = "$" + GameManager.SharedInstance.money.ToString();
        }
    }
}
