FROM node:latest AS build
WORKDIR /usr/src/app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

FROM nginx:latest
COPY --from=build /usr/src/app/dist/project-zurich-web /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]