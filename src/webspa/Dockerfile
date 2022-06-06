FROM node:18 as node-build

ARG CODESPACE_NAME
ENV ANGULAR_CODESPACE_ENV=${CODESPACE_NAME:+codespace}

WORKDIR /app
ENV PATH /app/node_modules/.bin:$PATH

COPY package.json package-lock.json ./
RUN npm install

COPY . ./

# https://github.com/webpack/webpack/issues/14532
ENV NODE_OPTIONS=--openssl-legacy-provider

CMD ng serve --host 0.0.0.0 --configuration=${ANGULAR_CODESPACE_ENV:-default}
