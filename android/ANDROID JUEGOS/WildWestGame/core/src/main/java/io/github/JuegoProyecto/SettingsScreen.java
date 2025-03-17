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
import com.badlogic.gdx.math.Rectangle;

public class SettingsScreen implements Screen {

    private MenuScreen menuScreen;
    private SpriteBatch batch;

    private Texture background;
    private Texture buttonTexture;
    private BitmapFont font;

    // Botones para el tiempo de partida
    private Rectangle time30SecButton;
    private Rectangle time2MinButton;
    private Rectangle time3MinButton;
    private Rectangle time5MinButton;

    // Botones para volumen (música y efectos)
    private Rectangle musicToggleButton;
    private Rectangle sfxToggleButton;

    // Botón para abrir pantalla de Controles
    private Rectangle controlsButton;

    // Botón para volver al menú
    private Rectangle backButton;

    // Estados de configuración
    private float selectedDuration;
    private boolean musicOn;
    private boolean sfxOn;

    /**
     * Constructor: recibe la referencia al MenuScreen para poder
     * leer y modificar la configuración (duración, música, efectos, etc.).
     */
    public SettingsScreen(MenuScreen menuScreen) {
        this.menuScreen = menuScreen;
        this.batch = menuScreen.getBatch();

        // Tomar valores actuales desde el menuScreen
        this.selectedDuration = menuScreen.getGameDuration(); // p.e. 0.5f, 2f, 3f o 5f
        this.musicOn = menuScreen.isMusicOn();
        this.sfxOn   = menuScreen.isSfxOn();
    }

