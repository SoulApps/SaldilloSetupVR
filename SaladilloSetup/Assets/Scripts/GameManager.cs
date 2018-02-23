
public static class GameManager
{
    // Clave para la dirección ip
    public const string IP_ADDRESS = "IP_ADDRESS";
    // Variable para almacenar la direccion ip de la web API
    public static string ipaddress;
    // Constante con la url del emodo con la web api para comprobar la conectividad
    public const string WEB_API_CHECK_CONNECTIVITY="http://{0}/SaladilloVR/api/SaladilloVR/CheckConnectivity";

    public const string WEB_API_GET_CLIENTS = "http://{0}/SaladilloVR/api/SaladilloVR/GetClients";
    
    public const string WEB_API_LOG_CLIENT = "http://{0}/SaladilloVR/api/SaladilloVR/LogClient";
}
