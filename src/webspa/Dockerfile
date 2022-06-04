FROM node:14 as node-build

WORKDIR /app
ENV PATH /app/node_modules/.bin:$PATH

COPY package.json package-lock.json ./
RUN npm install

COPY . ./
RUN ng build --configuration=${ANGULAR_ENVIRONMENT:-default}

CMD [ "ng", "serve", "--host", "0.0.0.0" ]
