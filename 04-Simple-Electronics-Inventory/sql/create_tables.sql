-- Run while connected to database: winforms_exercises

CREATE TABLE IF NOT EXISTS users (
    id SERIAL PRIMARY KEY,
    username VARCHAR(100) UNIQUE NOT NULL,
    password_hash TEXT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS products (
    id SERIAL PRIMARY KEY,
    name VARCHAR(150) NOT NULL,
    category VARCHAR(100) NOT NULL,
    price NUMERIC(10,2) NOT NULL,
    quantity INT NOT NULL,
    manufacture_date DATE NOT NULL DEFAULT CURRENT_DATE,
    expiry_date DATE NOT NULL DEFAULT (CURRENT_DATE + INTERVAL '2 years')
);

-- If you already created products WITHOUT the date columns, run this instead:
-- ALTER TABLE products ADD COLUMN IF NOT EXISTS manufacture_date DATE NOT NULL DEFAULT CURRENT_DATE;
-- ALTER TABLE products ADD COLUMN IF NOT EXISTS expiry_date DATE NOT NULL DEFAULT (CURRENT_DATE + INTERVAL '2 years');
