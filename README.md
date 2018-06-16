Using docker as a deployment mechanism, this app shows how to write a simple .Net Core 2.1 console app which to blinks a light using RaspberryPi's GPIO file integrations

# Setup and running
## On your developer machine:
* Use docker to build and push a BlinkGpioFS image which will use the file system to interact with GPIO,
* Use docker to build and push a BlinkGpioWiringPi image which uses wiring pi to interact with the GPIO.

## On your Raspberry Pi:
* Connect a LED to GPIO 17 (and use a resistor too)
* Install docker using ``curl -sSL https://get.docker.com | sh``
* Run the image using ``sudo docker run -it -v /sys:/sys --privileged ${imageName}:${version}``
