#/bin/bash
MACHINE=${uname -p}
OS=${cat /etc/*-release | uniq | head -1 | cut -c 12-17 | tr '[A-Z]' '[a-z]'}
VERSION=${cat /etc/*-release | uniq | head -2 | tail -1 | cut -c 17-21}


case MACHINE in
    x86_64
        download_install_debfile
    ;;
    armv7l
        CORE_TAR_FILE_LOCALE=https://download.visualstudio.microsoft.com/download/pr/349f13f0-400e-476c-ba10-fe284b35b932/44a5863469051c5cf103129f1423ddb8/dotnet-sdk-3.1.102-linux-arm.tar.gz
        RUNTIME_TAR_FILE_LOCALE=https://download.visualstudio.microsoft.com/download/pr/8ccacf09-e5eb-481b-a407-2398b08ac6ac/1cef921566cb9d1ca8c742c9c26a521c/aspnetcore-runtime-3.1.2-linux-arm.tar.gz
        download_install_tarfile
    ;;
    arm64
        CORE_TAR_FILE_LOCALE=https://download.visualstudio.microsoft.com/download/pr/2ea7ea69-6110-4c39-a07c-bd4df663e49b/5d60f17a167a5696e63904f7a586d072/dotnet-sdk-3.1.102-linux-arm64.tar.gz
        RUNTIME_TAR_FILE_LOCALE=https://download.visualstudio.microsoft.com/download/pr/ec985ae1-e15c-4858-b586-de5f78956573/f585f8ffc303bbca6a711ecd61417a40/aspnetcore-runtime-3.1.2-linux-arm64.tar.gz
        download_install_tarfile
    aarch64
        CORE_TAR_FILE_LOCALE=https://download.visualstudio.microsoft.com/download/pr/2ea7ea69-6110-4c39-a07c-bd4df663e49b/5d60f17a167a5696e63904f7a586d072/dotnet-sdk-3.1.102-linux-arm64.tar.gz
        RUNTIME_TAR_FILE_LOCALE=https://download.visualstudio.microsoft.com/download/pr/ec985ae1-e15c-4858-b586-de5f78956573/f585f8ffc303bbca6a711ecd61417a40/aspnetcore-runtime-3.1.2-linux-arm64.tar.gz
        download_install_tarfile
    armv8
        CORE_TAR_FILE_LOCALE=https://download.visualstudio.microsoft.com/download/pr/2ea7ea69-6110-4c39-a07c-bd4df663e49b/5d60f17a167a5696e63904f7a586d072/dotnet-sdk-3.1.102-linux-arm64.tar.gz
        RUNTIME_TAR_FILE_LOCALE=https://download.visualstudio.microsoft.com/download/pr/ec985ae1-e15c-4858-b586-de5f78956573/f585f8ffc303bbca6a711ecd61417a40/aspnetcore-runtime-3.1.2-linux-arm64.tar.gz
        download_install_tarfile
    ;;

npm install -g nouislider
sudo docker-compose -f docker-compose-external-services.yml up -d

download_install_tarfile(){
    wget CORE_TAR_FILE_LOCALE
    wget RUNTIME_TAR_FILE_LOCALE
    mkdir dotnet
    tar zxf dotnet* -C $HOME/dotnet
    tar zxf aspnetcore-runtime-* -C $HOME/dotnet
    cat >> ~/.bashrc <<EOF
export DOTNET_ROOT=$HOME/dotnet
export PATH=$PATH:$HOME/dotnet
EOF
}

download_install_debfile(){
    deb_locale=https://packages.microsoft.com/config/${OS}/${VERSION}/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
    sudo dpkg -i packages-microsoft-prod.deb
    sudo apt-get update; \
    sudo apt-get install -y apt-transport-https && \
    sudo apt-get update && \
    sudo apt-get install -y dotnet-sdk-3.1 aspnetcore-runtime-3.1
}
