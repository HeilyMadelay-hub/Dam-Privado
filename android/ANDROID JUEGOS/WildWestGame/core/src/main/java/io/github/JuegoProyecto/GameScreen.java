package io.github.JuegoProyecto;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input;
import com.badlogic.gdx.Screen;
import com.badlogic.gdx.audio.Music;
import com.badlogic.gdx.audio.Sound;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.Pixmap;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.BitmapFont;
import com.badlogic.gdx.graphics.g2d.GlyphLayout;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.Rectangle;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.utils.ScreenUtils;
import com.badlogic.gdx.utils.viewport.FitViewport;
import com.badlogic.gdx.utils.viewport.Viewport;
import com.badlogic.gdx.graphics.OrthographicCamera;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.Random;
import com.badlogic.gdx.graphics.g2d.freetype.FreeTypeFontGenerator;
import com.badlogic.gdx.graphics.g2d.freetype.FreeTypeFontGenerator.FreeTypeFontParameter;

public class GameScreen implements Screen {
    private WildWestGame game;
    private SpriteBatch batch;
    private Texture image;
    private Texture jugador1, jugador2;
    private Texture aguilaTexture, caballoTexture, bueyTexture;
    private Viewport viewport;
    private OrthographicCamera camera;
    private BitmapFont fuenteOeste;
    private GlyphLayout layout;
    private Texture hudFondo;
    private boolean mostrarMensaje = false;
    private String mensajeGanador = "";
    private float tiempoMensaje = 0;
    private final float DURACION_MENSAJE = 2f;
    private float gameDuration = 180;//valor predeterminado que luego suscribira menuscreen
    private float gameTimer = 0;
    private boolean gameTimeOver = false;
    private int puntosJugador1 = 0;
    private int puntosJugador2 = 0;
    private Music musicadefondopartida;
    private Sound disparoSonido1, disparoSonido2, sonidoPunto;
    private static final float VIRTUAL_WIDTH = 1416;
    private static final float VIRTUAL_HEIGHT = 582;

    private float nivelSuelo = 95;
    private static final float SUELO_Y = 95;

    private Vector2 posJugador1, posJugador2;
    private float velocidadJugador = 300f;

    // Clase Animal sin cambios...
    private class Animal {
        Rectangle bounds;
        float frameTime = 0;
        int currentFrame = 0;
        float velocidad;
        int totalFrames;
        boolean visible = true;

        public Animal(float x, float y, float width, float height, float velocidad, int totalFrames) {
            this.bounds = new Rectangle(x, y, width, height);
            this.velocidad = velocidad;
            this.totalFrames = totalFrames;
        }

        public void update(float delta) {
            // Solo actualizar si el juego no ha terminado
            if (!gameTimeOver) {
                bounds.x -= velocidad * delta;
                frameTime += delta;
                if (frameTime >= 0.1f) {
                    frameTime = 0;
                    currentFrame = (currentFrame + 1) % totalFrames;
                }
                if (bounds.x < -bounds.width) {
                    visible = false;
                }
            }
        }

        public int getFrame() {
            return currentFrame;
        }
    }

    private ArrayList<Animal> aguilas;
    private ArrayList<Animal> caballos;
    private ArrayList<Animal> bueyes;

    private float tiempoDesdeUltimaAguila = 0;
    private float tiempoDesdeUltimoCaballo = 0;
    private float tiempoDesdeUltimobuey = 0;

    private float intervaloAparicionAguila = 4f;
    private float intervaloAparicionCaballo = 6f;
    private float intervaloAparicionBuey = 8f;

    private static final int AGUILA_FRAMES = 2;
    private static final boolean AGUILA_FRAMES_VERTICALES = true;
    private static final int CABALLO_FRAMES = 8;
    private static final int BUEY_FRAMES = 7;

    public GameScreen(WildWestGame game) {
        this.game = game;
        this.batch = game.getBatch();
        this.layout = new GlyphLayout();
    }

