package io.github.JuegoProyecto;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input;
import com.badlogic.gdx.Screen;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.Pixmap;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.BitmapFont;
import com.badlogic.gdx.graphics.g2d.GlyphLayout;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.graphics.glutils.ShapeRenderer;
import com.badlogic.gdx.math.Rectangle;


public class MenuScreen implements Screen {

    private final WildWestGame game;

    // SpriteBatch compartido
    private SpriteBatch batch;

    // Recursos del menú
    private Texture menuBackground;
    private Texture playButton;
    private Texture settingsButton;
    private Texture exitButton;

    // Instancia de la pantalla de controles
    private ControlScreen controlsScreen;

    private Rectangle playBounds;
    private Rectangle settingsBounds;
    private Rectangle exitBounds;

    // Instancia de la pantalla de configuración
    private SettingsScreen settingsScreen;

    // Configuración del juego
    private float gameDuration = 1f;
    private boolean sfxOn   = true;   // Efectos activados por defecto
    private boolean musicOn = true;   // Música activada por defecto


    // Current screen being shown
    private Screen currentScreen;

    // Variable de clase
    private ShapeRenderer shapeRenderer;

    // Fuente para el texto de los botones
    private BitmapFont font;

    // Fuente para el título del juego
    private BitmapFont titleFont;


    // En el constructor
    public MenuScreen(WildWestGame game) {
        this.game = game;
        this.batch = game.getBatch(); // Usar el SpriteBatch compartido
        this.currentScreen = this;
        this.shapeRenderer = new ShapeRenderer(); // Inicializar una sola vez

        // Inicializar la fuente para los botones
        this.font = new BitmapFont();
        this.font.getData().setScale(2.0f); // Aumentar el tamaño de la fuente
        this.font.setColor(Color.WHITE); // Establecer color blanco para el texto

        // Inicializar la fuente para el título
        this.titleFont = new BitmapFont();
        this.titleFont.getData().setScale(3.5f); // Fuente más grande para el título
        this.titleFont.setColor(Color.WHITE); // Establecer color blanco para el título
    }

