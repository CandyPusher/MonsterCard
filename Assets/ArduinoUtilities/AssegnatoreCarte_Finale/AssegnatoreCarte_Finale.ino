#include <SPI.h>
#include <MFRC522.h>

#define SS_PIN 10
#define RST_PIN 9

MFRC522 rfid(SS_PIN, RST_PIN);

struct CartaUtente {
  byte uid[4];
  int azioneID;
  int numberDeck;
};

CartaUtente carteAutorizzate[] = {
  { { 0xFA, 0x10, 0x0C, 0x05 }, 0, 1},
  { { 0xAE, 0x9D, 0x07, 0x05 }, 0, 2},
  { { 0x21, 0xD6, 0x0B, 0x05 }, 0, 3},
  { { 0x47, 0x8F, 0x0A, 0x05 }, 1, 1},
  { { 0x7A, 0x41, 0x0A, 0x05 }, 2, 1},
  { { 0x7B, 0x4F, 0x08, 0x05 }, 3, 1},
  { { 0x59, 0x92, 0x07, 0x05 }, 4, 1},
  { { 0xB5, 0x69, 0x0E, 0x05 }, 5, 1},
  { { 0x56, 0x36, 0x09, 0x05 }, 6, 1},
  { { 0xA6, 0x0E, 0x0A, 0x05 }, 7, 1},
  { { 0xBE, 0x98, 0x0A, 0x05 }, 8, 1},
  { { 0x2C, 0x1E, 0x0B, 0x05 }, 9, 1},
  { { 0x35, 0x5D, 0x0E, 0x05 }, 10, 1},
  { { 0x27, 0x9F, 0x07, 0x05 }, 1, 2},
  { { 0x4C, 0x49, 0x08, 0x05 }, 2, 2},
  { { 0xED, 0x7B, 0x0E, 0x05 }, 3, 2},
  { { 0x63, 0xA2, 0x07, 0x05 }, 4, 2},
  { { 0x9B, 0x2B, 0x0A, 0x05 }, 5, 2},
  { { 0xBD, 0x4D, 0x0A, 0x05 }, 6, 2},
  { { 0xE3, 0xAE, 0x09, 0x05 }, 7, 2},
  { { 0xE7, 0x59, 0x0E, 0x05 }, 8, 2},
  { { 0x6A, 0xB2, 0x09, 0x05 }, 9, 2},
  { { 0xAE, 0xA6, 0x0E, 0x05 }, 10, 2},
  { { 0xB3, 0x2E, 0x07, 0x05 }, 1, 3},
  { { 0x7B, 0x9D, 0x07, 0x05 }, 2, 3},
  { { 0x76, 0xB4, 0x0B, 0x05 }, 3, 3},
  { { 0xAD, 0x39, 0x07, 0x05 }, 4, 3},
  { { 0x2A, 0x8A, 0x0E, 0x05 }, 5, 3},
  { { 0xBC, 0xE2, 0x0A, 0x05 }, 6, 3},
  { { 0x11, 0x02, 0x0B, 0x05 }, 7, 3},
  { { 0xDE, 0x9C, 0x07, 0x05 }, 8, 3},
  { { 0xA2, 0xCE, 0x0B, 0x05 }, 9, 3},
  { { 0xDC, 0x5D, 0x0E, 0x05 }, 10, 3},
};

const int numeroCarte = sizeof(carteAutorizzate) / sizeof(carteAutorizzate[0]);

void setup() {
  Serial.begin(9600);
  SPI.begin();
  rfid.PCD_Init();
  pinMode(2, INPUT_PULLUP);
}

bool isPressed = false;

void loop() {
  if (digitalRead(2) == LOW) {
    if(!isPressed){
      Serial.println("Pressed");
      isPressed = true;
    }
  } else {
    if(isPressed){
      isPressed = false;
    }
  }
  if (!rfid.PICC_IsNewCardPresent()) return;
  if (!rfid.PICC_ReadCardSerial()) return;

  int idTrovato = -1;
  int deckTrovato = -1;

  for (int i = 0; i < numeroCarte; i++) {
    if (confrontaUID(rfid.uid.uidByte, carteAutorizzate[i].uid)) {
      idTrovato = carteAutorizzate[i].azioneID;
      deckTrovato = carteAutorizzate[i].numberDeck;
      break;
    }
  }

  if (idTrovato != -1) {
    eseguiAzione(idTrovato, deckTrovato);
  } else {
    Serial.println(F("Carta non riconosciuta"));
    printHex(rfid.uid.uidByte, rfid.uid.size);
  }

  // Stop lettura
  rfid.PICC_HaltA();
  rfid.PCD_StopCrypto1();
}

void eseguiAzione(int id, int _deckTrovato) {
  Serial.print(id);
  Serial.print("-");
  Serial.println(_deckTrovato);
}

bool confrontaUID(byte *uidLetto, byte *uidTarget) {
  for (byte i = 0; i < 4; i++) {
    if (uidLetto[i] != uidTarget[i]) return false;
  }
  return true;
}

void printHex(byte *buffer, byte bufferSize) {
  for (byte i = 0; i < bufferSize; i++) {
    Serial.print(buffer[i] < 0x10 ? " 0" : " ");
    Serial.print(buffer[i], HEX);
  }
  Serial.println();
}
