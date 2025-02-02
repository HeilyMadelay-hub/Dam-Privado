
package data;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;

public class TCPCliente {
    
   public static void main(String[] args) {
        String host = "localhost";
        int puerto = 6000;

        try (
            Socket socket = new Socket(host, puerto);
            ObjectOutputStream salida = new ObjectOutputStream(socket.getOutputStream());
            ObjectInputStream entrada = new ObjectInputStream(socket.getInputStream())
        ) {
            // Recibir objeto inicial del servidor
            Persona personaRecibida = (Persona) entrada.readObject();
            System.out.println("Persona recibida del servidor: " + personaRecibida);

            // Modificar el objeto
            personaRecibida.setNombre("María");
            personaRecibida.setEdad(30);

            // Enviar objeto modificado
            System.out.println("Enviando persona modificada: " + personaRecibida);
            salida.writeObject(personaRecibida);

        } catch (IOException | ClassNotFoundException e) {
            System.err.println("Error en la comunicación: " + e.getMessage());
        }
    }
}
