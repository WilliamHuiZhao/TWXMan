=====================================================================
Welcome to TWXMan!

This tool is only for internal ThingWorx testing.

Only tested on Windows 10 OS, English version.

=====================================================================
Thingworx Runtime Usage

Prerequisites
1. Setup Oracle JDK.
2. Setup PostgreSQL 12.

Steps
1. Unzip to C:\data\TWXMan.
2. Run C:\data\TWXMan\TWXMan.exe.
3. Download Apache Tomcat zip distribution files, for example apache-tomcat-9.0.63.zip, and store into C:\data\TWXMan\package\tomcat.
4. Download Thingworx zip files for PostgreSQL, for example MED-61111-CD-093_SP8_ThingWorx-Platform-Postgres-9-3-8.zip, and store into C:\data\TWXMan\package\thingworx.
5. Create Tomcat runtime, File -> New -> Tomcat Runtime.
6. Create Thingworx runtime, File -> New -> Thingworx Runtime.
7. Start PostgreSQL service, open CMD, goto Thingworx runtime folder, run *-createdb.bat to create database.
8. Start a Thingworx runtime, right click on *-start.bat, select "Run as administrator".
9. Stop a Thingworx runtime, right click on *-stop.bat, select "Run as administrator".

If needed, you can modify *-start.bat and *-stop.bat to meet specific testing requirements.
