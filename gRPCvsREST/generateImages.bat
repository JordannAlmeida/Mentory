::Generate images docker from dockerfiles, if you can run any single
echo Generating a imagem from APIantiFraud.REST 
docker build -t apiantifraudrest:latest ./src/dotnet/APIantiFraud.REST

echo Generating a image from APIantiFraud.gRPC
docker build -t apiantifraudgrpc:latest ./src/dotnet/APIantifraude.gRPC

echo Generating a image from APIpagamentos.REST
docker build -t apipagamentosrest:latest ./src/dotnet/APIpagamentos.REST

echo FINISHED!!!