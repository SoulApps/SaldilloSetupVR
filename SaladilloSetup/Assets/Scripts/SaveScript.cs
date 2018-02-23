using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SaveScript : MonoBehaviour
{	// Objeto con la dirección ip introducida por el usuario
	public Text ipAddress;
	// Objeto que indica que se ha establecido conexion;
	public GameObject connected;
	// Objeto que indica que se ha no establecido conexion;
	public GameObject disconnected;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
	/// <summary>
	/// Método que se ejecuta cuando se pulsa el boton save.
	/// </summary>
	/// <remarks>
	/// Obtiene la dirección Ip introducidas por el usuario y la guarda en las preferencias de la aplicación.
	/// </remarks>
	public void Click()
	{
		// Se obtiene la direccion ip introducida por el usuario
		GameManager.ipaddress = ipAddress.GetComponent<Text>().text;
		// Se guarda la direccion Ip
		PlayerPrefs.SetString(GameManager.IP_ADDRESS,GameManager.ipaddress);
		// Se guarda el valor en la configuracion de la aplicación
		PlayerPrefs.Save();
		CheckConnectivity();
	}
}
