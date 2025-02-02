
package data;

import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;

public class TCPServidor {
    
    //Cuando en la variable servidor de tipo serversocket pasas numPuerto tienes que 
    //poner IOException porque estas reservardo el puerto y eso significa que puedes 
    //tener problemas con permisos,error en los recursos del sistema y otros problemas con 
    //los fallos de red
    
    //1.Crea un serversocket en el puerto 6000
    //2.espera conexiones de clientes
    //3.cuando un cliente se conecta le envia un objeto persona espera recibir el objeto modificado del cliente
    //4.espera recibir el objeto modificado del cliente
    //5.muestra los mensajes apropiados del cliente 
    //6.maneja las excepciones
    
    
    public static void main(String[]args) throws IOException, ClassNotFoundException {
        
        final int numPuerto=6000;//Fijamos el puerto
        
        try(ServerSocket servidor=new ServerSocket(numPuerto)){
            
            System.out.println("Servidor escuchando en el puerto "+numPuerto);
            
            //Acepta la conexion al cliente
            
            try(Socket socket=servidor.accept();
                    
               ObjectOutputStream salida=new ObjectOutputStream(socket.getOutputStream());
               ObjectInputStream entrada=new ObjectInputStream(socket.getInputStream())){
               
                //Crear y enviar un objeto cliente
                Persona persona=new Persona("Juan",25);
                
                salida.writeObject(persona);//Enviar objeto al cliente
                System.out.println("Enviado objeto persona: "+persona);
                
                //Recibir el objeto modificado del cliente
                Persona personaModificada=(Persona)entrada.readObject();
                System.out.println("Recibido objeto modificado:"+personaModificada);
               
           
           }
        }
    }
}
