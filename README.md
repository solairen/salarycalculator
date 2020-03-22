![Docker image](https://github.com/moleszek/salarycalculator/workflows/Docker%20image/badge.svg) [![CodeFactor](https://www.codefactor.io/repository/github/moleszek/salarycalculator/badge)](https://www.codefactor.io/repository/github/moleszek/salarycalculator)

## SalaryCalculator

### About:

Simpe application that calculates the salary based on the hours specified and the hourly wage.

### Language and Framework:

* Language: C#
* Framework: netCore 3.1

### Additional information:

This program can be also build as a docker container

#### To build as a standalone application that contains .msi installer:

* OS: Windows only

* Use script: 
    * buildstandalone.ps1

#### To build as a docker container:

* OS in container: Linux

* Use script:
    
    * builddocker.ps1

### To pull image from docker hub:

* docker pull moleszek/salarycalculator:latest

### Usage:

* Windows:
    
    * Open C:\Program Files\Funny Company\SalaryCalculator.exe and enter values
    * From CMD/PowerShell run "C:\Program Files\Funny Company\SalaryCalculator.exe -h/hours 100 -hw/hourlywage 10

* Docker:

    * docker run --rm moleszek/salarycalculator:latest -h/hours 100 -hw/hourlywage 10