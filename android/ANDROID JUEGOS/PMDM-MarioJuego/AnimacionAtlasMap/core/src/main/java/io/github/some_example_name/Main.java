package io.github.some_example_name;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.Rectangle;


/** {@link com.badlogic.gdx.ApplicationListener} implementation shared by all platforms. */
public class Main extends ApplicationAdapter {
    private SpriteBatch batch;
    private Texture button_settings;
    private Texture button_exit;
    private Texture button_start;
    private Texture background;
    private float centerx;
    private float centery;
    private Rectangle b_exit_r, b_start_r, b_settings_r;

    @Override
    public void create() {
        batch = new SpriteBatch();
        background = new Texture("background.jpg");
        button_settings = new Texture("button_settings.png");
        button_exit = new Texture("button_exit.png");
        button_start = new Texture("button_start.png");
        centerx = Gdx.graphics.getWidth()/2 - button_start.getWidth()/2;
        centery = Gdx.graphics.getHeight()/2;
        b_start_r = new Rectangle(centerx, centery, button_start.getWidth(), button_start.getHeight());
        b_settings_r = new Rectangle(centerx, centery - button_start.getHeight(), button_settings.getWidth(), button_settings.getHeight());
        b_exit_r = new Rectangle(centerx + 15, centery - (button_start.getHeight() * 2), button_exit.getWidth(), button_exit.getHeight());
    }

    @Override
    public void render() {

        if(Gdx.input.justTouched()){
            float x_in = Gdx.input.getX();
            float y_in = Gdx.input.getY();
            y_in = Gdx.graphics.getHeight() - y_in;

            if(b_start_r.contains(x_in, y_in)){
                System.out.println("Empieza el juego");
            } else if (b_settings_r.contains(x_in, y_in)) {
                System.out.println("Congiguración");
            } else if (b_exit_r.contains(x_in, y_in)) {
                System.out.println("Salir");
            }
        }

        batch.begin();
        batch.draw(background, 0, 0);;
        batch.draw(button_start, centerx, centery);
        batch.draw(button_settings, centerx, centery - button_start.getHeight());
        batch.draw(button_exit, centerx + 15, centery - (button_start.getHeight() * 2));
        batch.end();
    }

    @Override
    public void dispose() {
        batch.dispose();
        background.dispose();
        button_start.dispose();
        button_settings.dispose();
        button_exit.dispose();
    }
}
