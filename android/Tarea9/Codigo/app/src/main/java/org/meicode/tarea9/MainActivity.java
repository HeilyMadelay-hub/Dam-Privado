package org.meicode.tarea9;

import android.media.MediaPlayer;
import android.media.SoundPool;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.VideoView;
import androidx.appcompat.app.AppCompatActivity;

public class MainActivity extends AppCompatActivity {

    private MediaPlayer mediaPlayer;
    private SoundPool soundPool;
    private int soundId;
    private boolean isAudioPlaying = false;
    private boolean isVideoPlaying = false;
    private boolean isGifVisible = false;
    private int animation; // Variable para el recurso del GIF

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // Inicializar componentes
        Button btnAudio = findViewById(R.id.btnAudio);
        Button btnVideo = findViewById(R.id.btnVideo);
        Button btnSoundEffect = findViewById(R.id.btnSoundEffect);
        Button btnGif = findViewById(R.id.btnGif);
        VideoView videoView = findViewById(R.id.videoView);
        ImageView gifImageView = findViewById(R.id.gifImageView);

        // Asignar el recurso del GIF a la variable animation
        animation = R.drawable.animation;

        // Inicializar MediaPlayer para audio
        mediaPlayer = MediaPlayer.create(this, R.raw.audio);

        // Inicializar SoundPool para efecto de sonido
        soundPool = new SoundPool.Builder().setMaxStreams(1).build();
        soundId = soundPool.load(this, R.raw.sound_effect, 1);

        // Reproducir/Pausar Audio
        btnAudio.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (isAudioPlaying) {
                    mediaPlayer.pause();
                    btnAudio.setText("Reproducir Audio");
                } else {
                    mediaPlayer.start();
                    btnAudio.setText("Pausar Audio");
                }
                isAudioPlaying = !isAudioPlaying;
            }
        });

        // Reproducir/Pausar Video
        btnVideo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (isVideoPlaying) {
                    videoView.pause();
                    btnVideo.setText("Reproducir Video");
                } else {
                    Uri videoUri = Uri.parse("android.resource://" + getPackageName() + "/" + R.raw.video);
                    videoView.setVideoURI(videoUri);
                    videoView.start();
                    btnVideo.setText("Pausar Video");
                }
                isVideoPlaying = !isVideoPlaying;
            }
        });

        // Reproducir Efecto de Sonido
        btnSoundEffect.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                soundPool.play(soundId, 1f, 1f, 0, 0, 1f);
            }
        });

        // Mostrar/Ocultar GIF
        btnGif.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (isGifVisible) {
                    gifImageView.setVisibility(View.GONE);
                    btnGif.setText("Mostrar GIF");
                } else {
                    gifImageView.setImageResource(animation); // Usar la variable animation
                    gifImageView.setVisibility(View.VISIBLE);
                    btnGif.setText("Ocultar GIF");
                }
                isGifVisible = !isGifVisible;
            }
        });
    }

    // Liberar recursos al cerrar la actividad
    @Override
    protected void onDestroy() {
        super.onDestroy();
        if (mediaPlayer != null) {
            mediaPlayer.release();
        }
        if (soundPool != null) {
            soundPool.release();
        }
    }
}