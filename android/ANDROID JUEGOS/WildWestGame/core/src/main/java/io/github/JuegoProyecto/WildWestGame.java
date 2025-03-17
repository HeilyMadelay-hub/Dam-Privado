package io.github.JuegoProyecto;

import com.badlogic.gdx.Game;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;


/*
*
*La clase WildWestGame es la clase principal de tu juego que extiende
*la clase Game de LibGDX. Esta clase actúa como el punto de entrada y
*controlador principal de tu aplicación
*
* */
public class WildWestGame extends Game {
    private SpriteBatch batch;

    @Override
    public void create() {
        batch = new SpriteBatch();

        this.setScreen(new MenuScreen(this));
    }

    @Override
    public void render() {
        super.render();
    }

    @Override
    public void dispose() {
        batch.dispose();
        if (this.getScreen() != null) {
            this.getScreen().dispose();
        }
    }

    public SpriteBatch getBatch() {
        return batch;
    }
}
