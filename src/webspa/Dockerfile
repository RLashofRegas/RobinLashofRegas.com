FROM node:14 as node-build

WORKDIR /app
ENV PATH /app/node_modules/.bin:$PATH

COPY package.json package-lock.json ./
RUN npm install

COPY . ./
RUN npm run build

CMD [ "ng", "serve", "--host", "0.0.0.0" ]
