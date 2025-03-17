package io.github.JuegoProyecto;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input;
import com.badlogic.gdx.Screen;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.Pixmap;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.BitmapFont;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import java.awt.Rectangle;

public class ControlScreen implements Screen {

    private MenuScreen menuScreen;
    private SpriteBatch batch;

    private Texture background;
    private Texture buttonTexture;
    private BitmapFont font;
    private BitmapFont titleFont;

    // Botón para volver
    private com.badlogic.gdx.math.Rectangle backButton;

    /**
     * Constructor: recibe la referencia al MenuScreen para poder
     * volver al menú de configuración.
     */
    public ControlScreen(MenuScreen menuScreen) {
        this.menuScreen = menuScreen;
        this.batch = menuScreen.getBatch();
    }

    @Override
    public void show() {
        try {
            System.out.println("Mostrando pantalla de controles...");

            // Cargar texturas con manejo de errores
            try {
                background = new Texture(Gdx.files.internal("fondo.jpg"));
                System.out.println("Fondo de controles cargado correctamente");
            } catch (Exception e) {
                System.err.println("Error cargando fondo.jpg: " + e.getMessage());
                // Crear una textura de fallback
                Pixmap fallbackPixmap = new Pixmap(1, 1, Pixmap.Format.RGBA8888);
                fallbackPixmap.setColor(Color.BROWN);
                fallbackPixmap.fill();
                background = new Texture(fallbackPixmap);
                fallbackPixmap.dispose();
            }

            try {
                buttonTexture = new Texture(Gdx.files.internal("configuracion.png"));
                System.out.println("Textura de botón cargada correctamente");
            } catch (Exception e) {
                System.err.println("Error cargando configuracion.png: " + e.getMessage());
                // Crear una textura de fallback
                Pixmap fallbackPixmap = new Pixmap(1, 1, Pixmap.Format.RGBA8888);
                fallbackPixmap.setColor(Color.ORANGE);
                fallbackPixmap.fill();
                buttonTexture = new Texture(fallbackPixmap);
                fallbackPixmap.dispose();
            }

            // Inicializar fuentes
            font = new BitmapFont();
            font.setColor(Color.WHITE);
            font.getData().setScale(1.5f);

            titleFont = new BitmapFont();
            titleFont.setColor(Color.WHITE);
            titleFont.getData().setScale(2.5f);

            // Calcular posición central
            float centerX = Gdx.graphics.getWidth() / 2f;

            // Botón para volver
            backButton = new com.badlogic.gdx.math.Rectangle(centerX - 100, 50, 200, 50);

        } catch (Exception e) {
            System.err.println("Error en ControlsScreen.show(): " + e.getMessage());
            e.printStackTrace();
        }
    }

    @Override
    public void render(float delta) {
        // Limpiar la pantalla
        Gdx.gl.glClearColor(0.1f, 0.1f, 0.1f, 1);
        Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);

        batch.begin();

        // Dibujar fondo
        if (background != null) {
            batch.draw(background, 0, 0, Gdx.graphics.getWidth(), Gdx.graphics.getHeight());
        }

        // Título de la pantalla
        titleFont.draw(batch, "CONTROLES DEL JUEGO",
            Gdx.graphics.getWidth() / 2f - 150,
            Gdx.graphics.getHeight() - 60);

        // Información de controles
        float startY = Gdx.graphics.getHeight() - 120;
        float lineHeight = 40; // Espacio entre líneas
        float leftColumnX = 100;
        float rightColumnX = Gdx.graphics.getWidth() / 2f + 50;

        // Cabecera de jugadores
        font.draw(batch, "SHERIFF (JUGADOR 1)", leftColumnX, startY);
        font.draw(batch, "BANDIDO (JUGADOR 2)", rightColumnX, startY);

        // Controles de movimiento
        font.draw(batch, "Moverse izquierda: A", leftColumnX, startY - lineHeight);
        font.draw(batch, "Moverse derecha: D", leftColumnX, startY - lineHeight * 2);
        font.draw(batch, "Disparar: W", leftColumnX, startY - lineHeight * 3);

        font.draw(batch, "Moverse izquierda: FLECHA IZQUIERDA", rightColumnX, startY - lineHeight);
        font.draw(batch, "Moverse derecha: FLECHA DERECHA", rightColumnX, startY - lineHeight * 2);
        font.draw(batch, "Disparar: FLECHA ARRIBA", rightColumnX, startY - lineHeight * 3);

        // Información de puntuación
        float scoringY = startY - lineHeight * 5;
        titleFont.draw(batch, "PUNTUACIÓN", Gdx.graphics.getWidth() / 2f - 100, scoringY);

        font.draw(batch, "Águila: 3 puntos", leftColumnX, scoringY - lineHeight);
        font.draw(batch, "Caballo: 2 puntos", leftColumnX, scoringY - lineHeight * 2);
        font.draw(batch, "Buey: 1 punto", leftColumnX, scoringY - lineHeight * 3);

        // Información adicional
        float infoY = scoringY - lineHeight * 5;
        titleFont.draw(batch, "INFORMACIÓN GENERAL", Gdx.graphics.getWidth() / 2f - 150, infoY);

        font.draw(batch, "Volver al menú: ESC", Gdx.graphics.getWidth() / 2f - 100, infoY - lineHeight);
        font.draw(batch, "Gana el jugador con más puntos al finalizar el tiempo",
            Gdx.graphics.getWidth() / 2f - 250, infoY - lineHeight * 2);

        // Dibujar botón VOLVER
        if (buttonTexture != null) {
            batch.draw(buttonTexture, backButton.x, backButton.y, backButton.width, backButton.height);
        }
        font.draw(batch, "VOLVER", backButton.x + 60, backButton.y + 35);

        batch.end();

        // Manejo de clicks
        if (Gdx.input.justTouched()) {
            float x = Gdx.input.getX();
            float y = Gdx.graphics.getHeight() - Gdx.input.getY();

            // Botón VOLVER
            if (backButton.contains(x, y)) {
                System.out.println("Volviendo a la pantalla de configuración");
                // Cambiamos la pantalla actual en MenuScreen a SettingsScreen
                if (menuScreen.getSettingsScreen() != null) {
                    menuScreen.setCurrentScreen(menuScreen.getSettingsScreen());
                } else {
                    // Si por alguna razón SettingsScreen es null, volvemos al menú principal
                    menuScreen.returnToMenu();
                }
            }
        }

        // También permitir volver con ESC
        if (Gdx.input.isKeyJustPressed(Input.Keys.ESCAPE)) {
            System.out.println("Volviendo a la pantalla de configuración (ESC)");
            // Mismo comportamiento que el botón VOLVER
            if (menuScreen.getSettingsScreen() != null) {
                menuScreen.setCurrentScreen(menuScreen.getSettingsScreen());
            } else {
                menuScreen.returnToMenu();
            }
        }
    }

    @Override
    public void resize(int width, int height) {
        // Ajustar botón a la nueva resolución
        float centerX = width / 2f;
        backButton.x = centerX - 100;
    }

    @Override
    public void pause() {
        // Método requerido por la interfaz Screen
    }

    @Override
    public void resume() {
        // Método requerido por la interfaz Screen
    }

    @Override
    public void hide() {
        // Método requerido por la interfaz Screen
    }

    @Override
    public void dispose() {
        if (background != null) background.dispose();
        if (buttonTexture != null) buttonTexture.dispose();
        if (font != null) font.dispose();
        if (titleFont != null) titleFont.dispose();
    }
}
