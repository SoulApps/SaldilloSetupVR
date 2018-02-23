using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGazeClick : MonoBehaviour
{
    // Tiempo que tardara en activarse el temporizador
    public float activationTime = 3f;

    // Indica si el puntero esta sobre el objeto
    private bool isHover = false;
    // Indica si la accion se ha realizado
    private bool executed = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Si el usuario esta mirando el objeto y el temporizador
        // ha terminado de contrar o si el usuario esta mirando el 
        // objeto y pulsa el boton fire1 del mando y la accion aun
        // no se ha ejecutado, realizaremos la accion correspondiente
        if ((isHover && CustomPointerTimer.CPT.ended && !executed) ||
            (isHover && Input.GetButtonDown("Fire1") && !executed))
        {
            // Se indicaa que se ha realizado la accion
            executed = true;
            // Desactivaremos el contadoe de tiempo del cursor, para
            // evitar que se quede bloqueado
            CustomPointerTimer.CPT.StopCounting();
            // Invocar al click del button
            GetComponent<Button>().onClick.Invoke();
        }
    }
    /// <summary>
    /// Metodo que llamaremos desde EventTrigger PointerEmter
    /// </summary>
    public void StartHover()
    {
        // Indicamos que el objeto esya soemdp ,oradp directamento
        isHover = true;
        // Marcamos la accion como no realizada
        executed = false;
        // Iniciamos el contador del puntero, indicadole el tiempo de activacion
        CustomPointerTimer.CPT.StartCounting(activationTime);
    }

    /// <summary>
    /// Metodo que llamaremos desde el eventTrigger pointerexit
    /// </summary>
    public void EndHover()
    {
        // Indicamos que el objeto ya no esta siendo mirado
        isHover = false;
        // Reiniciamos el contador del pintero
        CustomPointerTimer.CPT.StopCounting();
    }
}