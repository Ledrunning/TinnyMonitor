# TinnyMonitor
Desktop application for the hardware weather station 
You can find the hardware project on the next repository - https://github.com/Ledrunning/HomeMeteostation

[![Build status](https://ci.appveyor.com/api/projects/status/bgvljka6bg9ofhec?svg=true)](https://ci.appveyor.com/project/Ledrunning/tinnymonitor)

## Application Capabilities

* Getting data from hardware devices using USB (Virtual com port);
  * Auto detect connection;
  * Indoor/Outdoor temperature;
  * Humidity;
  * Room light level;
* Virtual Com port settings;
* Console;
* Telemetry graph (DEMO);

TODO:
  * Telemetry graph
  * Real-time clock

Also, you can use this program for your hardware device with different microcontrollers,
just form your data transfer string it must be like that: "temp1 = {value}, temp2 = {value}, humidity = {value}, lightlevel = {value} \r"
with real-time values (you should put it instead of placeholders)
## Download Release as a TinyMonitorSetup.exe classic desktop installation and install it!

## UI Layouts
  
  ![](tinyMonitor.gif)


