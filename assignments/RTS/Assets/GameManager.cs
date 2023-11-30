using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager SharedInstance;

    public GameObject unitPrefab;

    public List<UnitController> units = new List<UnitController>();

    UnitController selectedUnit;

    public GameObject goldPrefab;

    [SerializeField] private Button btn = null;

    // Start is called before the first frame update
    void Awake()
    {
        if (SharedInstance != null)
        {
            Debug.Log("Why is there more than one GameManager!?!?!?!");
        }
        SharedInstance = this;
        for(int x = 0; x < 40; x++){
            generateGold();
        }
    }
    void generateGold()
    {
        float x = UnityEngine.Random.Range(-200, 200);
        float y = 4.768372e-07f;
        float z = UnityEngine.Random.Range(-200, 200);
        Vector3 pos = new Vector3(x, y, z);
        GameObject goldObj = Instantiate(goldPrefab, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 999999))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("ground"))
                {
                    // If we get in here, we hit something! And the 'hit' object
                    // contains info about what we hit.
                    if (selectedUnit != null)
                    {
                        selectedUnit.SetTarget(hit.point);
                    }
                }
            }
        }
    }


    public void SelectUnit(UnitController unit)
    {
        // Deselect any units that think they are selected
        foreach (UnitController u in units) {
            u.selected = false;
            u.SetUnitColor();
        }
        selectedUnit = unit;
        selectedUnit.selected = true;
        selectedUnit.SetUnitColor();

        //UnitSelectedHappened?.Invoke(unit);
    }
}
