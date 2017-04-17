package com.example.aayum.a91springboard;

import android.net.wifi.WifiManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.text.format.Formatter;
import android.util.Log;
import android.view.View;
import android.widget.Button;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.InetAddress;
import java.net.Socket;
import java.net.UnknownHostException;

public class Doors extends AppCompatActivity implements View.OnClickListener {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_doors);
        Button b = (Button)findViewById(R.id.button3);
        b.setOnClickListener(this);
        Button c =(Button)findViewById(R.id.button2);
        c.setOnClickListener(this);
    }


//    private void connectSocket(String a){
//
//        try {
//            WifiManager wm = (WifiManager) getSystemService(WIFI_SERVICE);
//            String ip = Formatter.formatIpAddress(wm.getConnectionInfo().getIpAddress());
//            InetAddress serverAddr = InetAddress.getByName("192.168.43.39");
//            Log.d("TCP", "C: Connecting...");
//            Socket socket = new Socket(serverAddr, 4444);
//            String message = null;
//            message = a + "Aayush Makkad";
//
//
//            PrintWriter out = null;
//            BufferedReader in = null;
//
//            try {
//                Log.d("TCP", "C: Sending: '" + message + "'");
//                out = new PrintWriter( new BufferedWriter( new OutputStreamWriter(socket.getOutputStream())),true);
//                in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
//
//                out.println(message);
//                String text = "";
//                String finalText = "";
//
//
//
//                while ((in.readLine()) != null)  {
////                    finalText += text;
//
//                }
//
//
//                Log.d("TCP", "C: Sent.");
//                Log.d("TCP", "C: Done.");
//
//            } catch(Exception e) {
//                Log.e("TCP", "S: Error", e);
//            } finally {
//                socket.close();
//            }
//
//        } catch (UnknownHostException e) {
//            // TODO Auto-generated catch block
//            Log.e("TCP", "C: UnknownHostException", e);
//            e.printStackTrace();
//        } catch (IOException e) {
//            // TODO Auto-generated catch block
//            Log.e("TCP", "C: IOException", e);
//            e.printStackTrace();
//        }
//    }
//}
private void connectSocket(String a){

    try {
        WifiManager wm = (WifiManager) getSystemService(WIFI_SERVICE);
        String ip = Formatter.formatIpAddress(wm.getConnectionInfo().getIpAddress());
        InetAddress serverAddr = InetAddress.getByName("192.168.43.39");
        Log.d("TCP", "C: Connecting...");
        Socket socket = new Socket(serverAddr, 4444);
        String message = null;
//            if(a=="lock_all")
//                message = "Lock_all";
//            else if(a=="lock_selec")
//                message="Lock_selec";
        message=a + "Aayush Makkad";


        PrintWriter out = null;
        BufferedReader in = null;

        try {
            Log.d("TCP", "C: Sending: '" + message + "'");
            out = new PrintWriter( new BufferedWriter( new OutputStreamWriter(socket.getOutputStream())),true);
            in = new BufferedReader(new InputStreamReader(socket.getInputStream()));

            out.println(message);
            String text = "";
            String finalText = "";



            while ((in.readLine()) != null)  {
//                    finalText += text;

            }


            Log.d("TCP", "C: Sent.");
            Log.d("TCP", "C: Done.");

        } catch(Exception e) {
            Log.e("TCP", "S: Error", e);
        } finally {
            socket.close();
        }

    } catch (UnknownHostException e) {
        // TODO Auto-generated catch block
        Log.e("TCP", "C: UnknownHostException", e);
        e.printStackTrace();
    } catch (IOException e) {
        // TODO Auto-generated catch block
        Log.e("TCP", "C: IOException", e);
        e.printStackTrace();
    }
}


    @Override
    public void onClick(View v) {
        switch (v.getId()) {
//            case R.id.button4: connectSocket("off fan"); break;
            case R.id.button3 : connectSocket("off fand"); break;
            case R.id.button2 : connectSocket("dimd"); break;
        }
    }
}
