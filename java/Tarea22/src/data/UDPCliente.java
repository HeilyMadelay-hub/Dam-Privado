package data;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;

public class UDPCliente {

    public static void main(String[] args) {
        String host = "localhost";
        int puerto = 12345;

        try (DatagramSocket socket = new DatagramSocket()) {
            InetAddress direccion = InetAddress.getByName(host);
            
            // Crear y serializar el objeto Persona
            Persona persona = new Persona("Carlos", 35);
            
            try (ByteArrayOutputStream baos = new ByteArrayOutputStream();
                 ObjectOutputStream oos = new ObjectOutputStream(baos)) {
                
                oos.writeObject(persona);
                byte[] datos = baos.toByteArray();
                
                // Enviar el objeto serializado
                DatagramPacket paquete = new DatagramPacket(
                    datos, datos.length, direccion, puerto);
                socket.send(paquete);
                
                System.out.println("Persona enviada: " + persona);
            }
        } catch (IOException e) {
            System.err.println("Error en la comunicación: " + e.getMessage());
        }
    }
}
