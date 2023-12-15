using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SellShop : MonoBehaviour
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

    private void OnMouseDown(){
        if (EventSystem.current.IsPointerOverGameObject()){
            return;
        }
        GameManager.SharedInstance.sellButton.SetActive(true);
        GameManager.SharedInstance.buyWheatSeedButton.SetActive(true);
        GameManager.SharedInstance.buyFertilizerButton.SetActive(false);
        GameManager.SharedInstance.buyFertilizerSpace.SetActive(false);
        GameManager.SharedInstance.buyWheatSpace.SetActive(false);
        GameManager.SharedInstance.buySeedSpace.SetActive(false);
        GameManager.SharedInstance.buyMoneySpace.SetActive(false);
    }

    public void SellButtonClicked(){
        if(GameManager.SharedInstance.wheatCount > 9 && (GameManager.SharedInstance.money+15) <= GameManager.SharedInstance.maxMoney){
            GameManager.SharedInstance.money = GameManager.SharedInstance.money + 15;
            GameManager.SharedInstance.moneyText.text = "$" + GameManager.SharedInstance.money.ToString();
            GameManager.SharedInstance.wheatCount = GameManager.SharedInstance.wheatCount - 10;
            GameManager.SharedInstance.wheatCountText.text = "Wheat: " + GameManager.SharedInstance.wheatCount.ToString();
        }
    }
    public void BuySeedsClicked(){
        if(GameManager.SharedInstance.money >= 5 && (GameManager.SharedInstance.wheatSeeds+1) <= GameManager.SharedInstance.maxSeeds){
            GameManager.SharedInstance.money = GameManager.SharedInstance.money - 5;
            GameManager.SharedInstance.moneyText.text = "$" + GameManager.SharedInstance.money.ToString();
            GameManager.SharedInstance.wheatSeeds = GameManager.SharedInstance.wheatSeeds + 1;
            GameManager.SharedInstance.wheatSeedText.text = "Wheat Seeds: " + GameManager.SharedInstance.wheatSeeds.ToString();
        }
    }
}
