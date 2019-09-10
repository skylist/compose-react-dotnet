FROM mongo
RUN mongo --eval "use boardDb" && mongo --eval("db.createCollection('tasks')")
EXPOSE 27017