package data;

import java.net.*;
import java.io.*;
import java.util.Scanner;

public class clienteInteractivoUDP {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        DatagramSocket socket = null;

        try {
            socket = new DatagramSocket();
            socket.setSoTimeout(2000); // Timeout de 2 segundos

            System.out.print("Ingrese un mensaje para enviar al servidor: ");
            String mensaje = scanner.nextLine();

            // Cambiar la dirección para provocar UnknownHostException
            // InetAddress address = InetAddress.getByName("host-invalido");

            InetAddress address = InetAddress.getByName("localhost");
            byte[] buffer = mensaje.getBytes();

            // Cambiar el puerto para provocar PortUnreachableException
            // DatagramPacket paqueteEnvio = new DatagramPacket(buffer, buffer.length, address, 54321);

            DatagramPacket paqueteEnvio = new DatagramPacket(buffer, buffer.length, address, 12345);
            System.out.println("Enviando mensaje al servidor...");
            socket.send(paqueteEnvio);

            buffer = new byte[256];
            DatagramPacket paqueteRecepcion = new DatagramPacket(buffer, buffer.length);

            System.out.println("Esperando respuesta del servidor...");
            socket.receive(paqueteRecepcion);

            String respuesta = new String(paqueteRecepcion.getData(), 0, paqueteRecepcion.getLength());
            System.out.println("Respuesta del servidor: " + respuesta);

        } catch (UnknownHostException e) {
            System.err.println("Error de socket: " + e.getMessage());
        } catch (SocketTimeoutException e) {
            System.err.println("Error: El servidor no responde (Timeout)");
        } catch (SocketException e) {
            System.err.println("Error de socket: " + e.getMessage());
        } catch (IOException e) {
            System.err.println("Error de E/S: " + e.getMessage());
        } finally {
            if (socket != null && !socket.isClosed()) {
                socket.close();
            }
            scanner.close();
        }
    }
}