    @Override
    public void show() {
        try {
            // Log which files we're trying to load
            System.out.println("Intentando cargar textura de fondo...");

            try {
                background = new Texture(Gdx.files.internal("fondo.jpg"));
                System.out.println("Fondo cargado correctamente");
            } catch (Exception e) {
                System.err.println("Error cargando fondo: " + e.getMessage());
                // Create a fallback texture
                Pixmap fallbackPixmap = new Pixmap(1, 1, Pixmap.Format.RGBA8888);
                fallbackPixmap.setColor(Color.BROWN);
                fallbackPixmap.fill();
                background = new Texture(fallbackPixmap);
                fallbackPixmap.dispose();
            }

            System.out.println("Intentando cargar textura de botón...");
            try {
                buttonTexture = new Texture(Gdx.files.internal("configuracion.png"));
                System.out.println("Textura de botón cargada correctamente");
            } catch (Exception e) {
                System.err.println("Error cargando configuracion.png: " + e.getMessage());
                // Create a fallback texture
                Pixmap fallbackPixmap = new Pixmap(1, 1, Pixmap.Format.RGBA8888);
                fallbackPixmap.setColor(Color.ORANGE);
                fallbackPixmap.fill();
                buttonTexture = new Texture(fallbackPixmap);
                fallbackPixmap.dispose();
            }

            // Fuente para texto con manejo de errores
            try {
                font = new BitmapFont();
                font.setColor(Color.WHITE);
                font.getData().setScale(2f);
                System.out.println("Fuente cargada correctamente");
            } catch (Exception e) {
                System.err.println("Error cargando fuente: " + e.getMessage());
                font = new BitmapFont();
            }

            // Calcular posición central
            float centerX = Gdx.graphics.getWidth() / 2f;

            // Botones de tiempo de partida
            time30SecButton = new Rectangle(centerX - 260, 350, 120, 50);
            time2MinButton  = new Rectangle(centerX - 130, 350, 120, 50);
            time3MinButton  = new Rectangle(centerX,        350, 120, 50);
            time5MinButton  = new Rectangle(centerX + 130,  350, 120, 50);

            // Botones de música y efectos
            musicToggleButton = new Rectangle(centerX - 200, 250, 180, 50);
            sfxToggleButton   = new Rectangle(centerX +  20, 250, 180, 50);

            // Botón para Controles
            controlsButton = new Rectangle(centerX - 100, 150, 200, 50);

            // Botón para volver al menú principal
            backButton = new Rectangle(centerX - 100,  50, 200, 50);

            System.out.println("SettingsScreen mostrada. Duración: " + selectedDuration
                + " | Música: " + musicOn + " | Efectos: " + sfxOn);
        } catch (Exception e) {
            System.err.println("Error general en SettingsScreen.show(): " + e.getMessage());
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

        // Dibujar los botones (usando la misma textura para todos)
        if (buttonTexture != null) {
            // Botones de tiempo
            batch.draw(buttonTexture, time30SecButton.x, time30SecButton.y,
                time30SecButton.width, time30SecButton.height);
            batch.draw(buttonTexture, time2MinButton.x, time2MinButton.y,
                time2MinButton.width, time2MinButton.height);
            batch.draw(buttonTexture, time3MinButton.x, time3MinButton.y,
                time3MinButton.width, time3MinButton.height);
            batch.draw(buttonTexture, time5MinButton.x, time5MinButton.y,
                time5MinButton.width, time5MinButton.height);

            // Música y Efectos
            batch.draw(buttonTexture, musicToggleButton.x, musicToggleButton.y,
                musicToggleButton.width, musicToggleButton.height);
            batch.draw(buttonTexture, sfxToggleButton.x, sfxToggleButton.y,
                sfxToggleButton.width, sfxToggleButton.height);

            // Controles
            batch.draw(buttonTexture, controlsButton.x, controlsButton.y,
                controlsButton.width, controlsButton.height);

            // Volver
            batch.draw(buttonTexture, backButton.x, backButton.y,
                backButton.width, backButton.height);
        }

        // Título de la pantalla
        font.draw(batch, "CONFIGURACIÓN",
            Gdx.graphics.getWidth() / 2f - 100,
            Gdx.graphics.getHeight() - 60);

        // Etiqueta "Tiempo de partida"
        font.draw(batch, "TIEMPO DE PARTIDA:",
            Gdx.graphics.getWidth()/2 - 200, 420);

        // Resaltar la duración seleccionada
        // 30 SEG
        if (Math.abs(selectedDuration - 0.5f) < 0.01f) font.setColor(Color.YELLOW);
        else font.setColor(Color.WHITE);
        font.draw(batch, "30 SEG", time30SecButton.x + 10, time30SecButton.y + 35);

        // 2 MIN
        if (Math.abs(selectedDuration - 2f) < 0.01f) font.setColor(Color.YELLOW);
        else font.setColor(Color.WHITE);
        font.draw(batch, "2 MIN", time2MinButton.x + 15, time2MinButton.y + 35);

        // 3 MIN
        if (Math.abs(selectedDuration - 3f) < 0.01f) font.setColor(Color.YELLOW);
        else font.setColor(Color.WHITE);
        font.draw(batch, "3 MIN", time3MinButton.x + 15, time3MinButton.y + 35);

        // 5 MIN
        if (Math.abs(selectedDuration - 5f) < 0.01f) font.setColor(Color.YELLOW);
        else font.setColor(Color.WHITE);
        font.draw(batch, "5 MIN", time5MinButton.x + 15, time5MinButton.y + 35);

        // Música y Efectos (resaltar si están ON)
        if (musicOn) font.setColor(Color.YELLOW); else font.setColor(Color.WHITE);
        font.draw(batch, "MUSICA: " + (musicOn ? "ON" : "OFF"),
            musicToggleButton.x + 10, musicToggleButton.y + 35);

        if (sfxOn) font.setColor(Color.YELLOW); else font.setColor(Color.WHITE);
        font.draw(batch, "EFECTOS: " + (sfxOn ? "ON" : "OFF"),
            sfxToggleButton.x + 10, sfxToggleButton.y + 35);

        // Controles
        font.setColor(Color.WHITE);
        font.draw(batch, "CONTROLES", controlsButton.x + 20, controlsButton.y + 35);

        // Volver
        font.draw(batch, "VOLVER", backButton.x + 50, backButton.y + 35);

        batch.end();

        // Manejo de clicks
        if (Gdx.input.justTouched()) {
            float x = Gdx.input.getX();
            float y = Gdx.graphics.getHeight() - Gdx.input.getY();

            // Ajustar tiempo de partida
            if (time30SecButton.contains(x, y)) {
                selectedDuration = 0.5f;
                menuScreen.setGameDuration(0.5f);
                System.out.println("Duración configurada a 30 seg");
            } else if (time2MinButton.contains(x, y)) {
                selectedDuration = 2f;
                menuScreen.setGameDuration(2f);
                System.out.println("Duración configurada a 2 minutos");
            } else if (time3MinButton.contains(x, y)) {
                selectedDuration = 3f;
                menuScreen.setGameDuration(3f);
                System.out.println("Duración configurada a 3 minutos");
            } else if (time5MinButton.contains(x, y)) {
                selectedDuration = 5f;
                menuScreen.setGameDuration(5f);
                System.out.println("Duración configurada a 5 minutos");
            }
            // Música ON/OFF
            else if (musicToggleButton.contains(x, y)) {
                musicOn = !musicOn;
                menuScreen.setMusicOn(musicOn);
                System.out.println("Música ahora está: " + (musicOn ? "ON" : "OFF"));
            }
            // Efectos ON/OFF
            else if (sfxToggleButton.contains(x, y)) {
                sfxOn = !sfxOn;
                menuScreen.setSfxOn(sfxOn);
                System.out.println("Efectos ahora están: " + (sfxOn ? "ON" : "OFF"));
            }
            // Botón CONTROLES
            else if (controlsButton.contains(x, y)) {
                System.out.println("Abriendo pantalla de Controles");
                menuScreen.showControlsScreen();
            }
            // Botón VOLVER
            else if (backButton.contains(x, y)) {
                System.out.println("Volviendo al menú principal");
                menuScreen.returnToMenu();
            }
        }
    }

    @Override
    public void resize(int width, int height) {
        float centerX = width / 2f;

        // Reposicionar cada botón al cambiar la resolución
        time30SecButton.x = centerX - 260;
        time2MinButton.x  = centerX - 130;
        time3MinButton.x  = centerX;
        time5MinButton.x  = centerX + 130;

        musicToggleButton.x = centerX - 200;
        sfxToggleButton.x   = centerX + 20;

        controlsButton.x = centerX - 100;
        backButton.x     = centerX - 100;
    }

    @Override
    public void pause() { }

    @Override
    public void resume() { }

    @Override
    public void hide() { }

    /** Libera recursos gráficos */
    @Override
    public void dispose() {
        if (background != null) background.dispose();
        if (buttonTexture != null) buttonTexture.dispose();
        if (font != null) font.dispose();
    }
}
