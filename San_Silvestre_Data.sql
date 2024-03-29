USE [SanSilvestre]
GO
SET IDENTITY_INSERT [dbo].[Competition] ON 

INSERT [dbo].[Competition] ([Id], [Name], [Description], [Year]) VALUES (1, N'San Silvestre', N'San Silvestre Villa de Mora 2019', 2019)
SET IDENTITY_INSERT [dbo].[Competition] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name]) VALUES (1, N'Especial')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (2, N'Mini Benjamin')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (3, N'Benjamin')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (4, N'Alevin')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (5, N'Infantil')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (6, N'Cadete')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (7, N'Junior')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (8, N'Senior')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (9, N'Veteranos A')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (10, N'Absoluta')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (11, N'Veteranos B')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (12, N'Veteranas')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (21, N'General')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (22, N'Local')
SET IDENTITY_INSERT [dbo].[Category] OFF
INSERT [dbo].[Gender] ([Id], [Name]) VALUES (N'F', N'Femenino')
INSERT [dbo].[Gender] ([Id], [Name]) VALUES (N'M', N'Masculio')
INSERT [dbo].[DocumentType] ([Id], [Name]) VALUES (1, N'DNI')
INSERT [dbo].[DocumentType] ([Id], [Name]) VALUES (2, N'NIE')
SET IDENTITY_INSERT [dbo].[Runner] ON 

