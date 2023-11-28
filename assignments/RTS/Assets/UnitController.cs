using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour{
    
    public string name;

    public bool selected = false;

    public Renderer bodyRenderer;
    
    public Color selectedColor;
    public Color hoverColor;
    Color defaultColor;

    public Animator animator;

    public CharacterController cc;

    float moveSpeed = 5;

    bool hover = false;

    Vector3 target;
    bool hasTarget = false;

    public int goldAmount;


    // Start is called before the first frame update
    void Start()
    {
        defaultColor = bodyRenderer.material.color;
        GameManager.SharedInstance.units.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 amountToMove = Vector3.zero;

        if (hasTarget)
        {
            Vector3 vectorToTarget = (target - transform.position).normalized;

            float step = 5 * Time.deltaTime;
            Vector3 rotatedTowardsVector = Vector3.RotateTowards(transform.forward, vectorToTarget, step, 1);
            rotatedTowardsVector.y = 0;
            transform.forward = rotatedTowardsVector;

            amountToMove = transform.forward * moveSpeed * Time.deltaTime;
            cc.Move(amountToMove);

            if (Vector3.Distance(transform.position, target) < 0.5f)
            {
                hasTarget = false;
            }
        }
        //Debug.Log(goldAmount);
    }

    private void OnMouseDown()
    {
        GameManager.SharedInstance.SelectUnit(this);
        SetUnitColor();
    }

    private void OnMouseEnter()
    {
        hover = true;
        SetUnitColor();
    }

    private void OnMouseExit()
    {
        hover = false;
        SetUnitColor();
    }

    public void SetTarget(Vector3 t)
    {
        target = t;
        hasTarget = true;
    }

    public void SetUnitColor()
    {
        if (selected)
        {
            bodyRenderer.material.color = selectedColor;
        }
        else if (hover)
        {
            bodyRenderer.material.color = hoverColor;
        }
        else
        {
            bodyRenderer.material.color = defaultColor;
        }
    }
}
