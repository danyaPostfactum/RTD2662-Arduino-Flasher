# RTD266X_I2CFlasher
Read, write, verify and erase the SPI flash chip connected to an RTD266X video chip from an Arduino


   Port of Adafruit_RTD266X_I2CFlasher, but uses PC connection instead of SD card to load ROM


   * Tested with RTD2662 but ought to work w/RTD2660 also (2668 uses a different protocol tho)

   * Connect GND, SDA and SCL -> RTD programming pins (on some boards, they are on the VGA port). Don't add any pullups, you'll use the 3.3V pu's on the RTD board

   * Use non-standart PC software to connect to Arduino and load ROM.