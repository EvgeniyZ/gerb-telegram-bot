CREATE SCHEMA gerb;

CREATE TABLE gerb.diet (
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL UNIQUE
);

INSERT INTO ops (op) VALUES ('migration V0001__Initial_Schema_gerb.sql');