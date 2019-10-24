#!/bin/bash

docker build -t brainshark-api.sarslan.net:latest -f ./backend/Dockerfile ./backend/ 
$(aws ecr get-login --no-include-email --region us-east-1 --profile sarslan)
docker tag brainshark-api.sarslan.net:latest 852343793337.dkr.ecr.us-east-1.amazonaws.com/brainshark-api.sarslan.net:latest
docker push 852343793337.dkr.ecr.us-east-1.amazonaws.com/brainshark-api.sarslan.net:latest
