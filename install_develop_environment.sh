#/bin/bash
#depends on Ubuntu 18.04

wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb

sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-3.1 aspnetcore-runtime-3.1 docker docker-compose git

wget https://release.gitkraken.com/linux/gitkraken-amd64.deb
sudo dpkg -i ./gitkraken-amd64.deb
curl https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > packages.microsoft.gpg
sudo install -o root -g root -m 644 packages.microsoft.gpg /etc/apt/trusted.gpg.d/
sudo sh -c 'echo "deb [arch=amd64 signed-by=/etc/apt/trusted.gpg.d/packages.microsoft.gpg] https://packages.microsoft.com/repos/vscode stable main" > /etc/apt/sources.list.d/vscode.list'
sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install code 

code --list-extensions
code --install-extension ms-dotnettools.csharp
code --install-extension jchannon.csharpextensions
code --install-extension ms-azuretools.vscode-docker
code --install-extension leo-labs.dotnet
code --install-extension ckolkman.vscode-postgres
code --install-extension visualstudioexptteam.vscodeintellicode
code --install-extension fernandoescolar.vscode-solution-explorer

sudo docker-compose -f docker-compose-external-services.yml up -d

