using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ConfigurationText : MonoBehaviour
{

	// Objeto que indica que se ha establecido conexion;
	public GameObject connected;
	// Objeto que indica que se ha no establecido conexion;
	public GameObject disconnected;
	// Use this for initialization
	void Start ()
	{	// Se recupera el valor de direccion ip almacenado en la configuración de la aplicacion
		GameManager.ipaddress = PlayerPrefs.GetString(GameManager.IP_ADDRESS);
		// Muestra la direccion ip
		GetComponent<Text>().text = GameManager.ipaddress;

		CheckConnectivity();

	}

	/// <summary>
	/// Comprueba si existe conexión con la web API
	/// </summary>
	/// <remarks>
	/// LLamar a la corrutina CheckConnectivityWebApi para comprobar la conexion
	/// </remarks>
	private void CheckConnectivity()
	{
		StartCoroutine(CheckConnectivityWebApi());
	}

	
	 IEnumerator CheckConnectivityWebApi()
	{
		// Prepara la peticion
		using (UnityWebRequest www =
			UnityWebRequest.Get(
				Uri.EscapeUriString(string.Format(GameManager.WEB_API_CHECK_CONNECTIVITY, GameManager.ipaddress))))
		{
			// hace la peticion a la web api
			yield return www.SendWebRequest();
			
			// Comprueba el valor devuelto por el metodo , si la respuesta es correcta activa la bola connected sino activa la esfera disconned
			connected.SetActive(www.responseCode==200);
			disconnected.SetActive(!connected.activeSelf);
		}
		
	}

	// Update is called once per frame
	void Update () {
		
	}
}
