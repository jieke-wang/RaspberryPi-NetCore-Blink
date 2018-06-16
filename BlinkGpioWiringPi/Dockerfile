FROM resin/rpi-raspbian as wiringpi-builder
RUN apt-get update && apt-get install -y \
    git-core \
    build-essential \
    gcc \
    --no-install-recommends && \
    rm -rf /var/lib/apt/lists/*

RUN git clone git://git.drogon.net/wiringPi

WORKDIR /wiringPi

RUN ./build

FROM microsoft/dotnet:2.1-sdk as dot-net-builder
ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

RUN mkdir -p /root/src/app  
WORKDIR /root/src/app  
COPY . .

RUN dotnet restore ./BlinkGpioWiringPi.csproj  
RUN dotnet publish -c release -o published -r linux-arm

FROM microsoft/dotnet:2.1.0-runtime-stretch-slim-arm32v7

WORKDIR /root/
COPY --from=wiringpi-builder /usr/local/lib .
COPY --from=dot-net-builder /root/src/app/published .

CMD ["dotnet", "./BlinkGpioWiringPi.dll"]