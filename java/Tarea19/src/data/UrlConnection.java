package data;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.IOException;
import java.net.URL;
import java.net.URLConnection;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;

public class UrlConnection {

    public static void main(String[] args) {

        if (args.length != 1) {
            System.out.println("Por favor, ingrese una URL como argumento.");
            return;
        }

        String urlString = args[0];

        try {
            // Crear un objeto URL a partir del argumento
            URL url = new URL(urlString);

            // Abrir la conexión
            URLConnection connection = url.openConnection();

            // Verificar si la conexión es una instancia de HttpURLConnection
            if (connection instanceof HttpURLConnection) {
                HttpURLConnection httpConnection = (HttpURLConnection) connection;

                // Verificar si la conexión fue exitosa (código HTTP 200)
                if (httpConnection.getResponseCode() != 200) {
                    System.out.println("Error al acceder a la URL. Código de respuesta: " 
                                        + httpConnection.getResponseCode());
                    return;
                }
            } else {
                System.out.println("La conexión no es de tipo HTTP. No se puede procesar.");
                return;
            }

            // Usar try-with-resources para asegurar el cierre del flujo
            try (BufferedReader reader = new BufferedReader(new InputStreamReader(connection.getInputStream()))) {
                String line;
                while ((line = reader.readLine()) != null) {
                    System.out.println(line);
                }
            }

        } catch (MalformedURLException e) {
            System.out.println("URL mal formada: " + urlString);
        } catch (IOException e) {
            System.out.println("Error al conectar o leer la URL: " + urlString);
        }
    }
}
