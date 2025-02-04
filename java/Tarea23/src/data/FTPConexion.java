
package data;


import java.io.IOException;
import org.apache.commons.net.ftp.FTPClient;
import org.apache.commons.net.ftp.FTPFile;

public class FTPConexion {
    
    
    private static final String SERVER = "ftp.rediris.es"; // Reemplazar con el servidor FTP real
    private static final int PORT = 21; // Puerto predeterminado para FTP
    private static final String USER = "usuario"; 
    private static final String PASSWORD = "contraseña"; 

    public static void main(String[] args) {
        FTPClient ftpClient = new FTPClient();

        try {
            // Conexión al servidor FTP
            System.out.println("Intentando conectar al servidor FTP...");
            ftpClient.connect(SERVER, PORT);
            ftpClient.enterLocalPassiveMode(); // Configuración en modo pasivo

            // Autenticación
            if (ftpClient.login(USER, PASSWORD)) {
                System.out.println("Inicio de sesión exitoso.");
            } else {
                System.out.println("Inicio de sesión fallido. Verifique las credenciales.");
                return; // Salir si la autenticación falla
            }

            // Listar archivos y directorios
            System.out.println("Obteniendo lista de archivos y directorios...");
            FTPFile[] files = ftpClient.listFiles();
            if (files.length == 0) {
                System.out.println("El directorio está vacío.");
            } else {
                for (FTPFile file : files) {
                    String fileType = getTypeDescription(file);
                    System.out.println("Nombre: " + file.getName() + ", Tipo: " + fileType);
                }
            }

            // Cierre de sesión y desconexión
            if (ftpClient.logout()) {
                System.out.println("Cierre de sesión exitoso.");
            } else {
                System.out.println("No se pudo cerrar la sesión.");
            }

            ftpClient.disconnect();
            System.out.println("Conexión cerrada.");

        } catch (IOException e) {
            System.err.println("Error de conexión o comunicación con el servidor FTP: " + e.getMessage());
        } finally {
            try {
                if (ftpClient.isConnected()) {
                    ftpClient.disconnect();
                    System.out.println("Desconexión forzada debido a un error.");
                }
            } catch (IOException e) {
                System.err.println("Error al desconectar del servidor FTP: " + e.getMessage());
            }
        }
    }

    /**
     * Obtiene una descripción del tipo de archivo basada en su código.
     *
     * @param file Objeto FTPFile que representa un archivo o directorio.
     * @return Descripción del tipo de archivo (Fichero, Directorio, Enlace simbólico).
     */
    private static String getTypeDescription(FTPFile file) {
        if (file.isDirectory()) {
            return "Directorio";
        } else if (file.isFile()) {
            return "Fichero";
        } else if (file.isSymbolicLink()) {
            return "Enlace simbólico";
        } else {
            return "Tipo desconocido";
        }
    }

}
