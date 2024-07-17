# Use an official Node runtime as a parent image
FROM node:14 AS build
WORKDIR /usr/src/app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build --prod

# Use an Nginx image to serve the Angular application
FROM nginx:alpine
COPY --from=build /usr/src/app/dist/patient-administration-system.ui /usr/share/nginx/html
