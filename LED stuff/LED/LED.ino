#include <LedControl.h>

//pins
int DIN = 12;
int CS =  11;
int CLK = 10;
//LED CONTROl
LedControl lc=LedControl(DIN,CLK,CS,0);



void setup(){
  Serial.begin(9600);
  lc.shutdown(0,false);       //Turning off power saving mode
  lc.setIntensity(0,1);      // Brightness (god help me do not go above 10)
  lc.clearDisplay(0);         // and clear the display
}

void loop(){
  ProtocallLoop();
}

void ProtocallLoop(){
    // checking if anything is in siral buffer
  while(Serial.available() > 0){
    char message = Serial.read();
    switch (message){
      case 's':
      PrintSad();
      break;
      
      case 'n':
      PrintNeutral();
      break;

      case 'h':
      PrintHappy();
      break;
    }  
  }
}

//printing function
void printByte(byte character [])
{
  int i = 0;
  for(i=0;i<8;i++)
  {
    lc.setRow(0,i,character[i]);
  }
}

//Print Face Functions
void PrintNeutral(){
  byte neutral[8] = {0x00,0x00,0xE7,0x00,0x42,0x42,0x7E,0x00};
  printByte(neutral);
}
void PrintHappy(){
  byte smile[8] =   {0x00,0x42,0xA5,0x00,0x7E,0x42,0x3C,0x00};
  printByte(smile);
}
void PrintSad(){
  byte frown[8] =   {0x00,0x00,0x24,0x42,0x81,0x3C,0x42,0x00};
  printByte(frown);
}
