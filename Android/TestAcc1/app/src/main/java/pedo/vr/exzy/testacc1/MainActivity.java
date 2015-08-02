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

import org.w3c.dom.Text;


public class MainActivity  extends Activity implements SensorEventListener {

    private SensorManager senSensorManager;
    private Sensor senAccelerometer;

    private EditText ed_shake_threshold;
    private TextView tv_step_count;
    private Integer step_count = 0;

    /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // init step count
        tv_step_count = (TextView) findViewById(R.id.textViewStepCount);
        ResetStepCount(null);

        // sensor
        senSensorManager = (SensorManager) getSystemService(Context.SENSOR_SERVICE);
        senAccelerometer = senSensorManager.getDefaultSensor(Sensor.TYPE_ACCELEROMETER);
        senSensorManager.registerListener( this, senAccelerometer , SensorManager.SENSOR_DELAY_NORMAL);

        // calculation method
        methodSelected(null);

        // event listener
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
            float x = sensorEvent.values[0]; // when using landscape just focus on X-axis (vertical)
            float y = 0f; //sensorEvent.values[1]; ignore Y-axis (horizon)
            float z = 0f; //sensorEvent.values[2];  ignore Z-axis (depth)

            long curTime = System.currentTimeMillis();

            // fixed update every 0.1 sec
            if ((curTime - lastUpdate) > 100) {
                long diffTime = (curTime - lastUpdate);
                lastUpdate = curTime;

                float speed = Math.abs(x + y + z - last_x - last_y - last_z)/ diffTime * 10000;

                // debug
                EditText edSpd= (EditText)findViewById(R.id.editText4);
                edSpd.setText(float2Str(speed));
                Log.i("info", "Test: " + float2Str(speed) );

                // cal upon selected method
                switch (calMethod)
                {
                    case speed:
                        if (speed > SHAKE_THRESHOLD) {
                            ShakeDetected();
                        }
                        break;

                    case x_axis:
                        if (Math.abs(x) >= 10.0f) {
                            ShakeDetected();
                        }
                        break;
                }

                last_x = x;
                last_y = y;
                last_z = z;

                // show
                TextView edX= (TextView)findViewById(R.id.textViewX);
                TextView edY= (TextView)findViewById(R.id.textViewY);
                TextView edZ= (TextView)findViewById(R.id.textViewZ);
                edX.setText( float2Str(last_x));
                edY.setText( float2Str(last_y));
                edZ.setText( float2Str(last_z));
            }
        }
    }
    void ShakeDetected()
    {
        Log.d("debug", "Detected! " + calMethod);
        // getApplicationContext(), +  String.valueOf(x) + ":" +  String.valueOf(y) + ":" +  String.valueOf(z)
        Toast.makeText(this,
                "Shake Detected! ",
                Toast.LENGTH_SHORT).show();

        ChangeStepCount(1);
    }
    public void ChangeStepCount(int stepVal)
    {
        step_count += stepVal;
        tv_step_count.setText(step_count.toString());
    }
    public void ResetStepCount(View view)
    {
        step_count = 0;
        tv_step_count.setText(step_count.toString());
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

    // method selection
    enum CalMethod{
        speed,
        x_axis
    }
    CalMethod calMethod = CalMethod.speed; // default
    public void methodSelected(View view){
        String  mSel = "speed";
        if (view != null)
        {
            mSel = view.getTag().toString(); // get by Tag in XML
        }
        calMethod = CalMethod.valueOf(mSel); //.values()[ (int)view.getTag()];
        EditText edMethod = (EditText)findViewById(R.id.editText);
        edMethod.setText(calMethod.name());

        Log.i("method", "method selected: " + calMethod.toString());
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
