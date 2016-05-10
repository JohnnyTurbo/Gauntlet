﻿using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public int attackStrength;
	public float attackSpeed;
	public bool isMagic;

	void Update(){
		transform.Translate (new Vector3(0,0,1) * attackSpeed * Time.deltaTime);
	}

}