dotnet build-server shutdown
del .\.sonarqube /S /Q

dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=OpenCover /p:CoverletOutput=.\TestResults\ .\test\Everis.Polar.ApiRest.Tests\Everis.Polar.ApiRest.Tests.csproj
reportgenerator -reports:%CD%/TestResults/coverage.opencover.xml -targetdir.\TestResults\Reports\ -reportTypes:HTMLInline;Cobertura

REM coverlet ./test/Everis.Polar.ApiRest.Tests/bin/Debug/netcoreapp2.1/Everis.Polar.ApiRest.Tests.dll --target "dotnet" --targetargs "test ./test/Everis.Polar.ApiRest.Tests/Everis.Polar.ApiRest.Tests.csproj --no-build" --format opencover

REM dotnet sonarscanner begin /key:POLAR /name:POLAR-polar /version:1.0.1 /d:sonar.host.url=https://steps.everis.com/sonarqube6ce /d:sonar.login=402bf587a948779851e60203139a518f8a01b0c9  /d:sonar.cs.cobertura.reportsPaths=%CD%/TestResults/Reports /d:sonar.exclusions=**wwwroot/lib/**
dotnet sonarscanner begin /key:POLAR /name:POLAR-polar /version:1.0.1 /d:sonar.host.url=http://localhost:9000 /d:sonar.login=5cebd1b77e6fd871c9f796832a5ec68fceda62dd /d:sonar.verbose=true /d:sonar.cs.opencover.reportsPaths=.\test\Everis.Polar.ApiRest.Tests\coverage.opencover.xml /d:sonar.exclusions=**wwwroot/lib/**
dotnet build Polar.sln
dotnet sonarscanner end /d:sonar.login=5cebd1b77e6fd871c9f796832a5ec68fceda62dd

REM dotnet %UserProfile%\.nuget\packages\reportgenerator\4.0.0\tools\netcoreapp2.0\ReportGenerator.dll -reports:%CD%\TestResults\Coverage.opencover.xml -targetdir:%CD%\TestResults\Reports\ -reporttypes:OpenCover
