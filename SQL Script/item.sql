-- Secuencia para generar id de la tabla product_seller

CREATE SEQUENCE item_seq
    START WITH 1
    INCREMENT BY 1
    MINVALUE 1
    MAXVALUE 999999999999999999999999999
    NOCYCLE
    NOCACHE
    NOORDER;

-- Tabla para almacenar los datos de la tabla product_seller con id autogenerado por secuencia product_seller_seq

CREATE TABLE item (
    id NUMBER DEFAULT item_seq.nextval,
    product_id NUMBER NOT NULL,
    quantity NUMBER DEFAULT 0 NOT NULL,
    total_price NUMBER DEFAULT 0 NOT NULL,
    purchase_id NUMBER NOT NULL,
    CONSTRAINT item_pk PRIMARY KEY (id),
    CONSTRAINT item_product_fk FOREIGN KEY (product_id) REFERENCES PRODUCT_API (id),
    CONSTRAINT item_purchase_fk FOREIGN KEY (purchase_id) REFERENCES purchase (id)
);