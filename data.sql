--
-- PostgreSQL database dump
--

-- Dumped from database version 17.5
-- Dumped by pg_dump version 17.5

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

--
-- Data for Name: AspNetRoles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetRoles" ("Id", "Name", "NormalizedName", "ConcurrencyStamp") FROM stdin;
\.


--
-- Data for Name: AspNetRoleClaims; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetRoleClaims" ("Id", "RoleId", "ClaimType", "ClaimValue") FROM stdin;
\.


--
-- Data for Name: AspNetUsers; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetUsers" ("Id", "LastLoginTime", "IsBlocked", "RegistrationTime", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount", "Name") FROM stdin;
91ffb972-b7c0-4e97-9189-86bdc308c9c1	2025-05-30 16:16:30.50317+04	f	2025-05-30 16:16:30.50317+04	test9@test.com	TEST9@TEST.COM	test9@test.com	TEST9@TEST.COM	f	AQAAAAIAAYagAAAAEDK5XXyDokKg/9Sb8tq6Qyxm7Vq6IO7BCouEYy2wQV7bPoEO//o8JKXmquEGtEZ8lA==	AAURS5F4L5CK57CXVISEVTUIYJINDSCQ	27f4e482-8e12-4f8c-a7cc-87d3f3bc3f1d	\N	f	f	\N	t	0	test9
e3a7a84e-2b6e-4634-bab1-1eca87bfeae5	2025-05-30 17:09:05.285421+04	f	2025-05-30 17:09:05.285391+04	test135@test.com	TEST135@TEST.COM	test135@test.com	TEST135@TEST.COM	f	AQAAAAIAAYagAAAAEPQQ8WqOz4ys2wUezDU4XSgBdfFLMyMGh5mCCXBfa+lMnMalUlF0HW6VP0nt39733w==	AYEPTP5KFKCRPCTII2ZP654HB5LFEXDX	49a2e000-194d-4909-82f1-9b5ce8dd2476	\N	f	f	\N	t	0	test135
715e0d1d-c517-4f84-aee6-413fb58333ae	2025-05-30 18:24:15.463026+04	f	2025-05-30 18:24:15.463026+04	test15@test.com	TEST15@TEST.COM	test15@test.com	TEST15@TEST.COM	f	AQAAAAIAAYagAAAAEMxvpBSIYhuUfI6NgWoiZ+u10ooRonrEndk6AWBiw0tbEinuFTR+nk4c42awXmYk5Q==	HO7DDETRG6LJCDZBGFUBOHTU7MZCS2NA	3a02bba2-bebc-4828-a81f-a93406f81b04	\N	f	f	\N	t	0	test15
9ad4cdd4-56c8-42a7-b17b-0b3a4ce8df07	2025-05-30 16:16:58.103491+04	f	2025-05-30 16:16:58.103491+04	test321@test.com	TEST321@TEST.COM	test321@test.com	TEST321@TEST.COM	f	AQAAAAIAAYagAAAAEJM9CH/WwM1/iNEjb5IIs2g2hKeTTU9cD0gdNNh1iQZ8UVJ8D0Ru+hmOUxVOwxVXPw==	5EKEKLWNIPGUNFGQV2BDNESHP4RCY3YW	c48ade12-429f-4f61-9744-fbd541ab5ab7	\N	f	f	\N	t	0	test321
968d8d9f-ef62-4041-9ea9-d2dfb41baa2e	2025-05-29 20:23:17.846111+04	f	2025-05-29 20:23:17.846081+04	test6@test.com	TEST6@TEST.COM	test6@test.com	TEST6@TEST.COM	f	AQAAAAIAAYagAAAAEC7T1fT0KodMbAsih2ZAxgs/gDKuRrvmWWHqe2TIQ7MtDwwgRRoYrZj5xdGu9+ME3A==	6CE27F4DM25ZHJMDYCP7PND6PQON3YCE	b78b61ac-1c33-415d-a84b-a8ceaf27cf04	\N	f	f	\N	t	0	test6@test.com
204a8f15-7258-40e6-bfcc-0283c150779c	2025-05-28 20:46:04.646713+04	f	2025-05-27 20:54:57.243382+04	test2@test.com	TEST2@TEST.COM	test2@test.com	TEST2@TEST.COM	f	AQAAAAIAAYagAAAAEMCaWQI9XBZceXiECsJtA1ogYxtWg4pouAb/RHYIyoFnIYs3CRTtfUZnDphI3BAehQ==	LVLZTZPW4N4H2H5FAUYAH4KKUJO46APQ	f585a1a9-2cd3-496b-b6b4-bbd6da97f6af	\N	f	f	\N	t	0	TestUser
299a54c2-535c-4432-9f4b-3a966dccef17	2025-05-30 16:13:25.953407+04	f	2025-05-30 16:13:25.953406+04	test7@test.com	TEST7@TEST.COM	test7@test.com	TEST7@TEST.COM	f	AQAAAAIAAYagAAAAEHgrZDzpHUXkqsQMyaNaLn1EZ1LYdFaYHNm3SOqPoTYgymxFKoL0YQZalhdFouk4GA==	P5T4PQPVT73YO5J6UNOTRINWWW3P3LOG	169f22c4-25a1-4b51-8e7b-98db656954d1	\N	f	f	\N	t	0	test7
2f981a0f-b906-464a-b81f-7c7e7358ff07	2025-05-29 13:23:09.199018+04	f	2025-05-29 13:10:05.167145+04	test5@test.com	TEST5@TEST.COM	test5@test.com	TEST5@TEST.COM	f	AQAAAAIAAYagAAAAENKPZSYIkNQd5SMVq+jdiLn6dQQYFcbkf3rJYcoTj0U5zNFslxzolV+8jHuZmKQzPA==	3DDMVCA7FROVID7GGEM7H4ELW2AYBSPA	78bffef1-418a-453a-a769-2a6536f765fa	\N	f	f	\N	t	0	test5
1e4f4d04-b8be-4822-a3b7-e4373ecc116e	2025-05-30 16:15:56.06088+04	f	2025-05-30 16:15:56.06088+04	test8@test.com	TEST8@TEST.COM	test8@test.com	TEST8@TEST.COM	f	AQAAAAIAAYagAAAAEAqtlARCd3fojt//u6KEjI5TXWbZL2JL0BXK/Ms+LWQhmkL7l9cuBrxySiozCEYG2Q==	4V2QSR3ZB3T3OOSM3HXJNTVUPSQVLEF4	7e02fcce-d5df-4d0e-8a80-fa215f22c907	\N	f	f	\N	t	0	test8
8c8fc980-cd5f-43b5-95eb-69d8379b84bd	2025-05-30 16:10:56.224547+04	f	2025-05-30 16:10:56.224519+04	test12@test.com	TEST12@TEST.COM	test12@test.com	TEST12@TEST.COM	f	AQAAAAIAAYagAAAAEPx5Om8lPPSYLxlhIWVGAuSo6XC4hWi9oGTOHjJSBIxu8nZzBi5m8oZWaLEtwyYQBA==	QH65PMZXLTXWUWBW4WLVV22XDHNEPMQ6	0bbb64f0-f1f3-45b5-9b41-ffa1d1fcec46	\N	f	f	\N	t	0	test12
553db896-e83f-4353-8d4a-1dc44ad1d181	2025-05-30 16:17:52.312237+04	f	2025-05-30 16:17:52.312237+04	testtest@test.com	TESTTEST@TEST.COM	testtest@test.com	TESTTEST@TEST.COM	f	AQAAAAIAAYagAAAAEJJ3M4rIOP6E4WDByygNA381n9OKQy/8nlPTY/v0/S2lKV85hqisjZKkwJ8839EbJQ==	DGMSPBRQYKP4C25RR7NJRVS4KMTFCITL	df59d2ab-ebfa-46f0-9d13-b75c384cc4d1	\N	f	f	\N	t	0	testtest
18b909b1-ff55-4198-b6fb-f41585acc2d1	2025-05-30 21:14:24.165143+04	f	2025-05-30 21:14:24.165143+04	test55@test.com	TEST55@TEST.COM	test55@test.com	TEST55@TEST.COM	f	AQAAAAIAAYagAAAAEI0hmeqQr+rAVuI2MUWmLd+o4ULlfcbqxPCv4HinKGv/97CxVD7/02N9iprJlbn4zg==	NHSZDTZKGBZZIP7U7TGHDIF3O3E4CJL4	9b642141-ba62-418f-a714-bfa6fa90207b	\N	f	f	\N	t	0	test55
6e39f04e-7d9c-4835-9db9-fb597e05c76c	2025-05-30 18:22:58.480976+04	f	2025-05-30 18:22:58.480947+04	lasttest@test.com	LASTTEST@TEST.COM	lasttest@test.com	LASTTEST@TEST.COM	f	AQAAAAIAAYagAAAAEHvuPjPIo2XMEkQwpUd3SRYaFD2GyAcPSj6nt8ZjTzbsqhLc7b/A0EzGixBJWkXzNQ==	NML4FA3PIWBVF6VZPLIBTS3OLRLQ55Q5	aa59d940-d66d-40df-ad66-af6f3aa454d3	\N	f	f	\N	t	0	lasttest
ad5a60de-f444-4bb3-a233-b1639569cdc6	2025-05-30 21:13:59.346463+04	f	2025-05-27 19:10:56.613184+04	test@test.com	TEST@TEST.COM	test@test.com	TEST@TEST.COM	f	AQAAAAIAAYagAAAAEJhgRjWfPIdWYZlEoia5hIvDeUPs/2qKtFU9//qbodPphjfeyojOhbQsQQdpEHavmg==	DQZR2KSFMVDJIKKUC6NDWUSHSPRVFNLX	16f3f8ca-f801-43c8-823d-bfcf4d05e292	\N	f	f	\N	t	0	\N
ccee28ea-f17f-49fe-b781-7af809800275	2025-05-28 19:40:43.134385+04	f	2025-05-28 19:40:43.134355+04	test3@test.com	TEST3@TEST.COM	test3@test.com	TEST3@TEST.COM	f	AQAAAAIAAYagAAAAEOpEclbEOef1iAnlSCbtWFKzhrqvSuG3igoGaYLZPPFO7/CiJvPMW62BRTCiT/9UFQ==	P2M5DUQCZDTSCMYMXKYDO72ET3OQ54VH	86a4d75c-43da-443b-9902-596867b51b7a	\N	f	f	\N	t	0	test3
4c08484f-1168-425a-b542-27211c877295	2025-05-30 17:37:24.465778+04	f	2025-05-30 17:37:24.465778+04	test666@test.com	TEST666@TEST.COM	test666@test.com	TEST666@TEST.COM	f	AQAAAAIAAYagAAAAENdC5iJ6gDDnJ9Wk7x2DHaZVu/AjovPYVsV/CW2/eiAFM4l6rRHPUQ/k7opsraqv8Q==	4CN4OH7YPSYG2KCMLRUI3VEZMXZVTKJW	dd392b90-f133-4237-a32a-ddced507a1e9	\N	f	f	\N	t	0	test666
\.


--
-- Data for Name: AspNetUserClaims; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetUserClaims" ("Id", "UserId", "ClaimType", "ClaimValue") FROM stdin;
\.


--
-- Data for Name: AspNetUserLogins; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetUserLogins" ("LoginProvider", "ProviderKey", "ProviderDisplayName", "UserId") FROM stdin;
\.


--
-- Data for Name: AspNetUserRoles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetUserRoles" ("UserId", "RoleId") FROM stdin;
\.


--
-- Data for Name: AspNetUserTokens; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetUserTokens" ("UserId", "LoginProvider", "Name", "Value") FROM stdin;
\.


--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20250527122415_InitialCreate	9.0.5
20250527164052_AddNameToUser	9.0.5
20250527164101_AddUniqueEmailIndex	9.0.5
\.


--
-- Name: AspNetRoleClaims_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."AspNetRoleClaims_Id_seq"', 1, false);


--
-- Name: AspNetUserClaims_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."AspNetUserClaims_Id_seq"', 1, false);


--
-- PostgreSQL database dump complete
--

