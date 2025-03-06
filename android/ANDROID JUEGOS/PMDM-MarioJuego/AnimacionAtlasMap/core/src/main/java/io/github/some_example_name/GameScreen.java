package io.github.some_example_name;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input;
import com.badlogic.gdx.graphics.g2d.Animation;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.graphics.g2d.TextureAtlas;
import com.badlogic.gdx.graphics.g2d.TextureRegion;
import com.badlogic.gdx.utils.Array;
import com.badlogic.gdx.utils.ScreenUtils;

/** {@link com.badlogic.gdx.ApplicationListener} implementation shared by all platforms. */
public class GameScreen extends ApplicationAdapter {
    private SpriteBatch batch;
    private TextureAtlas atlas;
    private float stateTime;
    private Animation <TextureRegion> bigMarioAnimation;
    private float x, y;
    private Boolean isMoving;
    private TextureRegion MarioStop;

    @Override
    public void create() {
        batch = new SpriteBatch();
        atlas = new TextureAtlas(Gdx.files.internal("Mario_and_Enemies.pack"));
        TextureAtlas.AtlasRegion bigMarioRegion = atlas.findRegion("big_mario");
        int count = bigMarioRegion.getRegionWidth() / 16;
        Array<TextureRegion> allFrames = new Array<>();
        System.out.println(count);
        MarioStop = new TextureRegion(bigMarioRegion, 0, 0, 16, bigMarioRegion.getRegionHeight());
        for (int i = 0; i < 3; i++){
            allFrames.add(new TextureRegion(bigMarioRegion, i * 16, 0, 16, bigMarioRegion.getRegionHeight()));
        }
        bigMarioAnimation = new Animation<>(0.4f, allFrames);
        x = 50;
        y = 50;
        isMoving = true;
    }

    @Override
    public void render() {
        ScreenUtils.clear(0.15f, 0.15f, 0.2f, 1f);
        handleInput();
        batch.begin();
        stateTime += Gdx.graphics.getDeltaTime();
        TextureRegion currentFrame = bigMarioAnimation.getKeyFrame(stateTime, true);
        if(isMoving){
            batch.draw(currentFrame, x, y, currentFrame.getRegionWidth()*3, currentFrame.getRegionHeight()*3);
        }else {
            batch.draw(MarioStop, x, y, MarioStop.getRegionWidth()*3, MarioStop.getRegionHeight()*3);
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
        batch.dispose();
    }
}
