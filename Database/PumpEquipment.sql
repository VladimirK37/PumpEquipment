PGDMP                         |            PumpEquipment    15.4    15.4                0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    16674    PumpEquipment    DATABASE     �   CREATE DATABASE "PumpEquipment" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "PumpEquipment";
             	   user_vova    false            �            1259    16680 	   Materials    TABLE     w   CREATE TABLE public."Materials" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "Description" text NOT NULL
);
    DROP TABLE public."Materials";
       public         heap 	   user_vova    false            �            1259    16687    Motors    TABLE       CREATE TABLE public."Motors" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "Power" integer NOT NULL,
    "Current" integer NOT NULL,
    "NominalSpeed" integer NOT NULL,
    "Motor" text NOT NULL,
    "Description" text NOT NULL,
    "Price" numeric NOT NULL
);
    DROP TABLE public."Motors";
       public         heap 	   user_vova    false            �            1259    16694    Pumps    TABLE     ~  CREATE TABLE public."Pumps" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "MaxPressure" double precision NOT NULL,
    "Temperature" double precision NOT NULL,
    "Weight" double precision NOT NULL,
    "Description" text NOT NULL,
    "Picture" text,
    "Price" numeric NOT NULL,
    "MotorId" uuid NOT NULL,
    "MaterialHullId" uuid,
    "ImpellerMaterialId" uuid
);
    DROP TABLE public."Pumps";
       public         heap 	   user_vova    false            �            1259    16675    __EFMigrationsHistory    TABLE     �   CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);
 +   DROP TABLE public."__EFMigrationsHistory";
       public         heap 	   user_vova    false                      0    16680 	   Materials 
   TABLE DATA           B   COPY public."Materials" ("Id", "Name", "Description") FROM stdin;
    public       	   user_vova    false    215                    0    16687    Motors 
   TABLE DATA           u   COPY public."Motors" ("Id", "Name", "Power", "Current", "NominalSpeed", "Motor", "Description", "Price") FROM stdin;
    public       	   user_vova    false    216   �                 0    16694    Pumps 
   TABLE DATA           �   COPY public."Pumps" ("Id", "Name", "MaxPressure", "Temperature", "Weight", "Description", "Picture", "Price", "MotorId", "MaterialHullId", "ImpellerMaterialId") FROM stdin;
    public       	   user_vova    false    217                    0    16675    __EFMigrationsHistory 
   TABLE DATA           R   COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
    public       	   user_vova    false    214   �       s           2606    16686    Materials PK_Materials 
   CONSTRAINT     Z   ALTER TABLE ONLY public."Materials"
    ADD CONSTRAINT "PK_Materials" PRIMARY KEY ("Id");
 D   ALTER TABLE ONLY public."Materials" DROP CONSTRAINT "PK_Materials";
       public         	   user_vova    false    215            u           2606    16693    Motors PK_Motors 
   CONSTRAINT     T   ALTER TABLE ONLY public."Motors"
    ADD CONSTRAINT "PK_Motors" PRIMARY KEY ("Id");
 >   ALTER TABLE ONLY public."Motors" DROP CONSTRAINT "PK_Motors";
       public         	   user_vova    false    216            z           2606    16700    Pumps PK_Pumps 
   CONSTRAINT     R   ALTER TABLE ONLY public."Pumps"
    ADD CONSTRAINT "PK_Pumps" PRIMARY KEY ("Id");
 <   ALTER TABLE ONLY public."Pumps" DROP CONSTRAINT "PK_Pumps";
       public         	   user_vova    false    217            q           2606    16679 .   __EFMigrationsHistory PK___EFMigrationsHistory 
   CONSTRAINT     {   ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");
 \   ALTER TABLE ONLY public."__EFMigrationsHistory" DROP CONSTRAINT "PK___EFMigrationsHistory";
       public         	   user_vova    false    214            v           1259    16716    IX_Pumps_ImpellerMaterialId    INDEX     a   CREATE INDEX "IX_Pumps_ImpellerMaterialId" ON public."Pumps" USING btree ("ImpellerMaterialId");
 1   DROP INDEX public."IX_Pumps_ImpellerMaterialId";
       public         	   user_vova    false    217            w           1259    16717    IX_Pumps_MaterialHullId    INDEX     Y   CREATE INDEX "IX_Pumps_MaterialHullId" ON public."Pumps" USING btree ("MaterialHullId");
 -   DROP INDEX public."IX_Pumps_MaterialHullId";
       public         	   user_vova    false    217            x           1259    16718    IX_Pumps_MotorId    INDEX     K   CREATE INDEX "IX_Pumps_MotorId" ON public."Pumps" USING btree ("MotorId");
 &   DROP INDEX public."IX_Pumps_MotorId";
       public         	   user_vova    false    217            {           2606    16701 +   Pumps FK_Pumps_Materials_ImpellerMaterialId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Pumps"
    ADD CONSTRAINT "FK_Pumps_Materials_ImpellerMaterialId" FOREIGN KEY ("ImpellerMaterialId") REFERENCES public."Materials"("Id");
 Y   ALTER TABLE ONLY public."Pumps" DROP CONSTRAINT "FK_Pumps_Materials_ImpellerMaterialId";
       public       	   user_vova    false    215    3187    217            |           2606    16706 '   Pumps FK_Pumps_Materials_MaterialHullId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Pumps"
    ADD CONSTRAINT "FK_Pumps_Materials_MaterialHullId" FOREIGN KEY ("MaterialHullId") REFERENCES public."Materials"("Id");
 U   ALTER TABLE ONLY public."Pumps" DROP CONSTRAINT "FK_Pumps_Materials_MaterialHullId";
       public       	   user_vova    false    215    217    3187            }           2606    16711    Pumps FK_Pumps_Motors_MotorId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Pumps"
    ADD CONSTRAINT "FK_Pumps_Motors_MotorId" FOREIGN KEY ("MotorId") REFERENCES public."Motors"("Id") ON DELETE CASCADE;
 K   ALTER TABLE ONLY public."Pumps" DROP CONSTRAINT "FK_Pumps_Motors_MotorId";
       public       	   user_vova    false    216    217    3189               �   x�}�=jA��S�
