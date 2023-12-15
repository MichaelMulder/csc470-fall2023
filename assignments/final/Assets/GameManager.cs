using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager SharedInstance;

    public GameObject plotPrefab;
    public GameObject cobblestonePrefab;

    PlotController selectedPlot;

    public GameObject farmCanvas;
    public GameObject sellButton;
    public GameObject buyWheatSeedButton;
    public GameObject buyFertilizerButton;

    public int wheatCount = 0;
    public TextMeshProUGUI wheatCountText;

    public int money = 100;
    public TextMeshProUGUI moneyText;

    public int wheatSeeds = 0;
    public TextMeshProUGUI wheatSeedText;

    public int fertilizerAmount = 0;
    public TextMeshProUGUI fertilizerAmountText;

    private float countDownTime = 90;
    public TextMeshProUGUI countDownTimeText;

    public GameObject buyWheatSpace;
    public GameObject buySeedSpace;
    public GameObject buyMoneySpace;
    public GameObject buyFertilizerSpace;

    public int maxWheat = 50;
    public int maxSeeds = 5;
    public int maxMoney = 150;
    public int maxFertilizer = 5;
    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = "$" + money.ToString();
        sellButton.SetActive(false);
        buyWheatSeedButton.SetActive(false);
        buyFertilizerButton.SetActive(false);
        buyFertilizerSpace.SetActive(false);
        buyWheatSpace.SetActive(false);
        buySeedSpace.SetActive(false);
        buyMoneySpace.SetActive(false);
        if (SharedInstance != null)
        {
            Debug.Log("Why is there more than one GameManager!?!?!?!");
        }
        SharedInstance = this;
        for(int i = 0; i <= 20; i++){
            for(int j = 0; j <= 20; j++){
                generatePlot(i,j);
            }
        }
        for(int i = 0; i <= 20; i++){
            for(int j = 0; j <= 20; j++){
                generateCobblestone(i,j);
            }
        }
    }

    void generatePlot(int zvalue, int xvalue)
    {
        float x = xvalue * 10;
        float y = 0;
        float z = zvalue * 10;
        Vector3 pos = new Vector3(x, y, z);
        GameObject plotObj = Instantiate(plotPrefab, pos, Quaternion.identity);
    }
    void generateCobblestone(int zvalue, int xvalue)
    {
        float x = xvalue * 10 + 200;
        float y = 0;
        float z = zvalue * 10;
        Vector3 pos = new Vector3(x, y, z);
        GameObject plotObj = Instantiate(cobblestonePrefab, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        countDownTime -= Time.deltaTime;
        Debug.Log(countDownTime);
        countDownTimeText.text = ((int)countDownTime).ToString(); 
        if(countDownTime <= 0){
            money = money - 100;
            countDownTime = 90;
            moneyText.text = "$" + money.ToString(); 
        }
        if(money < 0){
            SceneManager.LoadScene(0);
        }
    }

}
