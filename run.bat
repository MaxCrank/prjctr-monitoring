docker-compose down

rd /s /q .\grafana\data
rd /s /q .\influxdb
rd /s /q .\influxdb2
rd /s /q .\mongodb\data\configdb
rd /s /q .\mongodb\data\db

mkdir .\grafana\data
mkdir .\influxdb
mkdir .\influxdb2
mkdir .\mongodb\data\configdb
mkdir .\mongodb\data\db

docker-compose up --build