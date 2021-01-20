node("Win") {
    stage("Pull") {
        git "https://github.com/huhu0327/MCInstall.git"
    }

    stage("Restore") {
        bat "dotnet restore src/"
    }

    stage("Clean") {
        bat "dotnet clean src/"
    }

    stage("Build") {
        withSonarQubeEnv("sonarqube"){
            bat "dotnet-sonarscanner begin /k:MCInstall"
            bat "dotnet build src/ --configuration Release --no-restore"
        }
    }

    stage("Test") {
        bat "dotnet test src/ --no-restore"
    }

    stage("Analysis"){
        withSonarQubeEnv("sonarqube"){
            bat "dotnet-sonarscanner end"
        }
    }

    stage("publish") {

    }
}
