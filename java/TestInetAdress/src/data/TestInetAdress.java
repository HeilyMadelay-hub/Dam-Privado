package data;
import java.net.InetAddress;
import java.net.UnknownHostException;

/**
 * Aplicación para explorar el uso de la clase InetAddress.
 * Permite obtener información de una dirección IP y nombres de host.
 */
public class TestInetAdress {

    public static void main(String[] args) {
        // Configuración del proxy HTTP y HTTPS (opcional)
        configurarProxy("192.168.1.30", "3128");

        try {
            // Información sobre localhost
            informacionLocalHost();

            // Información sobre una URL específica
            informacionURL("www.google.es");

            // Información de todas las direcciones IP asociadas a un nombre de host
            mostrarDireccionesAsociadas("www.google.es");

        } catch (UnknownHostException e) {
            System.err.println("Error al obtener información sobre la dirección IP: " + e.getMessage());
        }
    }

    /**
     * Configura el proxy para las conexiones HTTP y HTTPS.
     * 
     * @param host El host del proxy.
     * @param puerto El puerto del proxy.
     */
    private static void configurarProxy(String host, String puerto) {
        System.setProperty("http.proxyHost", host);
        System.setProperty("http.proxyPort", puerto);
        System.out.println("Proxy configurado: " + host + ":" + puerto);
    }

    /**
     * Muestra información sobre el host local.
     * 
     * @throws UnknownHostException Si no se puede obtener información del host local.
     */
    private static void informacionLocalHost() throws UnknownHostException {
        System.out.println("\n--- Información del host local ---");
        InetAddress localHost = InetAddress.getLocalHost();
        System.out.println("Nombre de host: " + localHost.getHostName());
        System.out.println("Dirección IP del host: " + localHost.getHostAddress());
        System.out.println("Nombre canónico del host: " + localHost.getCanonicalHostName());
    }

    /**
     * Muestra información sobre una URL específica.
     * 
     * @param url La URL de la que se desea obtener información.
     * @throws UnknownHostException Si no se puede resolver la URL.
     */
    private static void informacionURL(String url) throws UnknownHostException {
        System.out.println("\n--- Información sobre la URL: " + url + " ---");
        InetAddress dir = InetAddress.getByName(url);
        System.out.println("Nombre de host: " + dir.getHostName());
        System.out.println("Dirección IP: " + dir.getHostAddress());
        System.out.println("Nombre canónico: " + dir.getCanonicalHostName());
    }

    /**
     * Muestra todas las direcciones IP asociadas a un nombre de host.
     * 
     * @param host El nombre del host.
     * @throws UnknownHostException Si no se pueden obtener las direcciones asociadas.
     */
    private static void mostrarDireccionesAsociadas(String host) throws UnknownHostException {
        System.out.println("\n--- Direcciones IP asociadas a: " + host + " ---");
        InetAddress[] direcciones = InetAddress.getAllByName(host);
        for (int i = 0; i < direcciones.length; i++) {
            System.out.println("Dirección IP " + (i + 1) + ": " + direcciones[i].getHostAddress());
        }
    }
}

