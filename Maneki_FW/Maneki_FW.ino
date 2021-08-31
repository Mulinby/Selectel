#include "PCM.h"
#include "myau.h"
#include "error.h"
#define BTN               4  // Кнопка

byte succes = 1;             // Символ успешной отправки
byte denied = 0;             // Символ ошибки
byte mess;                   // Принятое сообщение

void setup()
{
  Serial.begin(9600);
  pinMode(BTN, INPUT_PULLUP);
}

void loop()
{
  if (digitalRead(BTN) == 0)
  {
    Serial.println(2);
    delay(500);
  }
  if (Serial.available() > 0)
  {
    mess = Serial.read();

    if (mess == '1')
    {
      Serial.println("Succes");
      startPlayback(myau, sizeof(myau));
    }
    else if (mess == '0')
    {
      Serial.println("Denied");
      startPlayback(error, sizeof(error));
    }
  }
}
