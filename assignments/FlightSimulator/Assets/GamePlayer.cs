using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayer : MonoBehaviour
{
    public static GamePlayer SharedInstance;

    public TMP_Text scoreText;

    int score = 0;

    public bool isPlane = false;

    public GameObject ring;
    public GameObject coin;

    // Start is called before the first frame update
    void Awake(){
            if (SharedInstance != null){
                Debug.Log("There should only be one GameManager!");
            }
            SharedInstance = this;

            for(int i = 0; i < 40; i++){
                generateRing();
            }
            for(int i = 0; i < 400; i++){
                generateCoin();
            }
        }

    // Update is called once per frame
    void Update()
    {
        if(score == 5){
            isPlane = !isPlane;
            score = 0;
        }
    }
        public void UpdateScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    void generateRing(){
        float x = Random.Range(0, 1000);
        float y = Random.Range(0, 100);
        float z = Random.Range(0, 1000);
        Vector3 pos = new Vector3(x, y, z);
        GameObject treeObj = Instantiate(ring, pos, Quaternion.identity);
    }
    void generateCoin(){
        float x = Random.Range(0, 1000);
        float z = Random.Range(0, 1000);
        Vector3 pos = new Vector3(x, Terrain.activeTerrain.SampleHeight(transform.position) + 1f, z);
        GameObject coinObj = Instantiate(coin, pos, Quaternion.identity);
    }
}
