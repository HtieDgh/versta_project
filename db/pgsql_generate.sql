--
-- PostgreSQL database dump
--

-- Dumped from database version 18.6
-- Dumped by pg_dump version 18.6

-- Started on 2026-08-27 18:36:26

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 219 (class 1259 OID 16452)
-- Name: Cargo; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Cargo" (
    "ID" bigint CONSTRAINT "Order_ID_not_null" NOT NULL,
    "Weight" numeric CONSTRAINT "Order_Weight_not_null" NOT NULL
);


ALTER TABLE public."Cargo" OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 16461)
-- Name: Delivery; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Delivery" (
    "OrderID" bigint NOT NULL,
    "SenderID" bigint NOT NULL,
    "RecipientID" bigint NOT NULL,
    "Date" date,
    "CargoID" bigint
);


ALTER TABLE public."Delivery" OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 16469)
-- Name: Endpoint; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Endpoint" (
    "ID" bigint NOT NULL,
    "City" character varying(500) NOT NULL,
    "Address" character varying(500) NOT NULL
);


ALTER TABLE public."Endpoint" OWNER TO postgres;

--
-- TOC entry 225 (class 1259 OID 16501)
-- Name: Order; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Order" (
    "ID" bigint CONSTRAINT "Order_ID_not_null1" NOT NULL
);


ALTER TABLE public."Order" OWNER TO postgres;

--
-- TOC entry 224 (class 1259 OID 16500)
-- Name: Order_ID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Order_ID_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Order_ID_seq" OWNER TO postgres;

--
-- TOC entry 4950 (class 0 OID 0)
-- Dependencies: 224
-- Name: Order_ID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Order_ID_seq" OWNED BY public."Order"."ID";


--
-- TOC entry 226 (class 1259 OID 16519)
-- Name: cargo_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.cargo_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.cargo_id_seq OWNER TO postgres;

--
-- TOC entry 4951 (class 0 OID 0)
-- Dependencies: 226
-- Name: cargo_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.cargo_id_seq OWNED BY public."Cargo"."ID";


--
-- TOC entry 223 (class 1259 OID 16497)
-- Name: endpoint_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.endpoint_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.endpoint_id_seq OWNER TO postgres;

--
-- TOC entry 4952 (class 0 OID 0)
-- Dependencies: 223
-- Name: endpoint_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.endpoint_id_seq OWNED BY public."Endpoint"."ID";


--
-- TOC entry 222 (class 1259 OID 16496)
-- Name: order_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.order_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.order_id_seq OWNER TO postgres;

--
-- TOC entry 4953 (class 0 OID 0)
-- Dependencies: 222
-- Name: order_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.order_id_seq OWNED BY public."Order"."ID";


--
-- TOC entry 4770 (class 2604 OID 16520)
-- Name: Cargo ID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Cargo" ALTER COLUMN "ID" SET DEFAULT nextval('public.cargo_id_seq'::regclass);


--
-- TOC entry 4771 (class 2604 OID 16498)
-- Name: Endpoint ID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Endpoint" ALTER COLUMN "ID" SET DEFAULT nextval('public.endpoint_id_seq'::regclass);


--
-- TOC entry 4772 (class 2604 OID 16521)
-- Name: Order ID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Order" ALTER COLUMN "ID" SET DEFAULT nextval('public.order_id_seq'::regclass);


--
-- TOC entry 4937 (class 0 OID 16452)
-- Dependencies: 219
-- Data for Name: Cargo; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Cargo" ("ID", "Weight") FROM stdin;
\.


--
-- TOC entry 4938 (class 0 OID 16461)
-- Dependencies: 220
-- Data for Name: Delivery; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Delivery" ("OrderID", "SenderID", "RecipientID", "Date", "CargoID") FROM stdin;
\.


--
-- TOC entry 4939 (class 0 OID 16469)
-- Dependencies: 221
-- Data for Name: Endpoint; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Endpoint" ("ID", "City", "Address") FROM stdin;
\.


