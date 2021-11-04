db = db.getSiblingDB('prjctr')

db.createUser(
{
    user: "admin",
    pwd: "admin",
    roles: [
        {
            role: "readWrite",
            db: "prjctr"
        },
        {
            role: "readWrite",
            db: "admin"
        }
    ]
});