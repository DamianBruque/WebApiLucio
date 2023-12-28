-- Secuencia para generar id de la tabla seller

CREATE SEQUENCE seller_seq
    START WITH 1
    INCREMENT BY 1
    MINVALUE 1
    MAXVALUE 999999999999999999999999999
    NOCYCLE
    NOCACHE
    NOORDER;

-- Tabla para almacenar los datos de la tabla seller con id autogenerado por secuencia seller_seq

CREATE TABLE seller (
    id NUMBER DEFAULT seller_seq.nextval,
    name VARCHAR2(50) NOT NULL,
    user_id NUMBER NOT NULL,
    state NUMBER DEFAULT 1,
    CONSTRAINT seller_pk PRIMARY KEY (id),
    CONSTRAINT seller_user_fk FOREIGN KEY (user_id) REFERENCES User(id)
);

-- Stored procedure para insertar un dato en la tabla seller

CREATE OR REPLACE PROCEDURE seller_insert (name VARCHAR2) AS
BEGIN
    INSERT INTO seller (name) VALUES (name);
END;

-- Stored procedure para actualizar un dato de la tabla seller

CREATE OR REPLACE PROCEDURE seller_update (id NUMBER, name VARCHAR2) AS
BEGIN
    UPDATE seller SET name = name WHERE id = id;
END;

-- Stored procedure para eliminar un dato de la tabla seller

CREATE OR REPLACE PROCEDURE seller_delete (id NUMBER) AS
BEGIN
    DELETE FROM seller WHERE id = id;
END;

-- Stored procedure para obtener todos los datos de la tabla seller

CREATE OR REPLACE PROCEDURE seller_getall (sellers OUT SYS_REFCURSOR) AS
BEGIN
    OPEN sellers FOR SELECT * FROM seller;
END;

-- Stored procedure para obtener un dato de la tabla seller

CREATE OR REPLACE PROCEDURE seller_getbyid (id NUMBER, seller OUT SYS_REFCURSOR) AS
BEGIN
    OPEN seller FOR SELECT * FROM seller WHERE id = id;
END;

-- Stored procedure para obtener un dato de la tabla seller por nombre

CREATE OR REPLACE PROCEDURE seller_getbyname (name VARCHAR2, seller OUT SYS_REFCURSOR) AS
BEGIN
    OPEN seller FOR SELECT * FROM seller WHERE name = name;
END;


