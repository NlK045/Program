package com.example.cross_zero;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

public class mainClass extends Activity {
    Button button0;
    Button button1;
    Button button2;
    Button button3;
    Button button4;
    Button button5;
    Button button6;
    Button button7;
    Button button8;

    Button[] buttonArray = new Button[9];

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main_layout);
        button0 = findViewById(R.id.button0);
        button1 = findViewById(R.id.button1);
        button2 = findViewById(R.id.button2);
        button3 = findViewById(R.id.button3);
        button4 = findViewById(R.id.button4);
        button5 = findViewById(R.id.button5);
        button6 = findViewById(R.id.button6);
        button7 = findViewById(R.id.button7);
        button8 = findViewById(R.id.button8);

        buttonArray[0] = button0;
        buttonArray[1] = button1;
        buttonArray[2] = button2;
        buttonArray[3] = button3;
        buttonArray[4] = button4;
        buttonArray[5] = button5;
        buttonArray[6] = button6;
        buttonArray[7] = button7;
        buttonArray[8] = button8;
    }
    int[] arrayCheck = new int[9];
    int j = 0;
    public void Check(int[] arrayCheck){
        boolean winner = false;
        int winnerPoint = 0;
        if (arrayCheck[0] == arrayCheck[1] && arrayCheck[1] == arrayCheck[2]){ winner = true; winnerPoint = arrayCheck[0]; } else
        if (arrayCheck[3] == arrayCheck[4] && arrayCheck[4] == arrayCheck[5]){ winner = true; winnerPoint = arrayCheck[3]; } else
        if (arrayCheck[6] == arrayCheck[7] && arrayCheck[7] == arrayCheck[8]){ winner = true; winnerPoint = arrayCheck[6]; } else
        if (arrayCheck[0] == arrayCheck[3] && arrayCheck[3] == arrayCheck[6]){ winner = true; winnerPoint = arrayCheck[0]; } else
        if (arrayCheck[1] == arrayCheck[4] && arrayCheck[4] == arrayCheck[7]){ winner = true; winnerPoint = arrayCheck[1]; } else
        if (arrayCheck[2] == arrayCheck[5] && arrayCheck[5] == arrayCheck[8]){ winner = true; winnerPoint = arrayCheck[2]; } else
        if (arrayCheck[0] == arrayCheck[4] && arrayCheck[4] == arrayCheck[8]){ winner = true; winnerPoint = arrayCheck[0]; } else
        if (arrayCheck[2] == arrayCheck[4] && arrayCheck[4] == arrayCheck[6]){ winner = true; winnerPoint = arrayCheck[2]; }
        if (winnerPoint == 0) { winner = false; }
        if (winnerPoint == 0 && j == 9) {
            Toast.makeText(this, "Ничья, удачи очередняра", Toast.LENGTH_SHORT).show();
            Refresh();
        }
        if (winner) {
            if (winnerPoint == 1)
                Toast.makeText(this, "Побеждает игрок за крестики", Toast.LENGTH_SHORT).show();
            else Toast.makeText(this, "Побеждает игрок за нолики", Toast.LENGTH_SHORT).show();
            Refresh();
        }
    }
    public void Refresh()
    {
        for(int i = 0; i < 9; i++){
            arrayCheck[i] = 0;
            buttonArray[i].setText("");
        }
        j = 0;
    }
    boolean check = true;
    public void OnClick(View button) {
        TextView textView = findViewById(R.id.textView);
        Button but = (Button) button;
        int tag = Integer.valueOf( but.getTag().toString());
        String text = but.getText().toString();
        if (text.equalsIgnoreCase(""))
        if (check)
        {
            but.setText("X");
            check = false;
            arrayCheck[tag] = 1;
            j++;
            textView.setText(String.valueOf(j));

        } else
        {
            but.setText("O");
            check = true;
            arrayCheck[tag] = 2;
            j++;
            textView.setText(String.valueOf(j));
        }
        Check(arrayCheck);
    }
}
