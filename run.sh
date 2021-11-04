docker-compose down

rm -rf ./grafana/data
rm -rf ./influxdb
rm -rf ./influxdb2
rm -rf ./mongodb/data/configdb
rm -rf ./mongodb/data/db

mkdir ./grafana/data
mkdir ./influxdb
mkdir ./influxdb2
mkdir ./mongodb/data/configdb
mkdir ./mongodb/data/db

docker-compose up --build