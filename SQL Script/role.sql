-- Secuencia para generar id de la tabla role
CREATE SEQUENCE role_seq
    START WITH 1
    INCREMENT BY 1
    MINVALUE 1
    MAXVALUE 999999999999999999999999999
    NOCYCLE
    NOCACHE
    NOORDER;
    
-- Tabla role con id autogenerado por secuencia role_seq

CREATE TABLE Role (
    id NUMBER DEFAULT role_seq.nextval,
    name VARCHAR2(50) NOT NULL UNIQUE,
    description VARCHAR2(255) NOT NULL,
    state NUMBER DEFAULT 1,
    CONSTRAINT pk_role PRIMARY KEY (id)
);

-- Insertar datos en la tabla role

INSERT INTO Role (name, description) VALUES ('Admin', 'Administrador');
INSERT INTO Role (name, description) VALUES ('User', 'Usuario');

-- Stored procedure para insertar datos en la tabla role

CREATE OR REPLACE PROCEDURE ROLE_INSERT
(
  NAME IN VARCHAR2 
, DESCRIPTION IN VARCHAR2 
) AS 
BEGIN
  NULL;
END ROLE_INSERT;

-- Stored procedure para actualizar datos en la tabla role

CREATE OR REPLACE PROCEDURE role_update (id NUMBER, name VARCHAR2, description VARCHAR2) AS
BEGIN
    UPDATE Role SET name = name, description = description WHERE id = id;
END;

-- Stored procedure para eliminar datos en la tabla role

CREATE OR REPLACE PROCEDURE role_delete (id NUMBER) AS
BEGIN
    DELETE FROM Role WHERE id = id;
END;

-- Stored procedure para obtener todos los datos de la tabla role

CREATE OR REPLACE PROCEDURE role_getall (roles OUT SYS_REFCURSOR) AS
BEGIN
    OPEN roles FOR SELECT * FROM Role;
END;

-- Stored procedure para obtener un dato de la tabla role

CREATE OR REPLACE PROCEDURE role_getbyid (id NUMBER, role OUT SYS_REFCURSOR) AS
BEGIN
    OPEN role FOR SELECT * FROM Role WHERE id = id;
END;

-- Stored procedure para obtener un dato de la tabla role por nombre

CREATE OR REPLACE PROCEDURE role_getbyname (name VARCHAR2, role OUT SYS_REFCURSOR) AS
BEGIN
    OPEN role FOR SELECT * FROM Role WHERE LOWER(name) = LOWER(name);
END;




















-- Secuencia para generar id de la tabla user
CREATE SEQUENCE user_seq
    START WITH 1
    INCREMENT BY 1
    MINVALUE 1
    MAXVALUE 999999999999999999999999999
    NOCYCLE
    NOCACHE
    NOORDER;


-- Tabla user con id autogenerado por secuencia user_seq

CREATE TABLE User (
    id NUMBER DEFAULT user_seq.nextval,
    name VARCHAR2(50) NOT NULL,
    email VARCHAR2(50) NOT NULL UNIQUE,
    password VARCHAR2(255) NOT NULL,
    role_id NUMBER NOT NULL,
    CONSTRAINT pk_user PRIMARY KEY (id),
    CONSTRAINT fk_user_role FOREIGN KEY (role_id) REFERENCES Role (id)
);