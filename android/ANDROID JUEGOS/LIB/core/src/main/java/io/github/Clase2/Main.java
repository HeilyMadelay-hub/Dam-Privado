package io.github.Clase2;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.Rectangle;
import com.badlogic.gdx.utils.ScreenUtils;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.g2d.BitmapFont;
public class Main extends ApplicationAdapter {
    private SpriteBatch batch;
    private Texture image;
    private Texture barra1;
    private Texture barra2;
    private Texture bola;
    private float x1, x2;
    private float xb, yb;
    private Rectangle barra1_rect;
    private Rectangle barra2_rect;
    private Rectangle bola_cir;
    private int score1, score2;
    private BitmapFont font;
    private boolean gameOver;
    private float velocidadX, velocidadY;

    @Override
    public void create() {
        batch = new SpriteBatch();
        image = new Texture("background.jpg");
        barra1 = new Texture("barra.png");
        barra2 = new Texture("barra.png");
        bola = new Texture("bola_game.png");
        xb = Gdx.graphics.getWidth() / 2f;
        yb = Gdx.graphics.getHeight() / 2f;
        x1 = Gdx.graphics.getWidth() / 2f - barra1.getWidth() / 4f;
        x2 = Gdx.graphics.getWidth() / 2f - barra1.getWidth() / 4f;
        barra1_rect = new Rectangle(x1, 15, barra1.getWidth() / 2f, barra1.getHeight() / 2f);
        barra2_rect = new Rectangle(x2, Gdx.graphics.getHeight() - 80f, barra1.getWidth() / 2f, barra1.getHeight() / 2f);
        bola_cir = new Rectangle(xb, yb, bola.getWidth() / 6f, bola.getHeight() / 6f);
        score1 = 0;
        score2 = 0;
        font = new BitmapFont();
        gameOver = false;
        // Inicializar las velocidades de la bola
        velocidadX = 200f; // Velocidad horizontal
        velocidadY = 200f; // Velocidad vertical
    }

    @Override
    public void render() {
        ScreenUtils.clear(0.15f, 0.15f, 0.2f, 1f);
        handle_input();
        if (!gameOver) {
            trayectoria_bola();
            isGameOver();
        }

        barra1_rect.setPosition(x1, 15);
        barra2_rect.setPosition(x2, Gdx.graphics.getHeight() - 80f);
        batch.begin();

        batch.draw(image, 0, 0);
        batch.draw(barra1, x1, 15, barra1.getWidth() / 2f, barra1.getHeight() / 2f);
        batch.draw(barra2, x2, Gdx.graphics.getHeight() - 80f, barra1.getWidth() / 2f, barra1.getHeight() / 2f);
        batch.draw(bola, xb, yb, bola.getWidth() / 6f, bola.getHeight() / 6f);
        // Draw scores
        font.setColor(Color.WHITE);
        font.draw(batch, "Player 1: " + score1, 50, Gdx.graphics.getHeight() - 20);
        font.draw(batch, "Player 2: " + score2, Gdx.graphics.getWidth() - 150, Gdx.graphics.getHeight() - 20);

        // Display Game Over message
        if (gameOver) {
            font.getData().setScale(2);
            font.draw(batch, "GAME OVER!", Gdx.graphics.getWidth() / 2f - 100, Gdx.graphics.getHeight() / 2f);
        }

        batch.end();
    }

    public void handle_input() {
        if (Gdx.input.isKeyPressed(Input.Keys.LEFT) && x1 > 0) {
            x1 = x1 - Gdx.graphics.getDeltaTime() * 300;
        } else if (Gdx.input.isKeyPressed(Input.Keys.RIGHT) && x1 < Gdx.graphics.getWidth() - 150) {
            x1 = x1 + Gdx.graphics.getDeltaTime() * 300;
        }
        if (Gdx.input.isKeyPressed(Input.Keys.A) && x2 > 0) {
            x2 = x2 - Gdx.graphics.getDeltaTime() * 300;
        } else if (Gdx.input.isKeyPressed(Input.Keys.D) && x2 < Gdx.graphics.getWidth() - 150) {
            x2 = x2 + Gdx.graphics.getDeltaTime() * 300;
        }
    }

    public void trayectoria_bola() {
        // Mover la bola en la dirección actual
        xb += velocidadX * Gdx.graphics.getDeltaTime();
        yb += velocidadY * Gdx.graphics.getDeltaTime();

        // Rebotar con la primera barra (jugador 1)
        if (bola_cir.overlaps(barra1_rect)) {
            velocidadY = Math.abs(velocidadY); // Rebotar hacia abajo
            score1++;
        }

        // Rebotar con la segunda barra (jugador 2)
        if (bola_cir.overlaps(barra2_rect)) {
            velocidadY = -Math.abs(velocidadY); // Rebotar hacia arriba
            score2++;
        }

        // Rebotar con los bordes laterales (izquierdo y derecho)
        if (xb < 0 || xb > Gdx.graphics.getWidth() - bola_cir.width) {
            velocidadX = -velocidadX; // Invertir la dirección de la bola en X
        }

        bola_cir.setPosition(xb, yb);
    }

    public void isGameOver() {
        if (yb < 0) { // Player 1 loses
            score2++;
            gameOver = true;
        } else if (yb > Gdx.graphics.getHeight()) { // Player 2 loses
            score1++;
            gameOver = true;
        }
    }

    @Override
    public void dispose() {
        batch.dispose();
        image.dispose();
    }
}
