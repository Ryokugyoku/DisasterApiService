-- 建造物種別
CREATE TABLE disasterschema.structure_type_table(
    struct_id serial PRIMARY KEY,
    struct_name varchar NOT NULL,
    struct_note varchar NOT NULL
);

-- 基底テーブル
CREATE TABLE disasterschema.organization_table(
    org_no serial PRIMARY KEY,
    org_name varchar NOT NULL,
    lon decimal NOT NULL,
    lat decimal NOT NULL,
    struct_id smallint NOT NULL,
    org_note varchar,
    org_tel varchar,
    CONSTRAINT fk_struct_id
        FOREIGN KEY (struct_id)
            REFERENCES structure_type_table(struct_id)
);

-- 指定避難所セクター
CREATE TABLE disasterschema.emergency_shelter_tsunami_table(
    org_no smallint NOT NULL ,
    CONSTRAINT fk_org_no
        FOREIGN KEY (org_no)
            REFERENCES structure_type_table(struct_id)
);

CREATE TABLE disasterschema.emergency_shelter_earthquake_table(
    org_no smallint NOT NULL ,
    CONSTRAINT fk_org_no
        FOREIGN KEY (org_no)
            REFERENCES structure_type_table(struct_id)
);


CREATE TABLE disasterschema.emergency_shelter_slide_table(
    org_no smallint NOT NULL ,
    CONSTRAINT fk_org_no
        FOREIGN KEY (org_no)
            REFERENCES structure_type_table(struct_id)
);

CREATE TABLE disasterschema.emergency_shelter_specified_table(
    org_no smallint NOT NULL ,
    CONSTRAINT fk_org_no
        FOREIGN KEY (org_no)
            REFERENCES structure_type_table(struct_id)
);

CREATE TABLE disasterschema.emergency_shelter_volcano_table(
    org_no smallint NOT NULL ,
    CONSTRAINT fk_org_no
        FOREIGN KEY (org_no)
            REFERENCES structure_type_table(struct_id)
);

-- 設備情報セクター
CREATE TABLE disasterschema.equipment_table(
    org_no smallint NOT NULL ,
    water_flg boolean,
    electricity_flg boolean,
    free_wifi_flg boolean,
    phone_net_flg boolean,
    air_conditioning_flg boolean,
    evacuation_count smallint,
    medical_system_flg boolean,
    gas_flg boolean,

    CONSTRAINT fk_org_no
        FOREIGN KEY (org_no)
            REFERENCES structure_type_table(struct_id)
);

