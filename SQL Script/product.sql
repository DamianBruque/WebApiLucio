/*
/CreateProduct. Permite al vendedor crear un nuevo producto y ponerlo a la venta. Campos requeridos: nombre, codigo, precio y cantidad.
/DeleteProduct/{id}: Permite al vendedor eliminar un producto y sacarlo de la venta.Campos requeridos: código del producto.
/UpdateProduct: Permite al vendedor modificar un producto.
/GetProduct/{id} : Permite al vendedor/comprador obtener un producto en especifico. Campos requeridos: código del producto. Solo debe traer el producto si hay stock.
/GetAllProducts: Permite al comprador obtener todos los productos a la venta. Solo debe traer productos en stock.
*/

-- Secuencia para generar el id de la tabla product

CREATE SEQUENCE product_seq
    START WITH 1
    INCREMENT BY 1
    MINVALUE 1
    MAXVALUE 999999999999999999999999999
    NOCYCLE
    NOCACHE
    NOORDER;

-- Tabla para almacenar los datos de los productos con id autogenerado por secuencia product_seq

CREATE TABLE PRODUCT_API (
    id NUMBER DEFAULT product_seq.nextval,
    name VARCHAR2(50) NOT NULL UNIQUE,
    code VARCHAR2(50) NOT NULL UNIQUE,
    price NUMBER NOT NULL,
    stock NUMBER DEFAULT 0,
    state NUMBER DEFAULT 1,
    CONSTRAINT pk_product_id PRIMARY KEY (id)
);

-- Stored procedure para insertar un dato en la tabla product

CREATE OR REPLACE PROCEDURE product_insert (name VARCHAR2, code VARCHAR2, price NUMBER, quantity NUMBER) AS
BEGIN
    INSERT INTO PRODUCT_API (name, code, price,stock) VALUES (name, code, price, quantity);
END;

-- Stored procedure para actualizar un dato de la tabla product

CREATE OR REPLACE PROCEDURE product_update (id NUMBER, name VARCHAR2, code VARCHAR2, price NUMBER) AS
BEGIN
    UPDATE PRODUCT_API SET name = name, code = code, price = price WHERE id = id;
END;

-- Stored procedure para actualizar el stock sumando o restanto la cantidad de stock

CREATE OR REPLACE PROCEDURE product_updatestock (id NUMBER, quantity NUMBER) AS
BEGIN
    UPDATE PRODUCT_API SET stock = stock + quantity WHERE id = id;
END;

-- Stored procedure para eliminar un dato de la tabla product

CREATE OR REPLACE PROCEDURE product_delete (id NUMBER) AS
BEGIN
    DELETE FROM PRODUCT_API WHERE id = id;
END;

-- Stored procedure para obtener todos los datos de la tabla product

CREATE OR REPLACE PROCEDURE product_getall (products OUT SYS_REFCURSOR) AS
BEGIN
    OPEN products FOR SELECT * FROM PRODUCT_API;
END;

-- Stored procedure para obtener un dato de la tabla product

CREATE OR REPLACE PROCEDURE product_getbyid (id NUMBER, product OUT SYS_REFCURSOR) AS
BEGIN
    OPEN product FOR SELECT * FROM PRODUCT_API WHERE id = id;
END;

-- Stored procedure para obtener un dato de la tabla product por code

CREATE OR REPLACE PROCEDURE product_getbycode (code VARCHAR2, product OUT SYS_REFCURSOR) AS
BEGIN
    OPEN product FOR SELECT * FROM PRODUCT_API WHERE code = code;
END;

-- Stored procedure para obtener un dato de la tabla product por name

CREATE OR REPLACE PROCEDURE product_getbyname (name VARCHAR2, product OUT SYS_REFCURSOR) AS
BEGIN
    OPEN product FOR SELECT * FROM PRODUCT_API WHERE name LIKE ('%' || name || '%');
END;

-- Stored procedure para obtener los datos de la tabla product por rango de precio (min, max)

CREATE OR REPLACE PROCEDURE product_getbyprice (min NUMBER, max NUMBER, product OUT SYS_REFCURSOR) AS
BEGIN
    OPEN product FOR SELECT * FROM PRODUCT_API WHERE price BETWEEN min AND max;
END;

-- Stored procedure para obtener los datos de la tabla product que tengan por lo menos una cantidad de stock (quantity)

CREATE OR REPLACE PROCEDURE product_getallwithminsotck (quantity NUMBER, product OUT SYS_REFCURSOR) AS
BEGIN
    OPEN product FOR SELECT * FROM PRODUCT_API WHERE stock >= quantity;
END;


