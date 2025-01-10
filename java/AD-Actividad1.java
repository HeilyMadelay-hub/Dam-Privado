import Accesoadatos.EJERCICIOSLIBRO.TEMA1;
import java.io.File;

/*
 * 
 * Realice un programa Java que utilice el método listFiles() para mostrar la lista de ficheros
 * en un directorio cualquiera o en el directorio actual.
 * 
 * Realice un programa Java que muestre los ficheros de un directorio.El nombre del directorio se pasara al programa desde los 
 * argumentos de main().Si el directorio no existe se debe mostrar un mensaje indicándolo
 * 
 * 
 */


public class Actividad1 {

    public static void main(String[] args) {

        String dir = "C:\\";//Ruta  que vamos a listar

        File f=new File(dir); 
        
         // Verificamos si el directorio existe y si es un directorio
         if (f.exists() && f.isDirectory()) {
            // Obtenemos la lista de archivos en el directorio
            File[] archivos = f.listFiles();
            
            if (archivos != null && archivos.length > 0) {

                System.out.println("Archivos en el directorio '" + dir + "':");
                
                for (File archivo : archivos) {
                    
                    System.out.println(archivo.getName());
                }
            } else {
                System.out.println("El directorio está vacío.");
            }
        } else {
            System.out.println("El directorio no existe o no es un directorio válido.");
        }
    }
}
