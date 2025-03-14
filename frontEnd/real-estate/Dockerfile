# Build aşaması
FROM node:19.3.0-alpine as build

WORKDIR /app

# package.json ve package-lock.json'ı kopyala
COPY package.json package-lock.json ./

# Bağımlılıkları yükle
RUN npm install

# Tüm proje dosyalarını kopyala
COPY . ./

# Production build'i oluştur
RUN npm run build

# Production aşaması
FROM nginx:stable-alpine

# Nginx konfigürasyon dosyasını kopyala
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Build edilmiş dosyaları Nginx'in html dizinine kopyala
COPY --from=build /app/build /usr/share/nginx/html

# 3000 portunu aç
EXPOSE 3000

# Nginx'i başlat
CMD ["nginx", "-g", "daemon off;"]