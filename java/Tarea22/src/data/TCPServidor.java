
package data;

import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;

public class TCPServidor {
    
    //Cuando en la variable servidor de tipo serversocket pasas numPuerto tienes que 
    //poner IOException porque estas reservardo el puerto y eso significa que puedes 
    //tener problemas con permisos,error en los recursos del sistema y otros problemas con 
    //los fallos de red
    
    
    public static void main(String[]args) throws IOException {
        
        final int numPuerto=6000;//Fijamos el puerto
        
        ServerSocket servidor=new ServerSocket(numPuerto);
        
        System.out.println("Servidor escuchando en el puerto "+ numPuerto);
        
        //Acepta la conexion al cliente
        
        try(Socket socket=servidor.accept();
            ObjectOutputStream salida=new ObjectOutputStream(socket.getOutputStream());
            ObjectInputStream entrada=new ObjectInputStream(socket.getInputStream())) {
            
            //Crear y enviar un objeto cliente
            
            Persona persona=new Persona("Juan",25);
            
            salida.writeObject(persona);//Enviar objeto al cliente
            
            System.out.println("Enviado datos");
        
        
        
        }
                  
                ){
        
        
        
        
        }catch(){
        
        
        
        }
        
    
    
    }

}
