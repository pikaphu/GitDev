package pedo.vr.exzy.testacc1;

import android.app.Activity;
import android.app.Dialog;
import android.content.Context;
import android.content.Intent;
import android.hardware.Sensor;
import android.hardware.SensorEvent;
import android.hardware.SensorManager;
import android.hardware.SensorEventListener;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.KeyEvent;
import android.view.View;
import android.view.inputmethod.EditorInfo;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;


public class MainActivity  extends Activity implements SensorEventListener {

    private SensorManager senSensorManager;
    private Sensor senAccelerometer;

    private EditText ed_shake_threshold;

    /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // sensor
        senSensorManager = (SensorManager) getSystemService(Context.SENSOR_SERVICE);
        senAccelerometer = senSensorManager.getDefaultSensor(Sensor.TYPE_ACCELEROMETER);
        senSensorManager.registerListener( this, senAccelerometer , SensorManager.SENSOR_DELAY_NORMAL);

        // event listener
        // change Threshold
        // SHAKE_THRESHOLD = Integer.parseInt ( ((EditText)findViewById(R.id.edTh)).getText().toString() );
        ed_shake_threshold = (EditText) findViewById(R.id.edTh);
        ed_shake_threshold.setText( String.valueOf(SHAKE_THRESHOLD) );

        ed_shake_threshold.addTextChangedListener(new TextWatcher() {

            public void afterTextChanged(Editable s) {
                //SHAKE_THRESHOLD = Integer.parseInt(s.toString());
            }

            public void beforeTextChanged(CharSequence s, int start, int count, int after) {}

            public void onTextChanged(CharSequence s, int start, int before, int count) {}
        });

        // on done
        ed_shake_threshold.setOnEditorActionListener(new TextView.OnEditorActionListener() {
            @Override
            public boolean onEditorAction(TextView v, int actionId, KeyEvent event) {
                boolean handled = false;
                if (actionId == EditorInfo.IME_ACTION_DONE || actionId == EditorInfo.IME_ACTION_SEND) {

                    SHAKE_THRESHOLD = Integer.parseInt( ed_shake_threshold.getText().toString() );
                    handled = false;
                }else if (actionId == EditorInfo.IME_FLAG_NO_ENTER_ACTION) {
                    handled = true;
                }

                isFocus = !handled;
                return handled;
            }
        });

        // on focus
        ed_shake_threshold.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            public void onFocusChange(View v, boolean hasFocus) {
                isFocus = !hasFocus;
            }
        });

    }


    // Acc detecting
    private long lastUpdate = 0;
    private float last_x, last_y, last_z;
    private int SHAKE_THRESHOLD = 400; // final static
    private boolean isFocus = true;
    @Override
    public void onSensorChanged(SensorEvent sensorEvent) {
        Sensor mySensor = sensorEvent.sensor;

        if (!isFocus) return;

        if (mySensor.getType() == Sensor.TYPE_ACCELEROMETER) {
            float x = sensorEvent.values[0];
            float y = sensorEvent.values[1];
            float z = sensorEvent.values[2];

            long curTime = System.currentTimeMillis();

            if ((curTime - lastUpdate) > 100) {
                long diffTime = (curTime - lastUpdate);
                lastUpdate = curTime;

                float speed = Math.abs(x + y + z - last_x - last_y - last_z)/ diffTime * 10000;

                // debug
                EditText edSpd= (EditText)findViewById(R.id.editText4);
                edSpd.setText(float2Str(speed));
                Log.i("info", "Test: " + float2Str(speed) );

                if (speed > SHAKE_THRESHOLD) {
                    Log.d("debug", "Detected!");
                    // getApplicationContext(), +  String.valueOf(x) + ":" +  String.valueOf(y) + ":" +  String.valueOf(z)
                    Toast.makeText(this,
                            "Shake Detected! ",
                            Toast.LENGTH_SHORT).show();
                }

                last_x = x;
                last_y = y;
                last_z = z;

                // show
                EditText edX= (EditText)findViewById(R.id.editText1);
                EditText edY= (EditText)findViewById(R.id.editText2);
                EditText edZ= (EditText)findViewById(R.id.editText3);
                edX.setText( float2Str(last_x));
                edY.setText( float2Str(last_y));
                edZ.setText( float2Str(last_z));
            }
        }
    }

    /** Called when the user clicks the Send button */
    public void sendMessage(View view) {
        Intent intent = new Intent(this, AccActivity.class);
        startActivity(intent);

        // Dialog for action
        final Dialog dialog = new Dialog(MainActivity.this);
        dialog.setContentView(R.layout.activity_acc);
        dialog.setTitle("AccActivity");
        dialog.setCancelable(true);
    }

    String float2Str(float f)
    {
        // f.toString();
        // String.valueOf();
        return String.format("%.2f", f);
    }

    @Override
    public void onAccuracyChanged(Sensor sensor, int accuracy) {

    }

    protected void onPause() {
        super.onPause();
        senSensorManager.unregisterListener(this);
    }

    protected void onResume() {
        super.onResume();
        senSensorManager.registerListener(this, senAccelerometer, SensorManager.SENSOR_DELAY_NORMAL);
    }
}
