FROM microsoft/wcf:4.7.1
ARG source
# Next, this Dockerfile creates a directory for your application
RUN mkdir C:\WcfServiceTest
# configure the new site in IIS.
RUN powershell -NoProfile -Command \
Import-module IISAdministration; \
New-IISSite -Name "WcfServiceTest" -PhysicalPath C:\WcfServiceTest-BindingInformation "*:83:"

RUN Import-Module WebAdministration; Set-ItemProperty "IIS:\\Sites\\WcfServiceTest" -name bindings -value (@{protocol='net.tcp';bindingInformation='808:*'},@{protocol='http';bindingInformation='*:83:'});
RUN windows\system32\inetsrv\appcmd.exe set app 'WcfServiceTest/' /enabledProtocols:"http,net.tcp"
# This instruction tells the container to listen on port 83.
EXPOSE 83

COPY ${source:-obj/Docker/publish} c:\\WcfServiceTest