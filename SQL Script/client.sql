-- Secuencia para generar id de la tabla client

CREATE SEQUENCE client_seq
    START WITH 1
    INCREMENT BY 1
    MINVALUE 1
    MAXVALUE 999999999999999999999999999
    NOCYCLE
    NOCACHE
    NOORDER;

-- Tabla para almacenar los datos de la tabla client con id autogenerado por secuencia client_seq

CREATE TABLE client (
    id NUMBER DEFAULT client_seq.nextval,
    name VARCHAR2(50) NOT NULL,
    state NUMBER DEFAULT 1,
    CONSTRAINT client_pk PRIMARY KEY (id)
);