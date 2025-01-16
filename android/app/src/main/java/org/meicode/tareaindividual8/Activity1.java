package org.meicode.tareaindividual8;

import static org.meicode.tareaindividual8.R.*;

import androidx.appcompat.app.AppCompatActivity;

import android.media.MediaPlayer;
import android.net.Uri;
import android.os.Bundle;
import android.widget.Button;
import android.view.View;

public class Activity1 extends AppCompatActivity {

    private MediaPlayer mediaPlayer;
    private String url = "https://www.learningcontainer.com/wp-content/uploads/2020/02/Kalimba.mp3";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity1);

        Button playbut = findViewById(R.id.button_play);
        Button stopbut = findViewById(R.id.button_stop);

        initializeMediaPlayer();

        playbut.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (!mediaPlayer.isPlaying()) {
                    mediaPlayer.start();
                }
            }
        });

        stopbut.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (mediaPlayer.isPlaying()) {
                    mediaPlayer.stop();
                    initializeMediaPlayer(); // Reinicializa el MediaPlayer después de detenerlo
                }
            }
        });
    }

    private void initializeMediaPlayer() {
        Uri parseurl = Uri.parse(url);
        mediaPlayer = MediaPlayer.create(this, parseurl);
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        if (mediaPlayer != null) {
            mediaPlayer.release(); // Libera los recursos del MediaPlayer cuando la actividad se destruye
        }
    }
}
