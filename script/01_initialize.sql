CREATE DATABASE disaster;
\c disaster

CREATE SCHEMA disasterschema;

CREATE ROLE disasterapi WITH LOGIN PASSWORD 'rootApi';

GRANT ALL PRIVILEGES ON SCHEMA disasterschema TO disasterapi;
