FROM node:8
MAINTAINER Sid Gupta <sgupta2@my.westga.edu>
RUN ln -s /usr/bin/nodejs /usr/bin/node
RUN npm install -g http-server
WORKDIR /usr/apps/data
CMD [ "http-server", "/usr/apps/data" ,"-g"]
