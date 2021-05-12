
dotnet test  /p:CollectCoverage=true /p:CoverletOutput="./TestResults/coverage.cobertura.xml" /p:CoverletOutputFormat="cobertura"


reportgenerator -reports:.\TestResults\coverage.cobertura.xml -reporttypes:"HTML" -targetDir:.\CoverageReport\
start .\CoverageReport\index.html