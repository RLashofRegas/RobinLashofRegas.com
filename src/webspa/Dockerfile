FROM node:14 as node-build

ARG ANGULAR_ENVIRONMENT

WORKDIR /app
ENV PATH /app/node_modules/.bin:$PATH

COPY package.json package-lock.json ./
RUN npm install

COPY . ./

CMD ng serve --host 0.0.0.0 --configuration=${ANGULAR_ENVIRONMENT:-default}
