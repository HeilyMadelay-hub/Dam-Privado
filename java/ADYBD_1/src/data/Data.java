package data;

import sql.Conexion;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;

public class Data {
	
    public static void main(String[] args) {
    	
        Conexion conexionDB = new Conexion();
        Connection conexion = conexionDB.conectar();

        if (conexion != null) {
            String sql = "INSERT INTO productos (nombre, precio, cantidad) VALUES (?, ?, ?)";

            try (PreparedStatement ps = conexion.prepareStatement(sql)) {
            	
                ps.setString(1, "Pera");
                ps.setDouble(2, 2.20);
                ps.setInt(3, 80);

                int filasAfectadas = ps.executeUpdate();
                System.out.println("Producto insertado correctamente. Filas afectadas: " + filasAfectadas);

            } catch (SQLException e) {
                System.out.println("Error al insertar el producto: " + e.getMessage());
            }
        }
    }
}
