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
  PrintNeutral();
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

      case 'h':
      PrintHappy();
      break;

      case 'n':
      PrintNeutral();
      break;

      case 'l':
      NameAnimation();
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
  byte neutral[8] = {0x20,0x2E,0x22,0x02,0x02,0x22,0x2E,0x20};
  printByte(neutral);
}
void PrintHappy(){
  byte smile[8] =   {0x20,0x4C,0x2A,0x0A,0x0A,0x2A,0x4C,0x20};
  printByte(smile);
}
void PrintSad(){
  byte frown[8] =   {0x08,0x12,0x24,0x04,0x04,0x24,0x12,0x08};
  printByte(frown);
}

void NameAnimation(){
  byte love[8] = {0x00,0x38,0x7C,0x3E,0x3E,0x7C,0x38,0x00};
  printByte(love);
}
