package org.meicode.tareaindividual8;
import static org.meicode.tareaindividual8.R.*;

import androidx.appcompat.app.AppCompatActivity;

import android.net.Uri;
import android.os.Bundle;
import android.widget.Button;
import android.view.View;
import android.widget.MediaController;
import android.widget.VideoView;

public class Activity2 extends AppCompatActivity {

    private MediaController mediaController;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity2);

        String url="android.resource://"+getPackageName()+"/"+R.raw.sample_video;

        Uri urlparse=Uri.parse(url);

        VideoView videoView=findViewById(R.id.VideoView);

        mediaController=new MediaController(this);
        mediaController.setAnchorView(videoView);
        videoView.setMediaController(mediaController);

        videoView.setVideoURI(urlparse);

        videoView.start();


    }
}