INSERT [dbo].[Runner] ([Id], [Name], [SurName], [YearBirthday], [DocumentTypeId], [DNI], [Email], [Telephone], [PostalCode], [IsLocalRunner], [GenderId], [Club]) VALUES (48, N'Mayca', N'Navarro Moreno', 1973, 1, N'03861881C', N'mayca.navarro@gmail.com', 925341899, 45400, 1, N'F', N'Independiente')
INSERT [dbo].[Runner] ([Id], [Name], [SurName], [YearBirthday], [DocumentTypeId], [DNI], [Email], [Telephone], [PostalCode], [IsLocalRunner], [GenderId], [Club]) VALUES (49, N'Hugo', N'Ramirez Navarro', 2003, 1, N'70300759V', N'hugo.ramirez@gmail.com', 925341899, 45400, 1, N'M', NULL)
INSERT [dbo].[Runner] ([Id], [Name], [SurName], [YearBirthday], [DocumentTypeId], [DNI], [Email], [Telephone], [PostalCode], [IsLocalRunner], [GenderId], [Club]) VALUES (50, N'Jorge', N'Ramirez Gutierrez', 2003, 1, N'70300969C', NULL, NULL, NULL, 1, N'M', N'Ramirez')
INSERT [dbo].[Runner] ([Id], [Name], [SurName], [YearBirthday], [DocumentTypeId], [DNI], [Email], [Telephone], [PostalCode], [IsLocalRunner], [GenderId], [Club]) VALUES (51, N'David', N'Ramirez Menchero', 1974, 1, N'70350627K', NULL, NULL, NULL, 1, N'M', N'Ramirez')
INSERT [dbo].[Runner] ([Id], [Name], [SurName], [YearBirthday], [DocumentTypeId], [DNI], [Email], [Telephone], [PostalCode], [IsLocalRunner], [GenderId], [Club]) VALUES (52, N'Carlos', N'Martin Nuñez', 1968, 1, N'70345955H', NULL, NULL, NULL, 1, N'M', N'Almazara')
INSERT [dbo].[Runner] ([Id], [Name], [SurName], [YearBirthday], [DocumentTypeId], [DNI], [Email], [Telephone], [PostalCode], [IsLocalRunner], [GenderId], [Club]) VALUES (53, N'Luis', N'Martin Sanchez-Perez', 2003, 1, N'703605778J', NULL, NULL, NULL, 1, N'M', N'Piedras Villarrubia')
INSERT [dbo].[Runner] ([Id], [Name], [SurName], [YearBirthday], [DocumentTypeId], [DNI], [Email], [Telephone], [PostalCode], [IsLocalRunner], [GenderId], [Club]) VALUES (54, N'Miguel', N'Moreno Gomez', 2003, 1, N'04249569C', NULL, NULL, NULL, 1, N'M', N'Piedras Villarrubia')
INSERT [dbo].[Runner] ([Id], [Name], [SurName], [YearBirthday], [DocumentTypeId], [DNI], [Email], [Telephone], [PostalCode], [IsLocalRunner], [GenderId], [Club]) VALUES (55, N'Jaime', N'Villarrubia Fernandez', 2003, 1, N'03935394W', NULL, NULL, NULL, 1, N'M', N'Piedras Villarrubia')
INSERT [dbo].[Runner] ([Id], [Name], [SurName], [YearBirthday], [DocumentTypeId], [DNI], [Email], [Telephone], [PostalCode], [IsLocalRunner], [GenderId], [Club]) VALUES (56, N'Sergio', N'Garcia-Movido Bravo', 2003, 1, N'70360047B', NULL, NULL, NULL, 1, N'M', N'Piedras Villlarrubia')
INSERT [dbo].[Runner] ([Id], [Name], [SurName], [YearBirthday], [DocumentTypeId], [DNI], [Email], [Telephone], [PostalCode], [IsLocalRunner], [GenderId], [Club]) VALUES (57, N'Mario', N'Rey Garoz', 2003, 1, N'03963428E', NULL, NULL, NULL, 1, N'M', N'Piedras Villarrubia')
INSERT [dbo].[Runner] ([Id], [Name], [SurName], [YearBirthday], [DocumentTypeId], [DNI], [Email], [Telephone], [PostalCode], [IsLocalRunner], [GenderId], [Club]) VALUES (58, N'Victor', N'Martin Manzano', 2003, 1, N'04230990W', NULL, NULL, NULL, 1, N'M', N'Piedras villarrubia')
INSERT [dbo].[Runner] ([Id], [Name], [SurName], [YearBirthday], [DocumentTypeId], [DNI], [Email], [Telephone], [PostalCode], [IsLocalRunner], [GenderId], [Club]) VALUES (59, N'Ismael', N'Villarrubia lopez', 2003, 1, N'04235912W', NULL, NULL, NULL, 1, N'M', N'Piedras Villarrubia')
INSERT [dbo].[Runner] ([Id], [Name], [SurName], [YearBirthday], [DocumentTypeId], [DNI], [Email], [Telephone], [PostalCode], [IsLocalRunner], [GenderId], [Club]) VALUES (60, N'Gonzalo', N'Marchan conejo', 2003, 1, N'03952223H', NULL, NULL, NULL, 1, N'M', N'Piedras Villarrubia')
INSERT [dbo].[Runner] ([Id], [Name], [SurName], [YearBirthday], [DocumentTypeId], [DNI], [Email], [Telephone], [PostalCode], [IsLocalRunner], [GenderId], [Club]) VALUES (61, N'Juan', N'Martin Gutierrez', 2003, 1, N'04234164W', NULL, NULL, NULL, 1, N'M', N'Piedras Villarrubia')
INSERT [dbo].[Runner] ([Id], [Name], [SurName], [YearBirthday], [DocumentTypeId], [DNI], [Email], [Telephone], [PostalCode], [IsLocalRunner], [GenderId], [Club]) VALUES (62, N'raul', N'ramirez Menchero', 1972, 1, N'03855864Y', NULL, NULL, 45400, 1, N'M', NULL)
SET IDENTITY_INSERT [dbo].[Runner] OFF
SET IDENTITY_INSERT [dbo].[Competition_Runner] ON 

