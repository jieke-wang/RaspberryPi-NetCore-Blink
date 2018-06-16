# RaspberryPi-NetCore-Blink
Using docker as a deployment mechanism, we'll use .Net Core 2.1 to blink a light using RaspberryPi's GPIO file integrations

# Setup and running
After you've set up the Raspberry Pi to run docker, connect an LED to GPIO pin 17 (and use a resistor too)

build the docker file and push it to the docker hub, then run the following command on the pi:
```bash
sudo docker run -it -v /sys:/sys ${imageName}:${version}
```

