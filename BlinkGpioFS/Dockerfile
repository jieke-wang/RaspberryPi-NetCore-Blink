FROM microsoft/dotnet:2.1-sdk as builder  
ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

RUN mkdir -p /root/src/app  
WORKDIR /root/src/app  
COPY *.* ./

RUN dotnet restore ./BlinkGpioFs.csproj  
RUN dotnet publish -c release -o published -r linux-arm

FROM microsoft/dotnet:2.1.0-runtime-stretch-slim-arm32v7

WORKDIR /root/
COPY --from=builder /root/src/app/published .

CMD ["dotnet", "./BlinkGpioFs.dll"]