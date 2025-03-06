package io.github.some_example_name;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.utils.ScreenUtils;

/** {@link com.badlogic.gdx.ApplicationListener} implementation shared by all platforms. */
public class Main extends ApplicationAdapter {
    private SpriteBatch batch;
    private Texture textureIdle;
    private Texture textureMoving;
    private float x, y;
    private Boolean isMoving;

    @Override
    public void create() {
        batch = new SpriteBatch();
        textureIdle = new Texture(Gdx.files.internal("Mario1.png"));
        textureMoving = new Texture(Gdx.files.internal("Mario2.png"));
        x = 50;
        y = 50;
        isMoving = true;
    }

    @Override
    public void render() {
        isMoving = false;
        ScreenUtils.clear(0.15f, 0.15f, 0.2f, 1f);
        handleInput();
        batch.begin();
        if(isMoving){
            batch.draw(textureMoving, x, y, textureMoving.getWidth() /3, textureMoving.getHeight() /3);
        } else {
            batch.draw(textureIdle, x, y, textureIdle.getWidth() / 2, textureIdle.getHeight() /2);
        }
        batch.end();
    }

    private void handleInput(){
        // Movemos el personaje con las teclas
        if(Gdx.input.isKeyPressed(Input.Keys.RIGHT)){ // Se puede usar A y D
            x += 200 * Gdx.graphics.getDeltaTime();
            isMoving = true;
        }
        if(Gdx.input.isKeyPressed(Input.Keys.LEFT)){// Se puede usar A y D
            x -= 200 * Gdx.graphics.getDeltaTime();
            isMoving = true;
        }
        if(Gdx.input.isKeyPressed(Input.Keys.UP)){// Se puede usar A y D
            y += 200 * Gdx.graphics.getDeltaTime();
            isMoving = true;
        }
        if(Gdx.input.isKeyPressed(Input.Keys.DOWN)){// Se puede usar A y D
            y -= 200 * Gdx.graphics.getDeltaTime();
            isMoving = true;
        }
    }



    @Override
    public void dispose() {
        batch.dispose();    }
}
