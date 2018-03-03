CREATE TABLE gerb.food (
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL UNIQUE
);

INSERT INTO ops (op) VALUES ('migration V0002__Add_Food.sql');