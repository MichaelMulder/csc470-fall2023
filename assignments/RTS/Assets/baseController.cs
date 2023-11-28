using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class baseController : MonoBehaviour
{
    float elapsedTime = 0f;

    public float baseAmount = 0;
    public float maxAmount = 50;
    public Image goldBar;

    // Start is called before the first frame update
    void Start()
    {
        goldBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
       elapsedTime += Time.deltaTime;
        if(elapsedTime > 1f){
            elapsedTime = elapsedTime % 1f;
            foreach (UnitController u in GameManager.SharedInstance.units){
                if(u.selected){
                    float distanceBetweenObjects = Vector3.Distance(transform.position, u.transform.position);
                    if(distanceBetweenObjects < 15 && baseAmount < maxAmount && u.goldAmount > 0){
                        baseAmount++;
                        u.goldAmount--;
                        goldBar.fillAmount = (baseAmount / maxAmount)*10;
                        Debug.Log(baseAmount);
                    }
                }
            }
        }
        if(baseAmount == 10){
            SpawnUnit();
        }
    }

    public void SpawnUnit(){
        Vector3 pos = new Vector3(5, 0, 5);
        Instantiate(GameManager.SharedInstance.unitPrefab, pos, Quaternion.identity);
        baseAmount = 0;
    }
}
