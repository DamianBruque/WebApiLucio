-- Secuencia para generar id de la tabla user

CREATE SEQUENCE user_seq
    START WITH 1
    INCREMENT BY 1
    MINVALUE 1
    MAXVALUE 999999999999999999999999999
    NOCYCLE
    NOCACHE
    NOORDER;

-- Tabla para almacenar los datos de los usuarios con id autogenerado por secuencia user_seq

CREATE TABLE USER_API (
    id NUMBER DEFAULT user_seq.nextval,
    email VARCHAR2(50) NOT NULL UNIQUE,
    password VARCHAR2(50) NOT NULL,
    role_id NUMBER,
    state NUMBER DEFAULT 1,
    CONSTRAINT pk_user_id PRIMARY KEY (id),
    CONSTRAINT fk_role_id FOREIGN KEY (role_id) REFERENCES Role(id)
);

-- Stored procedure para insertar un dato en la tabla user

CREATE OR REPLACE PROCEDURE user_insert (email VARCHAR2, password VARCHAR2, role_id NUMBER) AS
BEGIN
    INSERT INTO USER_API (email, password, role_id) VALUES (email, password, role_id);
END;

-- Stored procedure para actualizar un dato de la tabla user

CREATE OR REPLACE PROCEDURE user_update (id NUMBER, email VARCHAR2, password VARCHAR2, role_id NUMBER) AS
BEGIN
    UPDATE USER_API SET email = email, password = password, role_id = role_id WHERE id = id;
END;

-- Stored procedure para eliminar un dato de la tabla user

CREATE OR REPLACE PROCEDURE user_delete (id NUMBER) AS
BEGIN
    DELETE FROM USER_API WHERE id = id;
END;

-- Stored procedure para obtener todos los datos de la tabla user

CREATE OR REPLACE PROCEDURE user_getall (users OUT SYS_REFCURSOR) AS
BEGIN
    OPEN users FOR SELECT * FROM USER_API;
END;

-- Stored procedure para obtener un dato de la tabla user

CREATE OR REPLACE PROCEDURE user_getbyid (id NUMBER, user OUT SYS_REFCURSOR) AS
BEGIN
    OPEN user FOR SELECT * FROM USER_API WHERE id = id;
END;

-- Stored procedure para obtener un dato de la tabla user por email

CREATE OR REPLACE PROCEDURE user_getbyemail (email VARCHAR2, user OUT SYS_REFCURSOR) AS
BEGIN
    OPEN user FOR SELECT * FROM USER_API WHERE email = email;
END;





