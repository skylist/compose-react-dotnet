FROM node:alpine AS builder
WORKDIR /app
COPY . .
RUN npm install && npm run build

FROM m4rcu5/lighttpd
WORKDIR /var/www/localhost/htdocs
COPY --from=builder /app/build .

EXPOSE 80