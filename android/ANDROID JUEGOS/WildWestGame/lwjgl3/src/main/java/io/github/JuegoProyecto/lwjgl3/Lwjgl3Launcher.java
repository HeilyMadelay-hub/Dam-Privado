package io.github.JuegoProyecto.lwjgl3;

import com.badlogic.gdx.backends.lwjgl3.Lwjgl3Application;
import com.badlogic.gdx.backends.lwjgl3.Lwjgl3ApplicationConfiguration;

import io.github.JuegoProyecto.MenuScreen;
import io.github.JuegoProyecto.WildWestGame;

/** Launches the desktop (LWJGL3) application. */
public class Lwjgl3Launcher {
    public static void main(String[] args) {
        if (StartupHelper.startNewJvmIfRequired()) return; // This handles macOS support and helps on Windows.
        createApplication();
    }

    private static Lwjgl3Application createApplication() {
        return new Lwjgl3Application(new WildWestGame(), getDefaultConfiguration());
    }

    private static Lwjgl3ApplicationConfiguration getDefaultConfiguration() {
        Lwjgl3ApplicationConfiguration configuration = new Lwjgl3ApplicationConfiguration();
        configuration.setTitle("Sheriff VS Bandido");
        configuration.useVsync(true);
        configuration.setForegroundFPS(Lwjgl3ApplicationConfiguration.getDisplayMode().refreshRate + 1);

        // Cambiar a un tamaño que coincida con el aspecto del fondo (1416x582)
        // Podemos usar el tamaño real o una versión escalada manteniendo la proporción
        configuration.setWindowedMode(1416, 582); // Tamaño completo del fondo
        // Alternativa: configuration.setWindowedMode(1000, 412); // Versión escalada manteniendo proporción

        configuration.setResizable(false);        // Desactiva el redimensionamiento

        configuration.setWindowIcon("libgdx128.png", "libgdx64.png", "libgdx32.png", "libgdx16.png");
        return configuration;
    }
}
