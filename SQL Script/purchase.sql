-- Secuencia para generar id de la tabla purchase

CREATE SEQUENCE purchase_seq
    START WITH 1
    INCREMENT BY 1
    MINVALUE 1
    MAXVALUE 999999999999999999999999999
    NOCYCLE
    NOCACHE
    NOORDER;

-- Tabla para almacenar los datos de la tabla purchase con id autogenerado por secuencia purchase_seq

CREATE TABLE purchase (
    id NUMBER DEFAULT purchase_seq.nextval,
    seller_id NUMBER NOT NULL,
    client_id NUMBER NOT NULL,
    CONSTRAINT purchase_pk PRIMARY KEY (id),
    CONSTRAINT purchase_seller_fk FOREIGN KEY (seller_id) REFERENCES seller (id),
    CONSTRAINT purchase_client_fk FOREIGN KEY (client_id) REFERENCES client (id)
);
