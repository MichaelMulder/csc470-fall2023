using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class GoldManager : MonoBehaviour
{
    int goldCount;

    float elapsedTime = 0f;

    public static event Action EmptyGold;

    public Animator goldAnimator;

    // Start is called before the first frame update
    void Start()
    {
        goldCount = 100;
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
                    if(distanceBetweenObjects < 15 && goldCount > 0){
                        goldCount--;
                        u.goldAmount++;
                        goldAnimator.SetBool("playMining", true);
                        //Debug.Log(goldCount);
                        if(goldCount == 0){
                            EmptyGold?.Invoke();
                        }
                    } else {
                        goldAnimator.SetBool("playMining", false);
                    }
                }
            }
        }
    }
    private void OnEnable()
    {
        EmptyGold += removeGold;
    }

    private void OnDisable()
    {
        EmptyGold -= removeGold;
    }
    public void removeGold(){
        Destroy(this.gameObject);
    }
}