    @Override
    public void show() {
        try {
            // Cargar texturas con manejo de errores
            try {
                image = new Texture("fondo.jpg");
                System.out.println("Fondo cargado correctamente");
            } catch (Exception e) {
                System.err.println("Error al cargar fondo.jpg: " + e.getMessage());
            }

            try {
                jugador1 = new Texture("jug1.png");
                jugador2 = new Texture("jug2.png");
                System.out.println("Jugadores cargados correctamente");
            } catch (Exception e) {
                System.err.println("Error al cargar jugadores: " + e.getMessage());
            }

            try {
                aguilaTexture = new Texture("animal1.png");
                caballoTexture = new Texture("animal2.png");
                bueyTexture = new Texture("animal3.png");
                System.out.println("Animales cargados correctamente");
            } catch (Exception e) {
                System.err.println("Error al cargar animales: " + e.getMessage());
            }

            try {
                disparoSonido1 = Gdx.audio.newSound(Gdx.files.internal("disparojug1.mp3"));
                disparoSonido2 = Gdx.audio.newSound(Gdx.files.internal("disparojug2.mp3"));
                sonidoPunto = Gdx.audio.newSound(Gdx.files.internal("ganasteunpunto.mp3"));
                System.out.println("Sonidos cargados correctamente");
            } catch (Exception e) {
                System.err.println("Error al cargar sonidos: " + e.getMessage());
            }

            try {
                hudFondo = new Texture("hudfondo.png");
            } catch (Exception e) {
                System.err.println("No se pudo cargar hudfondo.png: " + e.getMessage());
                // Crear una textura de 1x1 píxel blanco como fallback
                Pixmap pixmap = new Pixmap(1, 1, Pixmap.Format.RGBA8888);
                pixmap.setColor(Color.WHITE);
                pixmap.fill();
                hudFondo = new Texture(pixmap);
                pixmap.dispose();
            }

            try {
                musicadefondopartida = Gdx.audio.newMusic(Gdx.files.internal("musicadefondo.mp3"));
                musicadefondopartida.setLooping(true); // Que suene en bucle

                // Solo reproducir si musicOn está activado
                if (musicOn) {
                    musicadefondopartida.play();
                    System.out.println("Música de fondo cargada y reproduciéndose");
                } else {
                    System.out.println("Música de fondo cargada pero en silencio (OFF)");
                }
            } catch (Exception e) {
                System.err.println("Error al cargar la música de fondo: " + e.getMessage());
            }


            camera = new OrthographicCamera();
            viewport = new FitViewport(VIRTUAL_WIDTH, VIRTUAL_HEIGHT, camera);
            camera.position.set(VIRTUAL_WIDTH / 2f, VIRTUAL_HEIGHT / 2f, 0);
            camera.update();

            // Colocar jugadores al nivel del suelo
            posJugador1 = new Vector2(50, nivelSuelo);
            posJugador2 = new Vector2(60, nivelSuelo);

            // Inicializar las listas de animales
            aguilas = new ArrayList<>();
            caballos = new ArrayList<>();
            bueyes = new ArrayList<>();

            // Inicializar la fuente
            inicializarFuenteEstilizada();

            // Reiniciar marcadores
            puntosJugador1 = 0;
            puntosJugador2 = 0;
            gameTimer = 0;
            gameTimeOver = false;

            System.out.println("GameScreen show() completado correctamente");
        } catch (Exception e) {
            System.err.println("Error general en show(): " + e.getMessage());
            e.printStackTrace();
        }
    }

    // Resto de métodos de generación y animación de animales sin cambios...
    private void generarAguila() {
        // No generar nuevos animales si el juego ha terminado
        if (gameTimeOver) return;

        Random rand = new Random();
        float y = SUELO_Y + rand.nextFloat() * 40 + 10;
        float width = 100;
        float height = 100;

        Animal aguila = new Animal(VIRTUAL_WIDTH, y, width, height, 150f, AGUILA_FRAMES);
        aguilas.add(aguila);
        System.out.println("Águila generada en posición (" + VIRTUAL_WIDTH + ", " + y + ")");
    }

