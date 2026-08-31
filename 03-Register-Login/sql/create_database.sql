-- Run this script in PostgreSQL (pgAdmin, psql, or any SQL client)
-- to create the database and users table for the Register/Login exercise.

-- 1. Create the database (run this while connected to the default 'postgres' database)
CREATE DATABASE winforms_exercises;

-- 2. Connect to winforms_exercises, then create the table:

CREATE TABLE IF NOT EXISTS users (
    id SERIAL PRIMARY KEY,
    username VARCHAR(100) UNIQUE NOT NULL,
    password_hash TEXT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
