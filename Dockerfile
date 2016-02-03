# NOTE: we are using aspnet coreclr bits here

FROM microsoft/aspnet:1.0.0-rc1-update1-coreclr

RUN printf "deb http://ftp.us.debian.org/debian jessie main\n" >> /etc/apt/sources.list
RUN apt-get -qq update && apt-get install -qqy sqlite3 libsqlite3-dev && rm -rf /var/lib/apt/lists/*
# add another update ?
RUN apt-get -qq update

COPY . /app
WORKDIR /app
RUN ["dnu", "restore"]

EXPOSE 8081/tcp
ENTRYPOINT ["dnx", "-p", "project.json", "web"]