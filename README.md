# TinnyMonitor
Desktop application for the hardware weather station 

[https://ci.appveyor.com/api/projects/status/32r7s2skrgm9ubva?svg=true](https://ci.appveyor.com/api/projects/status/32r7s2skrgm9ubva?svg=true)

You can find the hardware project on the next repository - https://github.com/Ledrunning/HomeMeteostation

## Application Capabilities

* Getting data from hardware devices using USB (Virtual com port); 
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

## UI Layouts
  
  ![](tinyMonitor.gif)


