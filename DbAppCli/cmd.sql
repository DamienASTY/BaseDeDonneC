#crée la base de donnée banque
CREATE DATABASE banque;

#crée la table client
CREATE TABLE client (
    ID INT NOT NULL AUTO_INCREMENT,
    first_name VARCHAR(255),
    last_name VARCHAR(255),
    email VARCHAR(255),
    phone VARCHAR(255),
    PRIMARY KEY (ID)
);

#Commande qui insère des données dans la table
INSERT INTO client (first_name, last_name, email, phone) VALUES ('Alice', 'Dupont', 'alice.dupont@example.com', '0123456789');
INSERT INTO client (first_name, last_name, email, phone) VALUES ('Bob', 'Martin', 'bob.martin@example.com', '0987654321');
INSERT INTO client (first_name, last_name, email, phone) VALUES ('Charlie', 'Garcia', 'charlie.garcia@example.com', '0123456789');