pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                sh 'npm install'
                echo 'Building..'
            }
        }
        stage('Test') {
            steps {
            sh 'npm test'
                echo 'Unit testing..'
            }
        }

        stage('e2e tests') {
        steps{
              sh 'webdriver-manager start --versions.chrome 2.38 &'
              sh 'docker kill testenv || true'
              sh 'docker rm testenv || true'
              sh 'docker build -f "./docker_testenv/Dockerfile" -t "docker_testenv:jenkins_image" .'
              sh 'docker run --name testenv -d -p "8000:8080" -v $WORKSPACE/app:/usr/apps/data "docker_testenv:jenkins_image"'
              sh 'protractor protractor.conf.js'

             }
        post {
             always {
             sh 'docker kill testenv||true'
             sh 'docker rm testenv||true'
             sh 'docker image rmi docker_testenv:jenkins_image||true'
             echo 'I will always say Hello again!'
              }
            }
        }

        stage('Deploy') {
            steps {
            sh 'docker build -f "./docker_testenv/Dockerfile" -t "docker_testenv:jenkins_image" .'
            sh 'docker run --name testenv -d -p "3000:8080" -v $WORKSPACE/app:/usr/apps/data "docker_testenv:jenkins_image"'
                echo 'Done !'
            }
        }
    }

    post {
         always {
         echo 'So tired, TTYL!'
          }
        }

}