    private void generarCaballo() {
        // No generar nuevos animales si el juego ha terminado
        if (gameTimeOver) return;

        float posicionYCaballo = SUELO_Y - 20;
        Animal caballo = new Animal(VIRTUAL_WIDTH, posicionYCaballo, 150, 100, 100f, CABALLO_FRAMES);
        caballos.add(caballo);
        System.out.println("Caballo generado en posición (" + VIRTUAL_WIDTH + ", " + posicionYCaballo + ")");
    }

    private void generarBuey() {
        // No generar nuevos animales si el juego ha terminado
        if (gameTimeOver) return;

        Animal buey = new Animal(VIRTUAL_WIDTH, SUELO_Y, 150, 100, 80f, BUEY_FRAMES);
        bueyes.add(buey);
        System.out.println("Buey generado en posición (" + VIRTUAL_WIDTH + ", " + SUELO_Y + ")");
    }

    private void dibujarAguilas() {
        if (aguilaTexture != null) {
            int frameWidth, frameHeight;

            if (AGUILA_FRAMES_VERTICALES) {
                frameWidth = aguilaTexture.getWidth();
                frameHeight = aguilaTexture.getHeight() / AGUILA_FRAMES;

                for (Animal aguila : aguilas) {
                    if (aguila.visible) {
                        int frameY = aguila.getFrame() * frameHeight;
                        batch.draw(aguilaTexture,
                            aguila.bounds.x, aguila.bounds.y,
                            aguila.bounds.width, aguila.bounds.height,
                            0, frameY,
                            frameWidth, frameHeight,
                            false, false);
                    }
                }
            } else {
                frameWidth = aguilaTexture.getWidth() / AGUILA_FRAMES;
                frameHeight = aguilaTexture.getHeight();

                for (Animal aguila : aguilas) {
                    if (aguila.visible) {
                        int frameX = aguila.getFrame() * frameWidth;
                        batch.draw(aguilaTexture,
                            aguila.bounds.x, aguila.bounds.y,
                            aguila.bounds.width, aguila.bounds.height,
                            frameX, 0,
                            frameWidth, frameHeight,
                            false, false);
                    }
                }
            }
        }
    }

    private void inicializarFuenteEstilizada() {
        try {
            FreeTypeFontGenerator generator = new FreeTypeFontGenerator(Gdx.files.internal("western_font.ttf"));
            FreeTypeFontParameter parameter = new FreeTypeFontParameter();
            parameter.size = 24;
            parameter.color = new Color(0.9f, 0.8f, 0.2f, 1);
            parameter.borderWidth = 2;
            parameter.borderColor = new Color(0.3f, 0.1f, 0, 1);
            parameter.shadowOffsetX = 2;
            parameter.shadowOffsetY = 2;
            parameter.shadowColor = new Color(0, 0, 0, 0.75f);
            fuenteOeste = generator.generateFont(parameter);
            generator.dispose();
        } catch (Exception e) {
            fuenteOeste = new BitmapFont();
            fuenteOeste.setColor(new Color(0.9f, 0.8f, 0.2f, 1));
            fuenteOeste.getData().setScale(1.5f);
        }
    }

