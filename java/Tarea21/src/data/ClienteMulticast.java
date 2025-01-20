package data;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.InetAddress;
import java.net.MulticastSocket;
import java.net.SocketException;

public class ClienteMulticast {

    public static void main(String[] args) {
        final String MULTICAST_IP = "225.0.0.1";
        final int PORT = 12345;
        final int BUFFER_SIZE = 1024;

        MulticastSocket multicastSocket = null;

        try {
            // Crear el socket multicast y unirse al grupo
            multicastSocket = new MulticastSocket(PORT);
            InetAddress group = InetAddress.getByName(MULTICAST_IP);

            multicastSocket.joinGroup(group);
            System.out.println("Cliente conectado al grupo multicast. Esperando mensajes...");

            byte[] buffer = new byte[BUFFER_SIZE];

            while (true) {
                try {
                    // Crear datagrama para recibir mensajes
                    DatagramPacket packet = new DatagramPacket(buffer, buffer.length);

                    // Recibir mensaje del grupo multicast
                    multicastSocket.receive(packet);

                    // Convertir el mensaje de bytes a String
                    String mensaje = new String(packet.getData(), 0, packet.getLength());

                    // Mostrar el mensaje recibido
                    System.out.println("Mensaje recibido: " + mensaje);

                    // Finalizar si el mensaje es "adios"
                    if ("adios".equalsIgnoreCase(mensaje.trim())) {
                        System.out.println("Cliente desconectándose...");
                        break;
                    }
                } catch (IOException e) {
                    System.err.println("Error al recibir un mensaje: " + e.getMessage());
                    e.printStackTrace();
                }
            }

            // Salir del grupo multicast
            multicastSocket.leaveGroup(group);
            System.out.println("Cliente finalizado.");
        } catch (SocketException e) {
            System.err.println("Error al crear el socket multicast: " + e.getMessage());
        } catch (IOException e) {
            System.err.println("Error de red inesperado: " + e.getMessage());
        } finally {
            if (multicastSocket != null && !multicastSocket.isClosed()) {
                multicastSocket.close();
                System.out.println("Socket cerrado correctamente.");
            }
        }
    }
}
