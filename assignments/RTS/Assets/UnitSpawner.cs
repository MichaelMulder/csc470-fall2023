using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
	public void spawn_unit(){
		Instantiate(GameManager.SharedInstance.unitPrefab);
	}
}
