/* Read, write, verify and erase the SPI flash chip connected to an RTD266X video chip 
   from an Arduino (32u4 tested, but ought to work with any)

   Essentially just a port of      https://github.com/ghent360/RTD-2660-Programmer 
   but handy if you want to have a 'standalone' programmer using something like
   a Feather Adalogger https://www.adafruit.com/products/2795

   Tested with RTD2662 but ought to work w/RTD2660 also (2668 uses a different protocol tho)

   Connect GND, SDA and SCL -> RTD programming pins (on some boards, they are on the VGA port)
      don't add any pullups, you'll use the 3.3V pu's on the RTD board
   Connect SCK, MOSI, MISO, CS -> MicroSD card
*/

#include <SD.h>
#include "Wire.h"
#include "rtd266x_main.h"
#if defined(__AVR__)
   extern "C" { 
     #include "utility/twi.h"  // from Wire library, so we can do bus scanning
   }
#endif


#define SD_CS        4         // pin connected to SD chip select
#define TWI_FREQ     200000     // only changed on AVR (shrug)


bool chipConnected = false;

const FlashDesc* chip;
  
void setup(void) 
{
  while (!Serial);
  Serial.begin(115200);

  Wire.begin();
}

uint8_t getch() {
  while (!Serial.available());
  return Serial.read();
}

void connection() {
#if defined(__AVR__)
  uint8_t data;
  if (twi_writeTo(0x4A, &data, 0, 1, 1)) {
    Serial.println("Couldn't find i2c device 0x4A");
    return;
  }
  //Serial.println(F("Found 0x4A"));

  TWBR = ((F_CPU / TWI_FREQ) - 16) / 2;
#endif

  if (!WriteReg(0x6f, 0x80)) {  // Enter ISP mode
    Serial.println("Write to 0x6F failed");
    return;
  }
  uint8_t b = ReadReg(0x6f);
  if (!(b & 0x80)) {
    Serial.println("Can't enable ISP mode");
    return;
  }
  uint32_t jedec_id = SPICommonCommand(E_CC_READ, 0x9f, 3, 0, 0);
  Serial.print(F("JEDEC ID: 0x")); Serial.print(jedec_id, HEX);
  chip = FindChip(jedec_id);
  if (NULL == chip) {
    Serial.println(" Unknown chip ID");
    return;
  }
  
  Serial.print(" Manufacturer ");
  uint32_t id = GetManufacturerId(chip->jedec_id);
  switch (id) {
    case 0x20: Serial.print("ST");         break;
    case 0xef: Serial.print("Winbond");    break;
    case 0x1f: Serial.print("Atmel");      break;
    case 0xc2: Serial.print("Macronix");   break;
    case 0xbf: Serial.print("Microchip");  break;
    default:   Serial.print("Unknown");    break;
  }

  Serial.print(" Chip: ");      Serial.print(chip->device_name);
  Serial.print(" Size (KB): "); Serial.print(chip->size_kb);
  Serial.println("");
  SetupChipCommands(chip->jedec_id);
  chipConnected = true;
}

void erase() {
    EraseFlash();
}

void flash() {
ProgramFlash(chip->size_kb * 1024);

  /*
  bool finished = false;
  while (!finished) {
    uint8_t buffer[256];
    memset(buffer, 0xff, sizeof(buffer));
    
    char len = getch();
    if (len == 0) {
      finished = true;
    } else {
      for (int i = 0; i < len; i++) {
        buffer[i] = getch();
      }
    }
    Serial.print('1');
  }
  */
}

void loop(void) 
{
  while (!Serial.available());
  char cmd = Serial.read();
  
  uint32_t starttime = millis();
  
  switch (cmd) {
    case 'E':
      erase();
      Serial.println("Erase OK");
      break;
    case 'W':
      flash();
      Serial.println("Flash OK");
      break;
    case 'I':
      Serial.println("RTD FLASH TOOL");
      break;
    case 'C':
      connection();
      break;
  }
  //Serial.print(millis() - starttime); Serial.println(F(" ms"));
  /*
  if (cmd == 'R') {
     // open the file. note that only one file can be open at a time,
     // so you have to close this one before opening another.
     // Open up the file we're going to log to!
     dataFile = SD.open(SAVENAME, FILE_WRITE);
     if (! dataFile) {
       Serial.println(F("Error opening file"));
       return;
     }
    
    Serial.println(F("Dumping FLASH to disk"));
     if (! SaveFlash(&dataFile, chip->size_kb * 1024)) {
      Serial.println(F("**** FAILED ****"));
    }
    Serial.println(F("OK!"));
    dataFile.flush();
    dataFile.close();
    Serial.print(millis() - starttime); Serial.println(F(" ms"));
  }
  
  if (cmd == 'V') {
     dataFile = SD.open(READNAME, FILE_READ);
     if (! dataFile) {
       Serial.println(F("Error opening file"));
       return;
     }
    Serial.println(F("Verifying FLASH from disk"));
     if (! VerifyFlash(&dataFile, dataFile.size())) {
      Serial.println(F("**** FAILED ****"));
    }
    Serial.println(F("OK!"));
    dataFile.close();
    Serial.print(millis() - starttime); Serial.println(" ms");
  }  
  */
}