    private void dibujarHUDMejorado() {
        // Dibujar fondos para las puntuaciones (opcional)
        if (hudFondo != null) {
            batch.draw(hudFondo, 10, VIRTUAL_HEIGHT - 50, 200, 40); // Fondo para jugador 1
            batch.draw(hudFondo, VIRTUAL_WIDTH - 210, VIRTUAL_HEIGHT - 50, 200, 40); // Fondo para jugador 2
        }

        // Puntuación del jugador 1 (esquina izquierda)
        String textoJugador1 = "SHERIFF: " + puntosJugador1;
        fuenteOeste.draw(batch, textoJugador1, 20, VIRTUAL_HEIGHT - 20);

        // Puntuación del jugador 2 (esquina derecha)
        String textoJugador2 = "BANDIDO: " + puntosJugador2;
        layout.setText(fuenteOeste, textoJugador2);
        fuenteOeste.draw(batch, textoJugador2, VIRTUAL_WIDTH - layout.width - 20, VIRTUAL_HEIGHT - 20);

        // Mostrar mensaje cuando un jugador alcanza cierta puntuación o gana
        if (mostrarMensaje) {
            layout.setText(fuenteOeste, mensajeGanador);
            float x = (VIRTUAL_WIDTH - layout.width) / 2;
            float y = VIRTUAL_HEIGHT / 2;

            // Dibujar un fondo para el mensaje (opcional)
            batch.setColor(0.3f, 0.1f, 0, 0.7f); // Color marrón semitransparente
            batch.draw(hudFondo, x - 20, y - layout.height - 10, layout.width + 40, layout.height + 20);
            batch.setColor(Color.WHITE); // Restaurar color

            fuenteOeste.draw(batch, mensajeGanador, x, y);
        }

        // Si el tiempo se ha agotado, mostrar un mensaje permanente
        if (gameTimeOver) {
            // Crear un mensaje más destacado para el final del juego
            String mensajeFinal;
            if (puntosJugador1 > puntosJugador2) {
                mensajeFinal = "¡TIEMPO AGOTADO! ¡EL SHERIFF GANA!";
            } else if (puntosJugador2 > puntosJugador1) {
                mensajeFinal = "¡TIEMPO AGOTADO! ¡EL BANDIDO GANA!";
            } else {
                mensajeFinal = "¡TIEMPO AGOTADO! ¡EMPATE!";
            }

            layout.setText(fuenteOeste, mensajeFinal);
            float x = (VIRTUAL_WIDTH - layout.width) / 2;
            float y = VIRTUAL_HEIGHT / 2 + 50;

            // Fondo más grande y destacado para el mensaje final
            batch.setColor(0.3f, 0.1f, 0, 0.8f);
            batch.draw(hudFondo, x - 30, y - layout.height - 20, layout.width + 60, layout.height + 40);
            batch.setColor(Color.WHITE);

            fuenteOeste.draw(batch, mensajeFinal, x, y);

            // Instrucciones para volver al menú
            String volverTexto = "Presiona ESC para volver al menú";
            layout.setText(fuenteOeste, volverTexto);
            float volverX = (VIRTUAL_WIDTH - layout.width) / 2;
            float volverY = y - 40;
            fuenteOeste.draw(batch, volverTexto, volverX, volverY);
        }
    }

    // Método para mostrar un mensaje temporal cuando ocurre algo importante
    public void mostrarMensajeTemporal(String mensaje) {
        mensajeGanador = mensaje;
        mostrarMensaje = true;
        tiempoMensaje = 0;
    }

