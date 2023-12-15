using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeBuilding : MonoBehaviour
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
        GameManager.SharedInstance.buyFertilizerButton.SetActive(true);
        GameManager.SharedInstance.buyFertilizerSpace.SetActive(false);
        GameManager.SharedInstance.buyWheatSpace.SetActive(false);
        GameManager.SharedInstance.buySeedSpace.SetActive(false);
        GameManager.SharedInstance.buyMoneySpace.SetActive(false);
    }
    public void BuyFertilizerClicked(){
        if(GameManager.SharedInstance.money >= 10 && (GameManager.SharedInstance.fertilizerAmount+1) <= GameManager.SharedInstance.maxFertilizer){
            GameManager.SharedInstance.money = GameManager.SharedInstance.money - 10;
            GameManager.SharedInstance.moneyText.text = "$" + GameManager.SharedInstance.money.ToString();
            GameManager.SharedInstance.fertilizerAmount = GameManager.SharedInstance.fertilizerAmount + 1;
            GameManager.SharedInstance.fertilizerAmountText.text = "Fertilizer: " + GameManager.SharedInstance.fertilizerAmount.ToString();
        }
    }
}