INSERT [dbo].[Competition_Runner] ([Id], [CompetitionId], [RunnerId], [CategoryId], [Dorsal], [PositionId], [GeneralPosition], [GenderId], [Elapsed_Time]) VALUES (56, 1, 48, 12, NULL, 1, 0, N'F', N'15min 30seg')
INSERT [dbo].[Competition_Runner] ([Id], [CompetitionId], [RunnerId], [CategoryId], [Dorsal], [PositionId], [GeneralPosition], [GenderId], [Elapsed_Time]) VALUES (57, 1, 49, 5, 12345, 12, 2, N'M', N'30min 15seg')
INSERT [dbo].[Competition_Runner] ([Id], [CompetitionId], [RunnerId], [CategoryId], [Dorsal], [PositionId], [GeneralPosition], [GenderId], [Elapsed_Time]) VALUES (58, 1, 50, 5, 69878, 11, 0, N'M', N'6min 45 seg')
INSERT [dbo].[Competition_Runner] ([Id], [CompetitionId], [RunnerId], [CategoryId], [Dorsal], [PositionId], [GeneralPosition], [GenderId], [Elapsed_Time]) VALUES (59, 1, 51, 9, 12587, 3, 0, N'M', N'6min 50 seg')
INSERT [dbo].[Competition_Runner] ([Id], [CompetitionId], [RunnerId], [CategoryId], [Dorsal], [PositionId], [GeneralPosition], [GenderId], [Elapsed_Time]) VALUES (60, 1, 52, 9, 11111, 1, 0, N'M', N'6min 10 seg')
INSERT [dbo].[Competition_Runner] ([Id], [CompetitionId], [RunnerId], [CategoryId], [Dorsal], [PositionId], [GeneralPosition], [GenderId], [Elapsed_Time]) VALUES (61, 1, 53, 5, 22222, 2, 0, N'M', N'6min 11 seg')
INSERT [dbo].[Competition_Runner] ([Id], [CompetitionId], [RunnerId], [CategoryId], [Dorsal], [PositionId], [GeneralPosition], [GenderId], [Elapsed_Time]) VALUES (62, 1, 54, 5, 33333, 3, 0, N'M', N'6min 12 seg')
INSERT [dbo].[Competition_Runner] ([Id], [CompetitionId], [RunnerId], [CategoryId], [Dorsal], [PositionId], [GeneralPosition], [GenderId], [Elapsed_Time]) VALUES (63, 1, 55, 5, 44444, 4, 0, N'M', N'6min 13 seg')
INSERT [dbo].[Competition_Runner] ([Id], [CompetitionId], [RunnerId], [CategoryId], [Dorsal], [PositionId], [GeneralPosition], [GenderId], [Elapsed_Time]) VALUES (64, 1, 56, 5, 55555, 5, 0, N'M', N'6min 14 seg')
INSERT [dbo].[Competition_Runner] ([Id], [CompetitionId], [RunnerId], [CategoryId], [Dorsal], [PositionId], [GeneralPosition], [GenderId], [Elapsed_Time]) VALUES (65, 1, 57, 5, 66666, 6, 0, N'M', N'6min 15 seg')
INSERT [dbo].[Competition_Runner] ([Id], [CompetitionId], [RunnerId], [CategoryId], [Dorsal], [PositionId], [GeneralPosition], [GenderId], [Elapsed_Time]) VALUES (66, 1, 58, 5, 77777, 7, 0, N'M', N'6min 16 seg')
INSERT [dbo].[Competition_Runner] ([Id], [CompetitionId], [RunnerId], [CategoryId], [Dorsal], [PositionId], [GeneralPosition], [GenderId], [Elapsed_Time]) VALUES (67, 1, 59, 5, 88888, 8, 0, N'M', N'6min 20 seg')
INSERT [dbo].[Competition_Runner] ([Id], [CompetitionId], [RunnerId], [CategoryId], [Dorsal], [PositionId], [GeneralPosition], [GenderId], [Elapsed_Time]) VALUES (68, 1, 60, 5, 99999, 9, 0, N'M', N'6min 25 seg')
INSERT [dbo].[Competition_Runner] ([Id], [CompetitionId], [RunnerId], [CategoryId], [Dorsal], [PositionId], [GeneralPosition], [GenderId], [Elapsed_Time]) VALUES (69, 1, 61, 5, 23232, 10, 0, N'M', N'6min 40 seg')
INSERT [dbo].[Competition_Runner] ([Id], [CompetitionId], [RunnerId], [CategoryId], [Dorsal], [PositionId], [GeneralPosition], [GenderId], [Elapsed_Time]) VALUES (70, 1, 62, 9, NULL, 0, 0, N'M', NULL)
SET IDENTITY_INSERT [dbo].[Competition_Runner] OFF
INSERT [dbo].[Competition_Category] ([CompetitionId], [CategoryId], [GenderId], [YearFrom], [YearTo], [Id], [Description]) VALUES (1, 1, N'F', 2014, 2019, 1, N'Especial Femenino')
INSERT [dbo].[Competition_Category] ([CompetitionId], [CategoryId], [GenderId], [YearFrom], [YearTo], [Id], [Description]) VALUES (1, 1, N'M', 2014, 2019, 2, N'Especial Masculino')
INSERT [dbo].[Competition_Category] ([CompetitionId], [CategoryId], [GenderId], [YearFrom], [YearTo], [Id], [Description]) VALUES (1, 2, N'F', 2012, 2013, 3, N'Mini Benjamin Femenino')
INSERT [dbo].[Competition_Category] ([CompetitionId], [CategoryId], [GenderId], [YearFrom], [YearTo], [Id], [Description]) VALUES (1, 2, N'M', 2012, 2013, 4, N'Mini Benjamin Masculino')
INSERT [dbo].[Competition_Category] ([CompetitionId], [CategoryId], [GenderId], [YearFrom], [YearTo], [Id], [Description]) VALUES (1, 3, N'F', 2010, 2011, 5, N'Benjamin Femenino')
INSERT [dbo].[Competition_Category] ([CompetitionId], [CategoryId], [GenderId], [YearFrom], [YearTo], [Id], [Description]) VALUES (1, 3, N'M', 2010, 2011, 6, N'Benjamin Masculino')
INSERT [dbo].[Competition_Category] ([CompetitionId], [CategoryId], [GenderId], [YearFrom], [YearTo], [Id], [Description]) VALUES (1, 4, N'F', 2008, 2009, 7, N'Alevin Femenino')
INSERT [dbo].[Competition_Category] ([CompetitionId], [CategoryId], [GenderId], [YearFrom], [YearTo], [Id], [Description]) VALUES (1, 4, N'M', 2008, 2009, 8, N'Alevin Masculino')
INSERT [dbo].[Competition_Category] ([CompetitionId], [CategoryId], [GenderId], [YearFrom], [YearTo], [Id], [Description]) VALUES (1, 5, N'F', 2006, 2007, 9, N'Infantil Femenino')
INSERT [dbo].[Competition_Category] ([CompetitionId], [CategoryId], [GenderId], [YearFrom], [YearTo], [Id], [Description]) VALUES (1, 5, N'M', 2006, 2007, 10, N'Infantil Masculino')
INSERT [dbo].[Competition_Category] ([CompetitionId], [CategoryId], [GenderId], [YearFrom], [YearTo], [Id], [Description]) VALUES (1, 6, N'F', 2004, 2005, 11, N'Cadete Femenino')
INSERT [dbo].[Competition_Category] ([CompetitionId], [CategoryId], [GenderId], [YearFrom], [YearTo], [Id], [Description]) VALUES (1, 6, N'M', 2004, 2005, 12, N'Cadete Masculino')
INSERT [dbo].[Competition_Category] ([CompetitionId], [CategoryId], [GenderId], [YearFrom], [YearTo], [Id], [Description]) VALUES (1, 7, N'M', 2001, 2003, 13, N'Junior Masculino')
INSERT [dbo].[Competition_Category] ([CompetitionId], [CategoryId], [GenderId], [YearFrom], [YearTo], [Id], [Description]) VALUES (1, 8, N'M', 1980, 2000, 14, N'Senior Masculino')
INSERT [dbo].[Competition_Category] ([CompetitionId], [CategoryId], [GenderId], [YearFrom], [YearTo], [Id], [Description]) VALUES (1, 9, N'M', 1970, 1979, 15, N'Veteranos A Masculino')
INSERT [dbo].[Competition_Category] ([CompetitionId], [CategoryId], [GenderId], [YearFrom], [YearTo], [Id], [Description]) VALUES (1, 10, N'F', 1985, 2003, 16, N'Senior Femenina')
INSERT [dbo].[Competition_Category] ([CompetitionId], [CategoryId], [GenderId], [YearFrom], [YearTo], [Id], [Description]) VALUES (1, 11, N'M', 1900, 1969, 17, N'Veteranos B Masculino')
INSERT [dbo].[Competition_Category] ([CompetitionId], [CategoryId], [GenderId], [YearFrom], [YearTo], [Id], [Description]) VALUES (1, 12, N'F', 1900, 1980, 18, N'Veteranas Femenino')
INSERT [dbo].[Competition_Category] ([CompetitionId], [CategoryId], [GenderId], [YearFrom], [YearTo], [Id], [Description]) VALUES (1, 21, N'M', 1800, 1900, 19, N'General Masculino')
INSERT [dbo].[Competition_Category] ([CompetitionId], [CategoryId], [GenderId], [YearFrom], [YearTo], [Id], [Description]) VALUES (1, 22, N'M', 1800, 1900, 20, N'Local Masculino')