    @Override
    public void render(float delta) {
        try {
            // Actualizar temporizador de juego solo si no ha terminado
            if (!gameTimeOver) {
                gameTimer += delta;
                if (gameTimer >= gameDuration) {
                    gameTimeOver = true;
                    mostrarMensaje = false; // Asegurarnos de que no se muestren mensajes temporales

                    // Parar la música de fondo
                    if (musicadefondopartida != null && musicadefondopartida.isPlaying()) {
                        musicadefondopartida.stop();
                    }

                    System.out.println("¡Tiempo de juego agotado! La pantalla se ha congelado.");
                }
            }

            // Color de fondo para que coincida con tu escenario del viejo oeste
            ScreenUtils.clear(0.7f, 0.5f, 0.3f, 1f);

            viewport.apply();
            batch.setProjectionMatrix(camera.combined);

            // Solo actualizar la lógica del juego si no ha terminado
            if (!gameTimeOver) {
                // Actualizar temporizadores para la generación de animales
                tiempoDesdeUltimaAguila += delta;
                tiempoDesdeUltimoCaballo += delta;
                tiempoDesdeUltimobuey += delta;

                // Generar nuevos animales si ha pasado suficiente tiempo
                if (tiempoDesdeUltimaAguila >= intervaloAparicionAguila) {
                    generarAguila();
                    tiempoDesdeUltimaAguila = 0;
                }

                if (tiempoDesdeUltimoCaballo >= intervaloAparicionCaballo) {
                    generarCaballo();
                    tiempoDesdeUltimoCaballo = 0;
                }

                if (tiempoDesdeUltimobuey >= intervaloAparicionBuey) {
                    generarBuey();
                    tiempoDesdeUltimobuey = 0;
                }

                // Actualizar la posición y animación de todos los animales
                actualizarAnimales(delta);

                // Mover jugadores solo si el juego no ha terminado
                moverJugadores();

                // Actualizar el tiempo del mensaje
                if (mostrarMensaje) {
                    tiempoMensaje += delta;
                    if (tiempoMensaje > DURACION_MENSAJE) {
                        mostrarMensaje = false;
                    }
                }

                // Comprobar si algún jugador ha ganado (alcanzado cierta puntuación)
                if (puntosJugador1 >= 20) {
                    gameTimeOver = true; // Congelar la pantalla cuando alguien gana
                    // No llamamos a mostrarMensajeTemporal para evitar duplicación
                } else if (puntosJugador2 >= 20) {
                    gameTimeOver = true; // Congelar la pantalla cuando alguien gana
                    // No llamamos a mostrarMensajeTemporal para evitar duplicación
                }
            }

            batch.begin();

            // Dibuja el fondo
            if (image != null) {
                batch.draw(image, 0, 0, VIRTUAL_WIDTH, VIRTUAL_HEIGHT);
            }

            // Dibuja primero los jugadores para que estén detrás de los animales
            if (jugador1 != null && jugador2 != null) {
                batch.draw(jugador1, posJugador1.x, posJugador1.y, 100, 100);
                batch.draw(jugador2, posJugador2.x, posJugador2.y, 100, 100);
            }

            dibujarAguilas();

            // Dibuja caballos con frames de animación
            if (caballoTexture != null) {
                int frameWidth = caballoTexture.getWidth() / CABALLO_FRAMES;
                int frameHeight = caballoTexture.getHeight();

                for (Animal caballo : caballos) {
                    if (caballo.visible) {
                        int frameX = caballo.getFrame() * frameWidth;
                        batch.draw(caballoTexture,
                            caballo.bounds.x, caballo.bounds.y,
                            caballo.bounds.width, caballo.bounds.height,
                            frameX, 0,
                            frameWidth, frameHeight,
                            false, false);
                    }
                }
            }

            // Dibuja bueyes con frames de animación
            if (bueyTexture != null) {
                int frameWidth = bueyTexture.getWidth() / BUEY_FRAMES;
                int frameHeight = bueyTexture.getHeight();

                for (Animal buey : bueyes) {
                    if (buey.visible) {
                        int frameX = buey.getFrame() * frameWidth;
                        batch.draw(bueyTexture,
                            buey.bounds.x, buey.bounds.y,
                            buey.bounds.width, buey.bounds.height,
                            frameX, 0,
                            frameWidth, frameHeight,
                            false, false);
                    }
                }
            }

            // Dibujar HUD
            dibujarHUDMejorado();

            // Dibujar temporizador
            if (!gameTimeOver) {
                int remainingSeconds = (int)(gameDuration - gameTimer);
                int minutes = remainingSeconds / 60;
                int seconds = remainingSeconds % 60;
                String timeStr = String.format("%02d:%02d", minutes, seconds);

                // Usar tu fuente existente
                fuenteOeste.draw(batch, "TIEMPO: " + timeStr, VIRTUAL_WIDTH/2 - 100, VIRTUAL_HEIGHT - 20);
            } else {
                // Mostrar tiempo agotado
                fuenteOeste.draw(batch, "TIEMPO: 00:00", VIRTUAL_WIDTH/2 - 100, VIRTUAL_HEIGHT - 20);
            }

            batch.end();

            // Limpiar los animales que ya no son visibles (salieron de la pantalla)
            limpiarAnimales();

            // Permitir volver al menú principal con la tecla Escape
            if (Gdx.input.isKeyJustPressed(Input.Keys.ESCAPE)) {
                game.setScreen(new MenuScreen(game));
                dispose();
            }

        } catch (Exception e) {
            System.err.println("Error en render(): " + e.getMessage());
            e.printStackTrace();
        }
    }

