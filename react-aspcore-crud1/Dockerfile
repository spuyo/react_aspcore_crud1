# Build image STAGE 1
FROM node:14.15.1-alpine3.11 as build-stage

# change working directory to the app directory
WORKDIR /app

# copy package.json from current filesystem to workingdir
COPY package*.json /app/

# install items needed on alpine linux for npm to install modules correctly
RUN apk --no-cache add g++ gcc libgcc libstdc++ linux-headers make python

# install node-gyp -system specific and needs to be installed before modules
RUN npm install --silent node-gyp -g

# install package.json modules
RUN npm install --silent

# Copy all currently made items into Working directory
COPY ./ /app/

# build artifact
RUN npm run build


# STAGE 2 Make nginx image

# based on Nginx, to have only the compiled app, ready for production with Nginx
FROM nginx:1.19.5-alpine

# Copy the build artifact in state 1 into the served directory of nginx
COPY --from=build-stage /app/build/ /usr/share/nginx/html

# Copy your custom nginx.conf to the default of nginx
COPY --from=build-stage /app/config/nginx.conf /etc/nginx/conf.d/default.conf