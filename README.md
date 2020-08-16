## SalaryCalculator

### About:

Simpe application that calculates the salary based on the hours specified and the hourly wage.

### Language and Framework:

* Language: C#
* Framework: netCore 3.1
* Tools: Wix Toolset

### Additional information:

Add "C:\Program Files (x86)\WiX Toolset v3.11\bin" to user path.

#### To build as a standalone application that contains .msi installer:

* OS: Windows

* Use script: 
    * build_windows.ps1

#### To build as a docker container:

* OS in container: Linux

* Use script:
    
    * build_docker.ps1

#### To build as a standalone application for Linux:

* OS: Linux

* Use script:

    * build_linux.ps1

### To pull image from docker hub:

* docker pull moleszek/salarycalculator:1.1

### Usage:

* Windows:
    
    * Open C:\Program Files\Funny Company\SalaryCalculator.exe and enter values
    * From CMD/PowerShell run "C:\Program Files\Funny Company\SalaryCalculator.exe -h/hours 100 -hw/hourlywage 10

* Docker:

    * docker run --rm moleszek/salarycalculator:1.2 -h/hours 100 -hw/hourlywage 10

* Linux:

    * dotnet run SalaryCalculator.dll -h/hours 100 -hw/hourlywage 10