FROM microsoft/dotnet:2.1-sdk as builder  
ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

RUN mkdir -p /root/src/app  
WORKDIR /root/src/app  
COPY Blink     Blink  
WORKDIR /root/src/app/Blink

RUN dotnet restore ./Blink.csproj  
RUN dotnet publish -c release -o published -r linux-arm

FROM microsoft/dotnet:2.1.0-runtime-stretch-slim-arm32v7

WORKDIR /root/  
COPY --from=builder /root/src/app/Blink/published .

CMD ["dotnet", "./Blink.dll"]