    private void actualizarAnimales(float delta) {
        // No actualizar animales si el juego ha terminado
        if (gameTimeOver) return;

        // Actualizar todas las águilas
        for (Animal aguila : aguilas) {
            aguila.update(delta);
        }

        // Actualizar todos los caballos
        for (Animal caballo : caballos) {
            caballo.update(delta);
        }

        // Actualizar todos los bueyes
        for (Animal buey : bueyes) {
            buey.update(delta);
        }
    }

    private void limpiarAnimales() {
        // Eliminar animales que ya no son visibles
        Iterator<Animal> iter = aguilas.iterator();
        while (iter.hasNext()) {
            Animal animal = iter.next();
            if (!animal.visible) {
                iter.remove();
            }
        }

        iter = caballos.iterator();
        while (iter.hasNext()) {
            Animal animal = iter.next();
            if (!animal.visible) {
                iter.remove();
            }
        }

        iter = bueyes.iterator();
        while (iter.hasNext()) {
            Animal animal = iter.next();
            if (!animal.visible) {
                iter.remove();
            }
        }
    }

    private void moverJugadores() {
        // No permitir movimiento si el juego ha terminado
        if (gameTimeOver) return;

        float delta = Gdx.graphics.getDeltaTime();

        // Movimiento horizontal jugador 1
        if (Gdx.input.isKeyPressed(Input.Keys.A)) {
            posJugador1.x -= velocidadJugador * delta;
        }
        if (Gdx.input.isKeyPressed(Input.Keys.D)) {
            posJugador1.x += velocidadJugador * delta;
        }

        // Movimiento horizontal jugador 2
        if (Gdx.input.isKeyPressed(Input.Keys.LEFT)) {
            posJugador2.x -= velocidadJugador * delta;
        }
        if (Gdx.input.isKeyPressed(Input.Keys.RIGHT)) {
            posJugador2.x += velocidadJugador * delta;
        }

        // Límites de pantalla para jugador 1
        if (posJugador1.x < 0) posJugador1.x = 0;
        if (posJugador1.x > VIRTUAL_WIDTH - 100) posJugador1.x = VIRTUAL_WIDTH - 100;

        // Límites de pantalla para jugador 2
        if (posJugador2.x < 0) posJugador2.x = 0;
        if (posJugador2.x > VIRTUAL_WIDTH - 100) posJugador2.x = VIRTUAL_WIDTH - 100;

        // Disparos
        if (Gdx.input.isKeyJustPressed(Input.Keys.W)) {
            if (disparoSonido1 != null && sfxOn) {
                disparoSonido1.play();
            }
            verificarImpacto(posJugador1, true);
        }
        if (Gdx.input.isKeyJustPressed(Input.Keys.UP)) {
            if (disparoSonido2 != null && sfxOn) {
                disparoSonido2.play();
            }
            verificarImpacto(posJugador2, false);
        }
    }

