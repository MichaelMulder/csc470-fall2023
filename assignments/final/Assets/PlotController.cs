using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlotController : MonoBehaviour
{
    public int plotState = 0;
    RaycastHit hit;
    public Renderer plotRenderer;

    private bool inCoroutine = false;

    public Color dirt;
    public Color seeded;

    public GameObject seedPrefab;
    public GameObject wheatPrefab;
    GameObject wheatObj;

    public bool isFertilized = false;
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

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()){
            return;
        }
        if(inCoroutine == false){
                setPlotState();
                Debug.Log(plotState);
            if(plotState == 2 && GameManager.SharedInstance.wheatSeeds >= 1){
                //StopAllCoroutines();
                inCoroutine = true;
                GameManager.SharedInstance.wheatSeeds = GameManager.SharedInstance.wheatSeeds - 1;
                GameManager.SharedInstance.wheatSeedText.text = "Wheat Seeds: " + GameManager.SharedInstance.wheatSeeds.ToString();
                StartCoroutine(ChangePlot(10f));
            } else if(plotState == 1) {
                Destroy(wheatObj);
                ChangeColor();
            } else if(plotState == 3){
                Destroy(wheatObj);
                if(isFertilized && (GameManager.SharedInstance.wheatCount+20) <= GameManager.SharedInstance.maxWheat){
                    GameManager.SharedInstance.wheatCount = GameManager.SharedInstance.wheatCount + 20;
                } else if((GameManager.SharedInstance.wheatCount+10) <= GameManager.SharedInstance.maxWheat) {
                    GameManager.SharedInstance.wheatCount = GameManager.SharedInstance.wheatCount + 10;
                }
                isFertilized = false;
                GameManager.SharedInstance.fertilizerAmountText.text = "Fertilizer: " + GameManager.SharedInstance.fertilizerAmount.ToString();
                GameManager.SharedInstance.wheatCountText.text = "Wheat: " + GameManager.SharedInstance.wheatCount.ToString();
                setPlotState();
                ChangeColor();
            } else if(plotState == 0) {
                ChangeColor();
            }
        } else {
            isFertilized = true;
            GameManager.SharedInstance.fertilizerAmount--;
            GameManager.SharedInstance.fertilizerAmountText.text = "Fertilizer: " + GameManager.SharedInstance.fertilizerAmount.ToString();
        }
    }

    public void ChangeColor(){
        if (plotState == 0){
            plotRenderer.material.color = dirt;
        }
        else {
            plotRenderer.material.color = seeded;
        }
    }

    public void setPlotState(){
        plotState++;
        if(plotState == 4){
            plotState = 0;
        }
    }

    private IEnumerator ChangePlot(float time)
    {
        Vector3 pos = transform.position;
        GameObject seedObj = Instantiate(seedPrefab, pos, Quaternion.identity);
        yield return new WaitForSeconds(time);
        inCoroutine = false;
        Destroy(seedObj);
        wheatObj = Instantiate(wheatPrefab, pos, Quaternion.identity);
    }
}