SET IDENTITY_INSERT [dbo].[User] ON 
INSERT [dbo].[User] ([UserId], [Username], [Password], [FullName], [EmailID], [IsActive]) VALUES (1, N'ANONYMOUS', N'Telefono15', N'Anonymous', N'', 1)
INSERT [dbo].[User] ([UserId], [Username], [Password], [FullName], [EmailID], [IsActive]) VALUES (2, N'ESRAMIREZR', N'Telefono15', N'Raul Ramirez', N'Raul.Ramirez@Telefonica.net', 1)
INSERT [dbo].[User] ([UserId], [Username], [Password], [FullName], [EmailID], [IsActive]) VALUES (3, N'ESTORRUBIASM', N'Portic63', N'Miguel Angel Torrubias Lopez', N'MiguelAngel.Trorrubias@tetrapak.com', 0)
INSERT [dbo].[User] ([UserId], [Username], [Password], [FullName], [EmailID], [IsActive]) VALUES (4, N'ESFERNANDEMI', N'Fernandez', N'Miguel Fernandez del Castillo Cebas', N'Miguel.Fernandez@tetrapak.com', 1)
SET IDENTITY_INSERT [dbo].[User] OFF

SET IDENTITY_INSERT [dbo].[Role] ON 
INSERT [dbo].[Role] ([Id], [Name], [Description]) VALUES (1, N'Administrador', N'Administrador')
INSERT [dbo].[Role] ([Id], [Name], [Description]) VALUES (2, N'Autorizado', N'Autorizado')
INSERT [dbo].[Role] ([Id], [Name], [Description]) VALUES (3, N'Usuario', N'Usuario')
SET IDENTITY_INSERT [dbo].[Role] OFF

INSERT [dbo].[UserRole] ([UserId], [RoleId], [Description]) VALUES (1, 3, N'Usuario Anonimo de Inicio de Conexion')
INSERT [dbo].[UserRole] ([UserId], [RoleId], [Description]) VALUES (2, 1, NULL)
INSERT [dbo].[UserRole] ([UserId], [RoleId], [Description]) VALUES (3, 2, NULL)
INSERT [dbo].[UserRole] ([UserId], [RoleId], [Description]) VALUES (4, 2, NULL)

