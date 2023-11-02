# Projeto Zurich

## Autor: Jackson de Fraga


cd ProjectZurich
docker build -t zurich-backend .

cd project-zurich-web
docker build -t zurich-frontend .

docker run -d -p 5000:80 zurich-backend
docker run -d -p 8080:80 zurich-frontend
