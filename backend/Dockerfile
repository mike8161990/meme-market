FROM mcr.microsoft.com/vscode/devcontainers/dotnet

ENV PATH $PATH:/home/vscode/.dotnet/tools
RUN su vscode -c "dotnet tool install --global dotnet-ef --version 5.0.2"
