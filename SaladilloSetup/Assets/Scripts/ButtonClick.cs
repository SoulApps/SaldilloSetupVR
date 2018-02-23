//////////////////////
// Ramón Guardia
// Curso 2017-2018
// ButtonClick.cs
/////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{	// GameObject que se modifica cuando se pulsa el boton
	public GameObject clickObject;
	// Use this for initialization
	void Start () {
		// Si el objeto esta activo lo desactiva y viceversa
	
		
	}

	public void Click()
	{
		
		clickObject.SetActive(!clickObject.activeSelf);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
