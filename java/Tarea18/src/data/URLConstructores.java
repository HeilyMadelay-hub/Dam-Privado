package data;

import java.net.MalformedURLException;
import java.net.URL;



public class URLConstructores {

  
      public static void main(String[] args) {
        try {
            
            // Configuración de proxy (opcional y comentada para pruebas)
            System.setProperty("http.proxyHost", "192.168.1.30");
            System.setProperty("http.proxyPort", "3128");
            
            // 1. Constructor simple: URL completa
            URL url1 = new URL("http://docs.oracle.com/");
            imprimirPropiedadesURL("URL 1: Constructor simple", url1);

            // 2. Constructor simple con directorio y parámetros de consulta
            URL url2 = new URL("http://localhost/PFC/gest/cli_gestion.php?S=3");
            imprimirPropiedadesURL("URL 2: Con directorio y parámetros", url2);

            // 3. Constructor con protocolo, host y directorio
            URL url3 = new URL("http", "docs.oracle.com", "/javase/10/");
            imprimirPropiedadesURL("URL 3: Protocolo, host y directorio", url3);

            // 4. Constructor con protocolo, host, puerto y directorio
            URL url4 = new URL("http", "localhost", 8084, "/WebApp/Controlador?accion=modificar");
            imprimirPropiedadesURL("URL 4: Protocolo, host, puerto y directorio", url4);

            // 5. Constructor con contexto de otra URL (ruta relativa)
            URL baseURL = new URL("https://docs.oracle.com/javase/10/");
            URL url5 = new URL(baseURL, "docs/api/java/net/URL.html");
            imprimirPropiedadesURL("URL 5: Con base y ruta relativa", url5);

           // Limpiar el proxy después de las pruebas
            System.clearProperty("http.proxyHost");
            System.clearProperty("http.proxyPort");
            
        } catch (MalformedURLException e) {
            System.err.println("Se ha producido un error al construir una URL: " + e.getMessage());
        }
    }
    
    
     private static void imprimirPropiedadesURL(String titulo, URL url) {
        System.out.println("\n" + titulo);
        System.out.println("Protocolo: " + url.getProtocol());
        System.out.println("Host: " + url.getHost());
        System.out.println("Puerto: " + url.getPort());
        System.out.println("Archivo: " + url.getFile());
        System.out.println("Usuario: " + url.getUserInfo());
        System.out.println("Path: " + url.getPath());
        System.out.println("Consulta: " + url.getQuery());
        System.out.println("Autoridad: " + url.getAuthority());
        System.out.println("Puerto por defecto: " + url.getDefaultPort());
    }
}
