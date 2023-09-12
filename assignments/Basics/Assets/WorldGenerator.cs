using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public GameObject lightPrefab;
    public GameObject lightningPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for(int j = -20; j <= 20; j = j + 5){
            for(int i = -20; i <= 20; i = i + 5){
                generateLight(i, j);
            }
        }
    }

    void generateLight(int zvalue, int xvalue)
    {
        float x = xvalue;
        float y = 0;
        float z = zvalue;
        Vector3 pos = new Vector3(x, y, z);
        GameObject lightObj = Instantiate(lightPrefab, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            float x = Random.Range(-20, 20);;
            float y = 0;
            float z = Random.Range(-20, 20);;
            Vector3 pos = new Vector3(x, y, z);
            GameObject lightningObj = Instantiate(lightningPrefab, pos, Quaternion.identity);
            Destroy(lightningObj, .2f);
        }
    }
}
