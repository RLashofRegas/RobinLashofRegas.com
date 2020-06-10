FROM node:latest as node-build
WORKDIR /app
COPY package.json package-lock.json ./
RUN npm install

COPY . ./
RUN npm run build

CMD [ "ng", "serve" ]
