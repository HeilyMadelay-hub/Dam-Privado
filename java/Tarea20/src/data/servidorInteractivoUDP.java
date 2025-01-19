package data;

import java.net.*;
import java.io.*;
import java.util.concurrent.*;

public class servidorInteractivoUDP {
    public static void main(String[] args) {
        try (DatagramSocket socket = new DatagramSocket(12345)) {
            byte[] buffer = new byte[256];
            System.out.println("Servidor UDP esperando mensajes...");

            while (true) {
                try {
                    DatagramPacket paqueteRecepcion = new DatagramPacket(buffer, buffer.length);
                    System.out.println("Esperando nuevo mensaje...");
                    socket.receive(paqueteRecepcion);

                    CompletableFuture.runAsync(() -> {
                        try {
                            String mensaje = new String(paqueteRecepcion.getData(), 0, paqueteRecepcion.getLength());
                            System.out.println("Mensaje recibido: " + mensaje);

                            int contadorA = contarLetraA(mensaje);
                            String respuesta = Integer.toString(contadorA);

                            byte[] bufferRespuesta = respuesta.getBytes();
                            InetAddress address = paqueteRecepcion.getAddress();
                            int port = paqueteRecepcion.getPort();

                            DatagramPacket paqueteEnvio = new DatagramPacket(bufferRespuesta, bufferRespuesta.length, address, port);
                            socket.send(paqueteEnvio);
                            System.out.println("Respuesta enviada al cliente: " + respuesta);

                        } catch (Exception e) {
                            System.err.println("Error en el procesamiento: " + e.getMessage());
                        }
                    });

                } catch (IOException e) {
                    System.err.println("Error al recibir datos: " + e.getMessage());
                }
            }
        } catch (SocketException e) {
            System.err.println("Problema con el socket: " + e.getMessage());
        }
    }

    private static int contarLetraA(String mensaje) {
        int contador = 0;
        for (char c : mensaje.toCharArray()) {
            if (c == 'a' || c == 'A') {
                contador++;
            }
        }
        return contador;
    }
}
