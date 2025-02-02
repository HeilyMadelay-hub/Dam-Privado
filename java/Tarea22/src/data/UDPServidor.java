
package data;

import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.net.DatagramPacket;
import java.net.DatagramSocket;

public class UDPServidor {
    
    public static void main(String[] args) {
        int puerto = 12345;
        byte[] buffer = new byte[1024];

        try (DatagramSocket socket = new DatagramSocket(puerto)) {
            System.out.println("Servidor UDP iniciado en puerto " + puerto);

            while (true) {
                try {
                    // Preparar el paquete para recibir datos
                    DatagramPacket paquete = new DatagramPacket(buffer, buffer.length);
                    socket.receive(paquete);

                    // Deserializar el objeto
                    try (ByteArrayInputStream bais = new ByteArrayInputStream(paquete.getData());
                         ObjectInputStream ois = new ObjectInputStream(bais)) {
                        
                        Persona personaRecibida = (Persona) ois.readObject();
                        System.out.println("Persona recibida: " + personaRecibida);
                    }
                } catch (IOException | ClassNotFoundException e) {
                    System.err.println("Error al procesar el paquete: " + e.getMessage());
                }
            }
        } catch (IOException e) {
            System.err.println("Error al iniciar el servidor: " + e.getMessage());
        }
    }
}