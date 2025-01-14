package sql;

//Conexion sql 

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class Conexion {
    private static final String URL = "jdbc:mysql://127.0.0.1:3306/almacen"; // Cambia "tu_base_datos" por tu base
    private static final String USER = "root"; // Cambia si usas otro usuario
    private static final String PASSWORD = "1234"; // Cambia por tu contraseña

    public Connection conectar() {
        Connection conexion = null;
        try {
            conexion = DriverManager.getConnection(URL, USER, PASSWORD);
            System.out.println("Conexión exitosa a la base de datos.");
        } catch (SQLException e) {
            System.out.println("Error al conectar a la base de datos: " + e.getMessage());
        }
        return conexion;
    }    
}