    @Override
    public void show() {
        try {
            // Mostrar información de depuración sobre directorios
            System.out.println("Directorio de trabajo: " + Gdx.files.getLocalStoragePath());
            System.out.println("Intentando cargar recursos del menú...");

            // Cargar texturas con manejo de errores y depuración extendida
            try {
                // Verificar si el archivo existe antes de cargarlo
                if (Gdx.files.internal("menu.png").exists()) {
                    System.out.println("menu.png encontrado, intentando cargar...");
                    menuBackground = new Texture("menu.png");
                    System.out.println("Menu background cargado correctamente");
                } else {
                    System.out.println("menu.png NO EXISTE en la ruta predeterminada");
                    // Intentar buscar en ubicaciones alternativas
                    String[] posiblesPaths = {"assets/menu.png", "data/menu.png", "images/menu.png"};
                    boolean encontrado = false;

                    for (String path : posiblesPaths) {
                        System.out.println("Intentando cargar desde: " + path);
                        if (Gdx.files.internal(path).exists()) {
                            menuBackground = new Texture(Gdx.files.internal(path));
                            System.out.println("Menu background cargado desde " + path);
                            encontrado = true;
                            break;
                        }
                    }

                    if (!encontrado) {
                        System.out.println("No se encontró menu.png en ninguna ruta, usando fallback");
                        // Crear una textura de fallback si falla la carga
                        Pixmap pixmap = new Pixmap(Gdx.graphics.getWidth(), Gdx.graphics.getHeight(), Pixmap.Format.RGBA8888);
                        pixmap.setColor(Color.BROWN);
                        pixmap.fill();
                        menuBackground = new Texture(pixmap);
                        pixmap.dispose();
                    }
                }
            } catch (Exception e) {
                System.err.println("Error al cargar menu.png: " + e.getMessage());
                e.printStackTrace(); // Esto mostrará la traza completa del error
                // Crear una textura de fallback si falla la carga
                Pixmap pixmap = new Pixmap(Gdx.graphics.getWidth(), Gdx.graphics.getHeight(), Pixmap.Format.RGBA8888);
                pixmap.setColor(Color.BROWN);
                pixmap.fill();
                menuBackground = new Texture(pixmap);
                pixmap.dispose();
            }


            // Definir áreas de botones con posiciones que aseguren visibilidad
            float centerX = Gdx.graphics.getWidth() / 2f;
            float centerY = Gdx.graphics.getHeight() / 2f;

            // Posicionar botones en el centro de la pantalla y hacerlos más grandes
            playBounds = new Rectangle(centerX - 180, centerY + 100, 360, 90);
            settingsBounds = new Rectangle(centerX - 180, centerY, 360, 90);
            exitBounds = new Rectangle(centerX - 180, centerY - 100, 360, 90);

            // Similar proceso de diagnóstico para los botones
            try {
                boolean todosCargados = true;

                // Verificar e intentar cargar cada botón individualmente
                if (Gdx.files.internal("iniciarjuego.png").exists()) {
                    playButton = new Texture("iniciarjuego.png");
                    System.out.println("iniciarjuego.png cargado correctamente");
                } else {
                    System.out.println("No se encontró iniciarjuego.png");
                    todosCargados = false;
                }

                if (Gdx.files.internal("configuracion.png").exists()) {
                    settingsButton = new Texture("configuracion.png");
                    System.out.println("configuracion.png cargado correctamente");
                } else {
                    System.out.println("No se encontró configuracion.png");
                    todosCargados = false;
                }

                if (Gdx.files.internal("salir.png").exists()) {
                    exitButton = new Texture("salir.png");
                    System.out.println("salir.png cargado correctamente");
                } else {
                    System.out.println("No se encontró salir.png");
                    todosCargados = false;
                }

                if (!todosCargados) {
                    System.out.println("Algunos botones no se cargaron, usando fallback");
                    // Crear fallbacks con colores distintivos para cada botón
                    Pixmap playPixmap = new Pixmap(360, 90, Pixmap.Format.RGBA8888);
                    playPixmap.setColor(new Color(0.8f, 0.6f, 0.4f, 1)); // Color beige claro
                    playPixmap.fill();

                    Pixmap settingsPixmap = new Pixmap(360, 90, Pixmap.Format.RGBA8888);
                    settingsPixmap.setColor(new Color(0.9f, 0.5f, 0.3f, 1)); // Color anaranjado
                    settingsPixmap.fill();

                    Pixmap exitPixmap = new Pixmap(360, 90, Pixmap.Format.RGBA8888);
                    exitPixmap.setColor(new Color(0.8f, 0.4f, 0.2f, 1)); // Color marrón rojizo
                    exitPixmap.fill();

                    if (playButton == null) {
                        playButton = new Texture(playPixmap);
                    }
                    if (settingsButton == null) {
                        settingsButton = new Texture(settingsPixmap);
                    }
                    if (exitButton == null) {
                        exitButton = new Texture(exitPixmap);
                    }

                    playPixmap.dispose();
                    settingsPixmap.dispose();
                    exitPixmap.dispose();
                }
            } catch (Exception e) {
                System.err.println("Error al cargar botones: " + e.getMessage());
                e.printStackTrace();

                // Crear texturas de fallback con colores distintivos
                Pixmap playPixmap = new Pixmap(360, 90, Pixmap.Format.RGBA8888);
                playPixmap.setColor(new Color(0.8f, 0.6f, 0.4f, 1));
                playPixmap.fill();

                Pixmap settingsPixmap = new Pixmap(360, 90, Pixmap.Format.RGBA8888);
                settingsPixmap.setColor(new Color(0.9f, 0.5f, 0.3f, 1));
                settingsPixmap.fill();

                Pixmap exitPixmap = new Pixmap(360, 90, Pixmap.Format.RGBA8888);
                exitPixmap.setColor(new Color(0.8f, 0.4f, 0.2f, 1));
                exitPixmap.fill();

                playButton = new Texture(playPixmap);
                settingsButton = new Texture(settingsPixmap);
                exitButton = new Texture(exitPixmap);

                playPixmap.dispose();
                settingsPixmap.dispose();
                exitPixmap.dispose();
            }

            // Crear instancia de SettingsScreen
            settingsScreen = new SettingsScreen(this);

            System.out.println("MenuScreen show() completado correctamente");
        } catch (Exception e) {
            System.err.println("Error general en show(): " + e.getMessage());
            e.printStackTrace();
        }
    }

