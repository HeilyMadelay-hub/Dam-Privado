package org.meicode.tareaindividual8;

import android.content.Intent;
import android.os.Bundle;
import android.view.View; // Import necesario para OnClickListener
import android.widget.Button;

import androidx.appcompat.app.AppCompatActivity;

public class MainActivity extends AppCompatActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Button buttonActivity1 = findViewById(R.id.buttonActivity1);
        Button buttonActivity2 = findViewById(R.id.buttonActivity2);

        // Intent para el primer botón
        buttonActivity1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // Intent para iniciar la Actividad 1
                Intent intent1 = new Intent(MainActivity.this, Activity1.class);
                startActivity(intent1);
            }
        });

        // Intent para el segundo botón
        buttonActivity2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // Intent para iniciar la Actividad 2
                Intent intent2 = new Intent(MainActivity.this, Activity2.class);
                startActivity(intent2);
            }
        });
    }
}