������hf�vR,�!��.R�56	�a�+H7�\�ƈ�����@57[��4fW �9C)�(��bJ����G�;~�����G�YV|��g����������!���k4F��{@��E&���<�A5�L���	e��_{@�$J	0xj�9kG�x˟�M�z�����O��ώ�N�]l�yֹ�nǘ�1����           x���MJC1�q�*��+�M�M2�g�@��N�j�8qnA,h�]C�#�*u$:��s9|��T3p0��AW��	Ѱ)�(q5����.j^(��3�!���߷}۶}諾j�����ڞۮ��۬����x��*Y%��
,�2�N������%#��<$�<&��I4hsr1��9�q���X� 򒫪_+υR$����!�7T�4��LU�$���b�y&�P(�(�S_��K۵��"Ob��ju�8�FrgR�L>k��8��@��i�H�d^���"��*         �  x���KnV1�ǹ����cg�k�X@'q3$&�)�2b� !*
�-���?������QrN>���z��r(�F��ѱ���޼�x�[����j�^?m����|�������n��f��?��~�~\���r'ޯ�K�m���Ü9R�y�`Щ�Ľ�0��|�"�}��� ��A�BkMUROR�FQ��E�	��E�4��3r;'x�"�h)�|6�7��d�C�}��4�y/p������@!>��Rnܚ�Y#����J���XjeI� O]�V��#�{~z��83�ăh!�5�$�8n���r�&�w�K�6�:{J1=$���2k<@��u)iŘ�3>3�.��H��dN�h��Jbe�̩k �C��R�P!q5��m�L���=i���Uz钷2����8�C}x���m��7T�N         (   x�320210343�411�����,�4�3�36����� t��     