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
                    dockerapp = docker.build("cesarag92/fiap-application:${env.BUILD_ID}",
                    '-f ./Transacoes/Dockerfile .')
                }
            }
        }
    }
}