    private void verificarImpacto(Vector2 posJugador, boolean esJugador1) {
        // No verificar impactos si el juego ha terminado
        if (gameTimeOver) return;

        Rectangle jugadorRect = new Rectangle(posJugador.x, posJugador.y, 100, 100);

        // Verificar impacto con águilas
        Iterator<Animal> iter = aguilas.iterator();
        while (iter.hasNext()) {
            Animal animal = iter.next();
            if (animal.visible && animal.bounds.overlaps(jugadorRect)) {
                iter.remove();
                if (sonidoPunto != null && sfxOn) {
                    sonidoPunto.play();
                }
                // Incrementar puntos según jugador
                if (esJugador1) {
                    puntosJugador1 += 3; // Águilas valen 3 puntos
                } else {
                    puntosJugador2 += 3;
                }
            }
        }



        // Verificar impacto con caballos
        iter = caballos.iterator();
        while (iter.hasNext()) {
            Animal animal = iter.next();
            if (animal.visible && animal.bounds.overlaps(jugadorRect)) {
                iter.remove();
                if (sonidoPunto != null && sfxOn) {
                    sonidoPunto.play();
                }
                // Incrementar puntos según jugador
                if (esJugador1) {
                    puntosJugador1 += 2; // Caballos valen 2 puntos
                } else {
                    puntosJugador2 += 2;
                }
            }
        }

        // Verificar impacto con bueyes
        iter = bueyes.iterator();
        while (iter.hasNext()) {
            Animal animal = iter.next();
            if (animal.visible && animal.bounds.overlaps(jugadorRect)) {
                iter.remove();
                if (sonidoPunto != null && sfxOn) {
                    sonidoPunto.play();
                }
                // Incrementar puntos según jugador
                if (esJugador1) {
                    puntosJugador1 += 1; // Bueyes valen 1 punto
                } else {
                    puntosJugador2 += 1;
                }
            }
        }
    }

    @Override
    public void resize(int width, int height) {
        viewport.update(width, height, true);
        camera.update();
        System.out.println("Ventana redimensionada: " + width + " x " + height);
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

    private boolean musicOn = true;
    private boolean sfxOn = true;
    @Override
    public void dispose() {
        try {
            if (image != null) image.dispose();
            if (jugador1 != null) jugador1.dispose();
            if (jugador2 != null) jugador2.dispose();
            if (disparoSonido1 != null) disparoSonido1.dispose();
            if (disparoSonido2 != null) disparoSonido2.dispose();
            if (sonidoPunto != null) sonidoPunto.dispose();
            if (aguilaTexture != null) aguilaTexture.dispose();
            if (caballoTexture != null) caballoTexture.dispose();
            if (bueyTexture != null) bueyTexture.dispose();
            if (fuenteOeste != null) fuenteOeste.dispose();
            if (hudFondo != null) hudFondo.dispose();
            if (musicadefondopartida != null) {
                musicadefondopartida.dispose();
            }
            System.out.println("Recursos de GameScreen liberados correctamente");
        } catch (Exception e) {
            System.err.println("Error en dispose(): " + e.getMessage());
        }
    }
    public void setMusicOn(boolean musicOn) {
        this.musicOn = musicOn;
        // Aplicar el cambio inmediatamente
        if (musicadefondopartida != null) {
            if (musicOn) {
                if (!musicadefondopartida.isPlaying()) {
                    musicadefondopartida.play();
                }
            } else {
                if (musicadefondopartida.isPlaying()) {
                    musicadefondopartida.stop();
                }
            }
        }
    }

    public void setSfxOn(boolean sfxOn) {
        this.sfxOn = sfxOn;
    }

    // Método para configurar la duración del juego en minutos
    public void setGameDuration(float minutes) {
        this.gameDuration = minutes * 60; // Convertir a segundos
        this.gameTimer = 0;
        this.gameTimeOver = false;
    }
}
