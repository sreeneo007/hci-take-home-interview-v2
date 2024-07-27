# Use an official Node runtime as a parent image
FROM node:14 AS build
WORKDIR /usr/src/app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

# Use an Nginx image to serve the React application
FROM nginx:alpine
COPY --from=build /usr/src/app/dist /usr/share/nginx/html