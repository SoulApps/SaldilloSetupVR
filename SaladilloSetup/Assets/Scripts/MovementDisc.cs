﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDisc : MonoBehaviour
{
	// Velocidad máxima de desplazamiento
	public float maxSpeed = 0.5f;
	// Fuerza de empuje
	public float pushForce = 10f;
	// Para indicar si el usuario está mirando directamente el disco
	[HideInInspector]
	public bool isHover = false;
	// Referencia al RigidBody que queremos mover
	public Rigidbody rigidbody;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void FixedUpdate()
	{
		if (isHover)
		{
			if (rigidbody.velocity.magnitude < maxSpeed)
			{
				rigidbody.AddForce((GvrPointerInputModule.Pointer.CurrentRaycastResult.worldPosition
				                    - transform.position).normalized * pushForce);
			}
		}
	}

	/// <summary>
	/// Acciones a realizar para el evento de mirar el disco.
	/// </summary>
	public void StartLookingAtDisc()
	{
		isHover = true;
	}
	
	/// <summary>
	/// Acciones a realizar para el evento de dejar de mirar el disco.
	/// </summary>
	public void StoptLookingAtDisc()
	{
		isHover = false;
	}
}