    @Override
    public void render(float delta) {
        if (currentScreen != this) {
            // Si estamos mostrando otra pantalla, delegar el render
            currentScreen.render(delta);

            // Comprobar escape para volver al menú desde settings o controls
            if ((currentScreen == settingsScreen || currentScreen == controlsScreen)
                && Gdx.input.isKeyJustPressed(Input.Keys.ESCAPE)) {
                returnToMenu();
            }
            return;
        }

        // Limpiar la pantalla una sola vez aquí
        Gdx.gl.glClearColor(0.2f, 0.2f, 0.4f, 1); // Fondo azul oscuro para distinguir
        Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);

        renderMenu();
    }

    private void renderMenu() {
        System.out.println("Dibujando menú...");

        // Mensajes de diagnóstico
        System.out.println("menuBackground es null? " + (menuBackground == null));
        System.out.println("Tamaño de ventana: " + Gdx.graphics.getWidth() + "x" + Gdx.graphics.getHeight());
        System.out.println("Posiciones de botones: Play(" + playBounds.x + "," + playBounds.y + ")");

        // Dibujar texturas
        batch.begin();
        if (menuBackground != null) {
            batch.draw(menuBackground, 0, 0, Gdx.graphics.getWidth(), Gdx.graphics.getHeight());
            System.out.println("Dibujando fondo del menú");

            // Para centrar el texto en los botones
            GlyphLayout layout = new GlyphLayout();

            // Dibujar el título "WildWestGame" encima del botón "Iniciar Partida"
            layout.setText(titleFont, "WildWestGame");
            float titleX = Gdx.graphics.getWidth() / 2f - layout.width / 2;
            float titleY = playBounds.y + playBounds.height + 80; // 80 píxeles encima del botón superior
            titleFont.draw(batch, "WildWestGame", titleX, titleY);

            // Dibujar botones con texto
            if (playButton != null) {
                batch.draw(playButton, playBounds.x, playBounds.y, playBounds.width, playBounds.height);
                System.out.println("Dibujando botón de juego");

                // Dibujar texto "INICIAR PARTIDA" dentro del botón
                layout.setText(font, "INICIAR PARTIDA");
                float textX = playBounds.x + (playBounds.width - layout.width) / 2;
                float textY = playBounds.y + (playBounds.height + layout.height) / 2;
                font.draw(batch, "INICIAR PARTIDA", textX, textY);
            }

            if (settingsButton != null) {
                batch.draw(settingsButton, settingsBounds.x, settingsBounds.y, settingsBounds.width, settingsBounds.height);
                System.out.println("Dibujando botón de configuración");

                // Dibujar texto "CONFIGURACION" dentro del botón
                layout.setText(font, "CONFIGURACION");
                float textX = settingsBounds.x + (settingsBounds.width - layout.width) / 2;
                float textY = settingsBounds.y + (settingsBounds.height + layout.height) / 2;
                font.draw(batch, "CONFIGURACION", textX, textY);
            }

            if (exitButton != null) {
                batch.draw(exitButton, exitBounds.x, exitBounds.y, exitBounds.width, exitBounds.height);
                System.out.println("Dibujando botón de salida");

                // Dibujar texto "SALIR" dentro del botón
                layout.setText(font, "SALIR");
                float textX = exitBounds.x + (exitBounds.width - layout.width) / 2;
                float textY = exitBounds.y + (exitBounds.height + layout.height) / 2;
                font.draw(batch, "SALIR", textX, textY);
            }
        } else {
            System.out.println("menuBackground es null, no se puede dibujar el menú");
        }
        batch.end();

        // Comprobar clics
        if (Gdx.input.justTouched()) {
            float x = Gdx.input.getX();
            float y = Gdx.graphics.getHeight() - Gdx.input.getY(); // Invertir Y
            System.out.println("Toque detectado en: (" + x + ", " + y + ")");

            if (playBounds.contains(x, y)) {
                System.out.println("Botón de juego presionado");
                startGame();
            } else if (settingsBounds.contains(x, y)) {
                try {
                    System.out.println("Botón de configuración presionado");

                    if (settingsScreen == null) {
                        settingsScreen = new SettingsScreen(this);
                    }

                    currentScreen = settingsScreen;
                    settingsScreen.show();
                    System.out.println("Transición a configuración completada");
                } catch (Exception e) {
                    System.err.println("Error en la transición a la pantalla de configuración: " + e.getMessage());
                    e.printStackTrace();
                    currentScreen = this;
                }
            } else if (exitBounds.contains(x, y)) {
                System.out.println("Botón de salida presionado");
                Gdx.app.exit();
            }
        }
    }


    private void startGame() {
        // Crear e inicializar la pantalla de juego
        GameScreen gameScreen = new GameScreen(game);

        // Pasar la configuración al GameScreen
        gameScreen.setGameDuration(gameDuration);
        gameScreen.setMusicOn(musicOn);
        gameScreen.setSfxOn(sfxOn);

        System.out.println("Iniciando juego con duración: " + gameDuration + " segundos, equivale a "
            + (gameDuration/60) + " minutos");
        System.out.println("Música: " + (musicOn ? "ON" : "OFF") + ", Efectos: " + (sfxOn ? "ON" : "OFF"));

        game.setScreen(gameScreen);
    }

    @Override
    public void resize(int width, int height) {
        // Ajustar botones a la nueva resolución
        float centerX = width / 2f;
        playBounds.x = centerX - 180;
        settingsBounds.x = centerX - 180;
        exitBounds.x = centerX - 180;

        // Propagar resize a la pantalla actual
        if (currentScreen != this) {
            currentScreen.resize(width, height);
        }
    }

    @Override
    public void pause() {
        if (currentScreen != this) {
            currentScreen.pause();
        }
    }

    @Override
    public void resume() {
        if (currentScreen != this) {
            currentScreen.resume();
        }
    }

    @Override
    public void hide() {
        // No es necesario implementar
    }

    @Override
    public void dispose() {
        if (menuBackground != null) menuBackground.dispose();
        if (playButton != null) playButton.dispose();
        if (settingsButton != null) settingsButton.dispose();
        if (exitButton != null) exitButton.dispose();
        if (shapeRenderer != null) shapeRenderer.dispose();
        if (font != null) font.dispose();
        if (titleFont != null) titleFont.dispose();
        if (settingsScreen != null) {
            settingsScreen.dispose();
        }
        if (controlsScreen != null) {
            controlsScreen.dispose();
        }
    }

    // Método para configurar la duración del juego en minutos
    public void setGameDuration(float minutes) {
        this.gameDuration = minutes; // Almacenar en minutos como entero
    }

    public float getGameDuration() {
        return gameDuration;
    }
    public void returnToMenu() {
        currentScreen = this;
    }

    // Para compartir el SpriteBatch
    public SpriteBatch getBatch() {
        return batch;
    }

    // Para obtener la referencia al juego principal
    public WildWestGame getGame() {
        return game;
    }

    public boolean isMusicOn() {
        return musicOn;
    }

    public void setMusicOn(boolean musicOn) {
        this.musicOn = musicOn;
        // Aquí podrías, por ejemplo, detener la música global o reanudarla
        // si tu juego principal la maneja de forma centralizada.
    }

    public boolean isSfxOn() {
        return sfxOn;
    }

    public void setSfxOn(boolean sfxOn) {
        this.sfxOn = sfxOn;
        // Similarmente, aquí podrías establecer un volumen de 0
        // para los efectos o reactivarlos.
    }

    // --------------------------
    // PANTALLA DE CONTROLES
    // --------------------------
    /**
     * Muestra la pantalla de controles.
     * (Necesitarías implementar ControlsScreen y su lógica)
     */
    public void showControlsScreen() {
        controlsScreen = new ControlScreen(this);
        currentScreen = controlsScreen;
        controlsScreen.show();
    }

    /**
     * Obtiene la referencia a la pantalla de configuración.
     */
    public SettingsScreen getSettingsScreen() {
        return settingsScreen;
    }

    /**
     * Establece la pantalla actual.
     */
    public void setCurrentScreen(Screen screen) {
        this.currentScreen = screen;
    }
}
