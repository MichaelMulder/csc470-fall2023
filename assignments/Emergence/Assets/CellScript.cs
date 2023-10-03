using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{

    public bool alive = false;
    public bool isPlayer = false;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
    rend = gameObject.GetComponentInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(alive){
            rend.material.color = new Color(1f, 1f, 1f);
        } else {
            rend.material.color = new Color(.5f, .5f, .5f);
        }
        if(isPlayer){
            rend.material.color = new Color(0f, 0f, 1f);
        }
    }
}
