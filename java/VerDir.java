import java.io.File;

public class VerDir{


   
    
    public static void main(String[] args) {

        //Definir el directorio especifico

        String dir = "C:\\";//Ruta  que vamos a listar

        File f=new File(dir);

        //Obtener la lista de archivos y directorios

        String[] archivos=f.list();

        if(archivos!=null){

            System.out.printf("Ficheros en el directorio '%s':%d%n", dir,archivos.length);
            //Iterar sobre los elementos del directorio
            for (int i=0;i< archivos.length;i++) {

                File f2=new File(f,archivos[i]);
                System.out.printf("Fichero nombre: %s ,es fichero? %b,es directorio?%b%n", archivos[i],f2.isFile(),f2.isDirectory());
            }


        }else{

            System.out.printf("El direcotrio '%s' no existe o no es accesibke.%n",dir);
            System.out.printf("Adios!!!!!!!!!!!!!!!");


        }
        
    }

}