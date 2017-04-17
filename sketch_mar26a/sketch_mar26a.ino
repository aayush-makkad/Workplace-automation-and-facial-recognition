const int pwm = 2 ;  //initializing pin 2 as pwm
const int in_1 = 8 ;
const int in_2 = 9 ;
const int in_12 = 4 ;
const int in_11 = 3 ;

//For providing logic to L298 IC to choose the direction of the DC motor 

void setup()
{
  Serial.begin(9600);
pinMode(pwm,OUTPUT) ;   //we have to set PWM pin as output
pinMode(in_1,OUTPUT) ;  //Logic pins are also set as output
pinMode(in_2,OUTPUT) ;
pinMode(in_12,OUTPUT) ;  //Logic pins are also set as output
pinMode(in_11,OUTPUT) ;
}

void loop()
{
   
//For Clock wise motion , in_1 = High , in_2 = Low
if (Serial.available() > 0) {
    int inByte = Serial.read();
    // do something different depending on the character received.
    // The switch statement expects single number values for each case;
    // in this exmaple, though, you're using single quotes to tell
    // the controller to get the ASCII value for the character.  For
    // example 'a' = 97, 'b' = 98, and so forth:

    switch (inByte) {
      case 'a':
      digitalWrite(in_1,HIGH) ;
digitalWrite(in_2,LOW) ;
        delay(3000);
         digitalWrite(in_1,LOW) ;
digitalWrite(in_2,LOW) ;
        break;
        case 'b':
        digitalWrite(in_1,LOW) ;
        digitalWrite(in_2,LOW) ;
        delay(3000) ;
        break;
        case 'm' : digitalWrite(in_1,HIGH) ;
        digitalWrite(in_2,HIGH) ;
        break;
        case 'p' : digitalWrite(in_12,HIGH) ;
digitalWrite(in_11,LOW) ;
        delay(3000);
        break;
        case 'o' : digitalWrite(in_12,LOW) ;
        digitalWrite(in_11,HIGH) ;
        break;
        
        default :  digitalWrite(in_1,LOW) ;
        digitalWrite(in_2,HIGH) ;
        delay(3000) ;
        digitalWrite(in_1,LOW) ;
        digitalWrite(in_2,LOW) ;


/*setting pwm of the motor to 255
we can change the speed of rotaion
by chaning pwm input but we are only
using arduino so we are using higest
value to driver the motor  */



    }
    }
}

