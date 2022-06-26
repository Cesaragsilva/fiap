pipeline{
    agent any

    stages{
        stage('1# Clone code from GitHub') {
            steps {
                git url: 'https://github.com/Cesaragsilva/fiap.git', branch: 'master'
            }
            post{
                always{
                    echo "========Cloning code from Github========"
                }
                success{
                    echo "========executed successfully========"
                }
                failure{
                    echo "========execution failed========"
                }
            }
        }

        stage('#2 Building Dockerfile') {
            steps {
                script {
                    dockerapp = docker.build("cesarag92/fiap-application:v${env.BUILD_ID}",
                    '-f ./Transacoes/Dockerfile ./Transacoes')
                }
            }
            post{
                always{
                    echo "========Building Dockerfile========"
                }
                success{
                    echo "========executed successfully========"
                }
                failure{
                    echo "========execution failed========"
                }
            }
        }

        stage('# Pushing image to DockerHub') {
            steps {
                script {
                        docker.withRegistry('https://registry.hub.docker.com', 'dockerhub') {
                        dockerapp.push('latest')
                        dockerapp.push("v${env.BUILD_ID}") 
                    }
                }
            }
            post {
                always{
                    echo "========Pushing image to DockerHub========"
                }
                success{
                    echo "========executed successfully========"
                }
                failure{
                    echo "========execution failed========"
                }
            }
        }
    }
}