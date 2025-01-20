package data;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.InetAddress;
import java.net.MulticastSocket;
import java.net.SocketException;
import java.util.Scanner;

public class ServidorMulticast {

    public static void main(String[] args) {
        final String MULTICAST_IP = "225.0.0.1";
        final int PORT = 12345;

        MulticastSocket multicastSocket = null;

        try (Scanner scanner = new Scanner(System.in)) {
            // Crear el socket multicast
            multicastSocket = new MulticastSocket();
            InetAddress group = InetAddress.getByName(MULTICAST_IP);

            System.out.println("Servidor Multicast iniciado. Escribe tus mensajes:");
            System.out.println("(Escribe 'adios' para terminar)");

            String mensaje;
            while (true) {
                try {
                    // Leer mensaje desde la entrada estándar
                    mensaje = scanner.nextLine();

                    // Convertir mensaje a bytes
                    byte[] buffer = mensaje.getBytes();

                    // Crear datagrama para enviar al grupo
                    DatagramPacket packet = new DatagramPacket(buffer, buffer.length, group, PORT);

                    // Enviar datagrama
                    multicastSocket.send(packet);
                    System.out.println("Mensaje enviado: " + mensaje);

                    // Finalizar si el mensaje es "adios"
                    if ("adios".equalsIgnoreCase(mensaje.trim())) {
                        System.out.println("Servidor finalizando...");
                        break;
                    }
                } catch (IOException e) {
                    System.err.println("Error al enviar el mensaje: " + e.getMessage());
                    e.printStackTrace();
                }
            }
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