--
-- TOC entry 4943 (class 0 OID 16501)
-- Dependencies: 225
-- Data for Name: Order; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Order" ("ID") FROM stdin;
\.


--
-- TOC entry 4954 (class 0 OID 0)
-- Dependencies: 224
-- Name: Order_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Order_ID_seq"', 1, false);


--
-- TOC entry 4955 (class 0 OID 0)
-- Dependencies: 226
-- Name: cargo_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.cargo_id_seq', 1, true);


--
-- TOC entry 4956 (class 0 OID 0)
-- Dependencies: 223
-- Name: endpoint_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.endpoint_id_seq', 1, true);


--
-- TOC entry 4957 (class 0 OID 0)
-- Dependencies: 222
-- Name: order_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.order_id_seq', 1, true);


--
-- TOC entry 4774 (class 2606 OID 16460)
-- Name: Cargo Cargo_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Cargo"
    ADD CONSTRAINT "Cargo_pkey" PRIMARY KEY ("ID");


--
-- TOC entry 4776 (class 2606 OID 16468)
-- Name: Delivery Delivery_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Delivery"
    ADD CONSTRAINT "Delivery_pkey" PRIMARY KEY ("OrderID", "SenderID", "RecipientID");


--
-- TOC entry 4783 (class 2606 OID 16478)
-- Name: Endpoint Endpoint_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Endpoint"
    ADD CONSTRAINT "Endpoint_pkey" PRIMARY KEY ("ID");


--
-- TOC entry 4785 (class 2606 OID 16507)
-- Name: Order Order_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Order"
    ADD CONSTRAINT "Order_pkey" PRIMARY KEY ("ID");


--
-- TOC entry 4777 (class 1259 OID 16513)
-- Name: fki_FK_Cargo_Delivery; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_FK_Cargo_Delivery" ON public."Delivery" USING btree ("CargoID");


--
-- TOC entry 4778 (class 1259 OID 16541)
-- Name: fki_FK_Endpoint_rid_Delivery; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_FK_Endpoint_rid_Delivery" ON public."Delivery" USING btree ("RecipientID");


--
-- TOC entry 4779 (class 1259 OID 16547)
-- Name: fki_FK_Endpoint_sid_Delivery; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_FK_Endpoint_sid_Delivery" ON public."Delivery" USING btree ("SenderID");


--
-- TOC entry 4780 (class 1259 OID 16484)
-- Name: fki_FK_Order_Delivery; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_FK_Order_Delivery" ON public."Delivery" USING btree ("OrderID");


--
-- TOC entry 4781 (class 1259 OID 16490)
-- Name: fki_K; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_K" ON public."Delivery" USING btree ("SenderID");


--
-- TOC entry 4786 (class 2606 OID 16553)
-- Name: Delivery FK_Cargo_Delivery; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Delivery"
    ADD CONSTRAINT "FK_Cargo_Delivery" FOREIGN KEY ("CargoID") REFERENCES public."Cargo"("ID") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4787 (class 2606 OID 16536)
-- Name: Delivery FK_Endpoint_rid_Delivery; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Delivery"
    ADD CONSTRAINT "FK_Endpoint_rid_Delivery" FOREIGN KEY ("RecipientID") REFERENCES public."Endpoint"("ID") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4788 (class 2606 OID 16542)
-- Name: Delivery FK_Endpoint_sid_Delivery; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Delivery"
    ADD CONSTRAINT "FK_Endpoint_sid_Delivery" FOREIGN KEY ("SenderID") REFERENCES public."Endpoint"("ID") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4789 (class 2606 OID 16548)
-- Name: Delivery FK_Order_Delivery; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Delivery"
    ADD CONSTRAINT "FK_Order_Delivery" FOREIGN KEY ("OrderID") REFERENCES public."Order"("ID") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


-- Completed on 2026-08-27 18:36:26

--
-- PostgreSQL database dump complete
--
