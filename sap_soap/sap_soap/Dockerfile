FROM microsoft/wcf
RUN mkdir C:\WcfServiceTest
RUN powershell -NoProfile -Command \
Import-module IISAdministration; \
New-IISSite -Name "WcfServiceTest" -PhysicalPath C:\WcfServiceTest -BindingInformation "*:83:"
EXPOSE 83
COPY /Published/ C:\WcfServiceTest